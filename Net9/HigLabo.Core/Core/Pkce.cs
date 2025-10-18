using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace HigLabo.Core;

public static class Pkce
{
    // RFC 7636: code_verifier は 43〜128 文字、[A-Z] / [a-z] / [0-9] / "-" / "." / "_" / "~"
    private static readonly Regex VerifierRegex =
        new(@"^[A-Za-z0-9\-._~]{43,128}$", RegexOptions.Compiled);

    // Base64URL（パディングなし）
    private static readonly Regex Base64UrlRegex =
        new(@"^[A-Za-z0-9\-_]+$", RegexOptions.Compiled);

    public static bool Verify(string codeChallengeMethod, string codeChallenge, string codeVerifier)
    {
        if (string.IsNullOrEmpty(codeChallenge) || string.IsNullOrEmpty(codeVerifier)) return false;
        if (!VerifierRegex.IsMatch(codeVerifier)) return false;

        // plain
        if (string.IsNullOrEmpty(codeChallengeMethod) || codeChallengeMethod.Equals("plain", StringComparison.OrdinalIgnoreCase))
        {
            return FixedTimeEquals(codeChallenge, codeVerifier);
        }

        // S256
        if (codeChallengeMethod.Equals("S256", StringComparison.OrdinalIgnoreCase))
        {
            // 参考: SHA-256 (32 bytes) → Base64URL(パディング無し) は 43 文字になる
            if (codeChallenge.Length != 43 || !Base64UrlRegex.IsMatch(codeChallenge)) return false;

            var computed = ComputeS256Challenge(codeVerifier);
            return FixedTimeEquals(codeChallenge, computed);
        }

        throw new NotSupportedException($"{codeChallengeMethod} is not supported.");
    }

    public static string ComputeS256Challenge(string codeVerifier)
    {
        // code_verifier は ASCII 定義なので ASCII でOK
        ReadOnlySpan<byte> bytes = Encoding.ASCII.GetBytes(codeVerifier);
        Span<byte> hash = stackalloc byte[32]; // SHA-256
        SHA256.HashData(bytes, hash);
        return Base64UrlEncode(hash);
    }

    private static string Base64UrlEncode(ReadOnlySpan<byte> bytes)
    {
        // .NET 5+ では ReadOnlySpan<byte> オーバーロードあり（ToArray不要）
        var s = Convert.ToBase64String(bytes);
        return s.Replace('+', '-').Replace('/', '_').TrimEnd('=');
    }

    private static bool FixedTimeEquals(string a, string b)
    {
        if (a is null || b is null) return false;
        // Base64URLやplainはバイト列にして比較（ASCIIで十分）
        ReadOnlySpan<byte> ba = Encoding.ASCII.GetBytes(a);
        ReadOnlySpan<byte> bb = Encoding.ASCII.GetBytes(b);
        return CryptographicOperations.FixedTimeEquals(ba, bb);
    }
}
