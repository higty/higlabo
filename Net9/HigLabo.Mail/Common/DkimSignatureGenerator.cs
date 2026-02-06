using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HigLabo.Net.Smtp;

public enum DkimCanonicalization
{
    Simple,
    Relaxed
}
public enum SigninAlgorithm
{
    RSASha1,
    RSASha256
}

public class DkimSignatureGenerator
{
    public static readonly string SignatureKey = "DKIM-Signature";
    private const string CrLf = "\r\n";

    private readonly string _Domain;
    private readonly string _Selector;

    public DkimCanonicalization HeaderCanonicalization { get; set; } = DkimCanonicalization.Relaxed;
    public DkimCanonicalization BodyCanonicalization { get; set; } = DkimCanonicalization.Relaxed;

    public List<string> HeaderKeys { get; private set; }
    public SigninAlgorithm SigninAlgorithm { get; set; } = SigninAlgorithm.RSASha256;
    public Encoding Encoding { get; set; } = Encoding.UTF8;

    public X509Certificate2 Certificate { get; private set; }

    public DkimSignatureGenerator(string pfxFilePath, string? password, string domain, string selector, IEnumerable<string>? headerKeys)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(domain);
        ArgumentException.ThrowIfNullOrWhiteSpace(selector);
        ArgumentException.ThrowIfNullOrWhiteSpace(pfxFilePath);

        if (!File.Exists(pfxFilePath))
            throw new FileNotFoundException("PFX file not found.", pfxFilePath);

        // Exportable が本当に必要なら残す。不要なら外した方が安全。
        Certificate = new X509Certificate2(pfxFilePath, password, X509KeyStorageFlags.Exportable);

        using (var rsa = Certificate.GetRSAPrivateKey())
        {
            if (rsa is null)
                throw new InvalidOperationException($"PFX does not contain an RSA private key. File: {pfxFilePath}");
        }

        _Domain = domain;
        _Selector = selector;

        HeaderKeys = (headerKeys ?? Array.Empty<string>())
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => x.Trim())
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();

        if (HeaderKeys.Count == 0)
            HeaderKeys.Add("From");
    }

    public string GenerateDkimHeaderValue(string body)
    {
        body ??= string.Empty;

        long unixTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        var signatureValue = new StringBuilder(512);

        signatureValue.Append("v=1;");
        signatureValue.Append(" a=").Append(GetAlgorithmName()).Append(';');
        signatureValue.Append(" c=").Append(HeaderCanonicalization.ToString().ToLowerInvariant())
                      .Append('/').Append(BodyCanonicalization.ToString().ToLowerInvariant()).Append(';');
        signatureValue.Append(" d=").Append(_Domain).Append(';');
        signatureValue.Append(" q=dns;");
        signatureValue.Append(" s=").Append(_Selector).Append(';');
        signatureValue.Append(" t=").Append(unixTime).Append(';');

        // headers to sign
        signatureValue.Append(" h=");
        for (int i = 0; i < HeaderKeys.Count; i++)
        {
            if (string.IsNullOrWhiteSpace(HeaderKeys[i])) continue;
            signatureValue.Append(HeaderKeys[i]).Append(':');
        }
        if (signatureValue[^1] == ':') signatureValue.Length--;
        signatureValue.Append(';');

        // body hash
        signatureValue.Append(" bh=").Append(SignBody(body)).Append(';');

        // signature (b=) is appended later
        signatureValue.Append(" b=");

        return signatureValue.ToString();
    }

    public string GenerateSignature(List<SmtpMailHeader> headers)
    {
        if (headers is null) throw new ArgumentNullException(nameof(headers));

        // DKIM-Signature 自身も署名対象に含める前提（呼び出し側が空の b= を含むヘッダーを追加してから呼ぶ）
        var headersText = CanonicalizeHeaders(headers);
        var sig = Sign(Encoding.GetBytes(headersText), SigninAlgorithm);
        return Convert.ToBase64String(sig);
    }

    public string SignBody(string body)
    {
        body ??= string.Empty;
        var cb = CanonicalizeBody(body);
        var hash = Hash(Encoding.GetBytes(cb), SigninAlgorithm);
        return Convert.ToBase64String(hash);
    }

    public byte[] Sign(byte[] data, SigninAlgorithm algorithm)
    {
        ArgumentNullException.ThrowIfNull(data);

        using RSA? rsa = Certificate.GetRSAPrivateKey();
        if (rsa is null)
            throw new InvalidOperationException("Certificate does not have an RSA private key.");

        var hashAlg = algorithm switch
        {
            SigninAlgorithm.RSASha1 => HashAlgorithmName.SHA1,
            SigninAlgorithm.RSASha256 => HashAlgorithmName.SHA256,
            _ => throw new ArgumentOutOfRangeException(nameof(algorithm))
        };

        return rsa.SignData(data, hashAlg, RSASignaturePadding.Pkcs1);
    }

    private string GetAlgorithmName()
    {
        return SigninAlgorithm switch
        {
            SigninAlgorithm.RSASha1 => "rsa-sha1",
            SigninAlgorithm.RSASha256 => "rsa-sha256",
            _ => throw new InvalidOperationException("Invalid SigninAlgorithm.")
        };
    }

    // ---- Canonicalization ----

    public string CanonicalizeHeaders(List<SmtpMailHeader> headers)
    {
        if (headers is null) throw new ArgumentNullException(nameof(headers));

        // DKIM-Signature が署名対象に入っていないなら追加（HeaderKeys のみ）
        if (!HeaderKeys.Contains(SignatureKey, StringComparer.OrdinalIgnoreCase))
            HeaderKeys.Add(SignatureKey);

        ValidateHeaders(headers);

        // 同名ヘッダー複数対応：Key -> list (出現順)
        var map = BuildHeaderMap(headers);

        // DKIM spec 的には “下から” 取る（同名ヘッダーは最後のものが優先される）
        var remainingIndexFromBottom = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        foreach (var kv in map)
            remainingIndexFromBottom[kv.Key] = kv.Value.Count - 1;

        var sb = new StringBuilder(1024);

        foreach (var keyRaw in HeaderKeys)
        {
            if (string.IsNullOrWhiteSpace(keyRaw)) continue;
            var key = keyRaw.Trim();

            var header = TakeHeaderFromBottom(map, remainingIndexFromBottom, key);

            // ※ key は HeaderKeys 側の表記を尊重（Simple での互換性）
            // Relaxed では lowercase にする
            switch (HeaderCanonicalization)
            {
                case DkimCanonicalization.Simple:
                    sb.Append(key);
                    sb.Append(':').Append(' ');
                    sb.Append(header.Value);
                    sb.Append(CrLf);
                    break;

                case DkimCanonicalization.Relaxed:
                    sb.Append(RelaxHeaderName(key));
                    sb.Append(':');
                    sb.Append(RelaxHeaderValue(header.Value));
                    sb.Append(CrLf);
                    break;

                default:
                    throw new ArgumentException("Invalid canonicalization type.");
            }
        }

        if (sb.Length >= CrLf.Length)
            sb.Length -= CrLf.Length;

        return sb.ToString();
    }

    private static Dictionary<string, List<SmtpMailHeader>> BuildHeaderMap(List<SmtpMailHeader> headers)
    {
        var map = new Dictionary<string, List<SmtpMailHeader>>(StringComparer.OrdinalIgnoreCase);
        for (int i = 0; i < headers.Count; i++)
        {
            var h = headers[i];
            if (!map.TryGetValue(h.Key, out var list))
            {
                list = new List<SmtpMailHeader>();
                map[h.Key] = list;
            }
            list.Add(h);
        }
        return map;
    }

    private static SmtpMailHeader TakeHeaderFromBottom(
        Dictionary<string, List<SmtpMailHeader>> map,
        Dictionary<string, int> remainingIndexFromBottom,
        string key)
    {
        if (!map.TryGetValue(key, out var list) || list.Count == 0)
            throw new InvalidOperationException($"Header not found: {key}");

        if (!remainingIndexFromBottom.TryGetValue(key, out int idx))
            idx = list.Count - 1;

        if (idx < 0)
            throw new InvalidOperationException($"Header exhausted (too many occurrences requested): {key}");

        remainingIndexFromBottom[key] = idx - 1;
        return list[idx];
    }

    private void ValidateHeaders(List<SmtpMailHeader> headers)
    {
        var existing = new HashSet<string>(headers.Select(x => x.Key), StringComparer.OrdinalIgnoreCase);

        if (!existing.Contains("From"))
            throw new InvalidOperationException("The From header must not be null. Please set From property of SmtpMessage object.");

        var invalid = HeaderKeys
            .Where(k => !string.IsNullOrWhiteSpace(k))
            .Select(k => k.Trim())
            .Where(k => !existing.Contains(k))
            .ToList();

        // DKIM-Signature は GenerateSignature 呼び出し前に “空の b=” を含むヘッダーとして追加する運用が多い
        // ここで弾くと分かりやすい。
        if (invalid.Count > 0)
            throw new ArgumentException("The following headers do not exist. " + string.Join(", ", invalid));
    }

    public string CanonicalizeBody(string body)
    {
        body ??= string.Empty;

        // 行単位に正規化（入力が \r\n / \n / \r 混在でも対応）
        var lines = SplitLines(body);

        switch (BodyCanonicalization)
        {
            case DkimCanonicalization.Simple:
                return CanonicalizeBodySimple(lines);

            case DkimCanonicalization.Relaxed:
                return CanonicalizeBodyRelaxed(lines);

            default:
                throw new ArgumentException("Invalid canonicalization type.");
        }
    }

    private static string CanonicalizeBodySimple(List<string> lines)
    {
        // Simple:
        // - 行末は CRLF
        // - 末尾の空行は “すべて削除” して、最後に CRLF を 1つだけ残す
        int lastNonEmpty = lines.Count - 1;
        while (lastNonEmpty >= 0 && lines[lastNonEmpty].Length == 0)
            lastNonEmpty--;

        var sb = new StringBuilder();
        if (lastNonEmpty < 0)
        {
            // empty body -> CRLF
            sb.Append(CrLf);
            return sb.ToString();
        }

        for (int i = 0; i <= lastNonEmpty; i++)
        {
            sb.Append(lines[i]);
            sb.Append(CrLf);
        }
        return sb.ToString();
    }

    private static string CanonicalizeBodyRelaxed(List<string> lines)
    {
        // Relaxed:
        // - 行末の WSP を削除
        // - 行中の連続 WSP を 1 つの SP に縮約
        // - 末尾の空行は削除
        // - 最後に CRLF を 1つ付ける（空ボディでも CRLF）
        var processed = new List<string>(lines.Count);
        foreach (var line in lines)
        {
            var trimmedEnd = TrimEndWsp(line);
            var compressed = CompressWspToSingleSpace(trimmedEnd);
            processed.Add(compressed);
        }

        int lastNonEmpty = processed.Count - 1;
        while (lastNonEmpty >= 0 && processed[lastNonEmpty].Length == 0)
            lastNonEmpty--;

        var sb = new StringBuilder();
        if (lastNonEmpty < 0)
        {
            sb.Append(CrLf);
            return sb.ToString();
        }

        for (int i = 0; i <= lastNonEmpty; i++)
        {
            sb.Append(processed[i]);
            sb.Append(CrLf);
        }
        return sb.ToString();
    }

    private static List<string> SplitLines(string text)
    {
        var lines = new List<string>();
        using var reader = new StringReader(text);

        string? line;
        while ((line = reader.ReadLine()) is not null)
            lines.Add(line);

        return lines;
    }

    private static string RelaxHeaderName(string name)
        => name.Trim().ToLowerInvariant();

    private static string RelaxHeaderValue(string value)
    {
        // DKIM relaxed:
        // - unfold はここでは扱わない（SmtpMailHeader.Value が unfold 済み前提）
        // - 前後WSP削除
        // - 連続WSPは1つのSPへ
        value ??= string.Empty;
        value = value.Trim();
        return CompressWspToSingleSpace(value);
    }

    private static string TrimEndWsp(string s)
    {
        int end = s.Length - 1;
        while (end >= 0 && (s[end] == ' ' || s[end] == '\t'))
            end--;
        return end < 0 ? string.Empty : s.Substring(0, end + 1);
    }

    private static string CompressWspToSingleSpace(string s)
    {
        if (s.Length == 0) return s;

        var sb = new StringBuilder(s.Length);
        bool inWsp = false;

        foreach (char c in s)
        {
            bool wsp = (c == ' ' || c == '\t');
            if (wsp)
            {
                if (!inWsp) sb.Append(' ');
                inWsp = true;
            }
            else
            {
                sb.Append(c);
                inWsp = false;
            }
        }
        return sb.ToString();
    }

    public static byte[] Hash(byte[] data, SigninAlgorithm algorithm)
    {
        ArgumentNullException.ThrowIfNull(data);

        return algorithm switch
        {
            SigninAlgorithm.RSASha1 => SHA1.HashData(data),
            SigninAlgorithm.RSASha256 => SHA256.HashData(data),
            _ => throw new ArgumentOutOfRangeException(nameof(algorithm))
        };
    }
}
