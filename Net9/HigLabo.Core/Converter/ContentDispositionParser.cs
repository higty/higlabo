using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

public sealed class ContentDispositionParseResult
{
    /// <summary>Disposition type (e.g., attachment, inline).</summary>
    public string DispositionType { get; init; } = string.Empty;

    /// <summary>Extracted filename (preferring extended/continuation if configured).</summary>
    public string? FileName { get; init; }

    private readonly Dictionary<string, string> _parameters = new(StringComparer.OrdinalIgnoreCase);

    internal ContentDispositionParseResult(string type, Dictionary<string, string> parameters, string? fileName)
    {
        DispositionType = type;
        _parameters = parameters;
        FileName = fileName;
    }

    /// <summary>
    /// Indexer to access parameter values. Returns null if the key does not exist.
    /// </summary>
    public string? this[string name]
    {
        get
        {
            if (_parameters.TryGetValue(name, out var v))
                return v;
            return null;
        }
    }

    /// <summary>
    /// Try to get a parameter value safely (returns false if not present).
    /// </summary>
    public bool TryGetValue(string name, out string? value)
    {
        if (_parameters.TryGetValue(name, out var v))
        {
            value = v;
            return true;
        }
        value = null;
        return false;
    }
}

public sealed class ContentDispositionParser
{
    // ----------------------- Configurable properties -----------------------

    /// <summary>
    /// Prefer extended filename parameters (RFC5987/6266 and RFC2231 continuation) over legacy "filename".
    /// </summary>
    public bool PreferExtendedFilename { get; set; } = true;

    /// <summary>
    /// Allow legacy "filename" parameter as a fallback when extended ones are absent.
    /// </summary>
    public bool AllowLegacyFilename { get; set; } = true;

    /// <summary>
    /// Treat '+' as space during percent-decoding (usually false for RFC5987/2231).
    /// </summary>
    public bool TreatPlusAsSpace { get; set; } = false;

    /// <summary>
    /// Default encoding when no charset is specified for continuation; UTF-8 by default.
    /// </summary>
    public Encoding DefaultEncoding { get; set; } = Encoding.UTF8;

    /// <summary>
    /// Fallback encoding if a declared charset is unknown/unsupported; UTF-8 by default.
    /// </summary>
    public Encoding UnknownCharsetFallbackEncoding { get; set; } = Encoding.UTF8;

    // ------------------------------ API methods ----------------------------

    /// <summary>
    /// Parse a Content-Disposition header string into a structured result.
    /// </summary>
    public ContentDispositionParseResult Parse(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("value is null or empty", nameof(value));

        var parts = SplitSemicolonAware(value);
        if (parts.Count == 0)
            throw new FormatException("Invalid Content-Disposition header.");

        // First token is the disposition type (e.g., "attachment", "inline").
        var type = parts[0].Trim();
        int colon = type.IndexOf(':'); // tolerate "Content-Disposition: attachment; ..."
        if (colon >= 0) type = type[(colon + 1)..].Trim();
        if (string.IsNullOrEmpty(type))
            throw new FormatException("Disposition type is missing.");

        var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        // Collect parameters (name=value).
        for (int i = 1; i < parts.Count; i++)
        {
            var item = parts[i];
            if (string.IsNullOrWhiteSpace(item)) continue;

            int eq = item.IndexOf('=');
            if (eq <= 0) continue;

            var name = item[..eq].Trim();
            var rawVal = item[(eq + 1)..].Trim();
            dict[name] = ParseParameterValue(rawVal);
        }

        string? fileName = ExtractFileName(dict);

        return new ContentDispositionParseResult(type, dict, fileName);
    }

    /// <summary>
    /// Convenience method to return only the filename from a Content-Disposition header.
    /// </summary>
    public string? GetFileName(string value) => Parse(value).FileName;

    // --------------------------- Internal helpers --------------------------

    private string? ExtractFileName(Dictionary<string, string> dict)
    {
        // Prefer extended/continuation if configured
        if (PreferExtendedFilename)
        {
            // --- RFC2231 continuation handling (filename*0*, filename*1, ...) ---
            var contKeys = dict.Keys
                .Where(k => k.StartsWith("filename*", StringComparison.OrdinalIgnoreCase) && k.Length > 9)
                .Select(k => new
                {
                    Key = k,
                    Index = ParseContinuationIndex(k),
                    IsExtended = k.EndsWith("*", StringComparison.OrdinalIgnoreCase)
                })
                .Where(x => x.Index >= 0)
                .OrderBy(x => x.Index)
                .ToList();

            if (contKeys.Count > 0)
            {
                // Determine charset/lang from the first extended segment if present.
                var firstKey = contKeys[0];
                var firstVal = dict[firstKey.Key];
                string? charset = null;

                if (firstKey.IsExtended)
                {
                    // RFC2231 form: charset'lang'value
                    int tick1 = firstVal.IndexOf('\'');
                    int tick2 = firstVal.IndexOf('\'', tick1 + 1);
                    if (tick1 > 0 && tick2 > tick1)
                    {
                        charset = firstVal[..tick1];
                        // Keep 'value' part only for the first segment.
                        dict[firstKey.Key] = firstVal[(tick2 + 1)..];
                    }
                }

                var bytes = new List<byte>();
                foreach (var part in contKeys)
                {
                    var val = dict[part.Key];

                    // Leniently strip quotes and unescape on each segment (handles \"...\")
                    val = StripLooseQuotesAndUnescape(val);

                    if (part.IsExtended)
                        bytes.AddRange(PercentDecodeToBytes(val));
                    else
                        bytes.AddRange(Encoding.ASCII.GetBytes(val));
                }

                try
                {
                    var enc = charset != null ? GetEncodingLenient(charset) : DefaultEncoding;
                    return enc.GetString(bytes.ToArray());
                }
                catch
                {
                    return UnknownCharsetFallbackEncoding.GetString(bytes.ToArray());
                }
            }

            // --- Single extended parameter: filename* (RFC5987/6266) ---
            if (dict.TryGetValue("filename*", out var ext))
            {
                if (TryDecodeRfc5987(ext, out var decoded))
                    return decoded;
                else
                    return ext;
            }
        }

        // --- Legacy parameter: filename ---
        if (AllowLegacyFilename && dict.TryGetValue("filename", out var normal))
        {
            return UnquoteAndUnescape(normal);
        }

        return null;
    }

    private static int ParseContinuationIndex(string key)
    {
        // Accept keys like: "filename*0*", "filename*1", "filename*2*"
        var name = key.Substring(9); // after "filename*"
        name = name.TrimEnd('*');
        if (int.TryParse(name, NumberStyles.None, CultureInfo.InvariantCulture, out var index))
            return index;
        return -1;
    }

    private static List<string> SplitSemicolonAware(string header)
    {
        // Split by ';' but ignore semicolons inside quoted-strings.
        var list = new List<string>();
        var sb = new StringBuilder();
        bool inQuotes = false;
        bool escape = false;

        foreach (var c in header)
        {
            if (escape)
            {
                sb.Append(c);
                escape = false;
            }
            else if (c == '\\' && inQuotes)
            {
                escape = true;
            }
            else if (c == '"')
            {
                inQuotes = !inQuotes;
                sb.Append(c);
            }
            else if (c == ';' && !inQuotes)
            {
                list.Add(sb.ToString().Trim());
                sb.Clear();
            }
            else
            {
                sb.Append(c);
            }
        }
        if (sb.Length > 0) list.Add(sb.ToString().Trim());

        return list;
    }

    private static string ParseParameterValue(string raw)
    {
        // If quoted-string, unquote and unescape; otherwise return as-is.
        return IsQuotedString(raw) ? UnquoteAndUnescape(raw) : raw;
    }

    private static bool IsQuotedString(string s) =>
        s.Length >= 2 && s[0] == '"' && s[^1] == '"';

    private static string UnquoteAndUnescape(string s)
    {
        // Remove surrounding quotes and resolve backslash-escapes inside.
        if (!IsQuotedString(s))
            return s.Replace("\\\"", "\"").Replace("\\\\", "\\");

        var inner = s.Substring(1, s.Length - 2);
        var sb = new StringBuilder(inner.Length);
        bool escape = false;

        foreach (var c in inner)
        {
            if (escape)
            {
                sb.Append(c); // \" -> ", \\ -> \
                escape = false;
            }
            else if (c == '\\')
            {
                escape = true;
            }
            else
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }

    /// <summary>
    /// Strip surrounding quotes (even if only loosely present like \"...\") and unescape \" and \\.
    /// </summary>
    private static string StripLooseQuotesAndUnescape(string s)
    {
        if (string.IsNullOrEmpty(s)) return s ?? string.Empty;

        var t = s.Trim();

        // Replace backslash-escaped quotes/backslashes first.
        t = t.Replace("\\\"", "\"").Replace("\\\\", "\\");

        // Remove surrounding quotes if present now.
        if (t.Length >= 2 && t[0] == '"' && t[^1] == '"')
            t = t.Substring(1, t.Length - 2);

        // Final trim (handles cases like " %..% ").
        return t.Trim();
    }

    private bool TryDecodeRfc5987(string extendedValue, out string result)
    {
        // Decode "charset'lang'value" where value is percent-encoded.
        result = extendedValue;

        // Be tolerant to outer quotes and escapes first.
        var v = UnquoteAndUnescape(extendedValue).Trim();

        int tick1 = v.IndexOf('\'');
        int tick2 = v.IndexOf('\'', tick1 + 1);

        // FIX: Allow empty language tag (e.g., UTF-8'') and even empty value.
        // Conditions to reject:
        //  - no first tick
        //  - no second tick
        //  - second tick not after the first tick
        // NOTE: We DO NOT require any characters after the second tick.
        if (tick1 <= 0 || tick2 < 0 || tick2 < tick1 + 1)
            return false;

        var charset = v[..tick1];
        var encoded = v[(tick2 + 1)..].Trim();

        // Be lenient with quotes only around the encoded part (supports "..." or \"...\").
        encoded = StripLooseQuotesAndUnescape(encoded);

        try
        {
            var bytes = PercentDecodeToBytes(encoded);
            var enc = GetEncodingLenient(charset);
            result = enc.GetString(bytes);
            return true;
        }
        catch
        {
            // Fallback decode with the configured fallback encoding
            result = UnknownCharsetFallbackEncoding.GetString(PercentDecodeToBytes(encoded));
            return true; // treat as successfully decoded with fallback
        }
    }
    private byte[] PercentDecodeToBytes(string s)
    {
        // Percent-decode to raw bytes. '+' handling is configurable.
        var buffer = new List<byte>(s.Length);
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (c == '%' && i + 2 < s.Length &&
                Uri.IsHexDigit(s[i + 1]) && Uri.IsHexDigit(s[i + 2]))
            {
                buffer.Add(Convert.ToByte(s.Substring(i + 1, 2), 16));
                i += 2;
            }
            else if (c == '+' && TreatPlusAsSpace)
            {
                buffer.Add((byte)' ');
            }
            else
            {
                // For ASCII characters, append as-is; for non-ASCII, encode to UTF-8.
                if (c <= 0x7F)
                    buffer.Add((byte)c);
                else
                    buffer.AddRange(Encoding.UTF8.GetBytes(new[] { c }));
            }
        }
        return buffer.ToArray();
    }

    private Encoding GetEncodingLenient(string name)
    {
        try
        {
            return Encoding.GetEncoding(name);
        }
        catch
        {
            return UnknownCharsetFallbackEncoding;
        }
    }
}
