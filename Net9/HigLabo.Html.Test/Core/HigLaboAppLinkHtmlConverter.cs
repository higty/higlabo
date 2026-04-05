using AngleSharp.Html.Parser;
using HigLabo.Html;
using HigLabo.Html.Converter;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace HigLaboApp.Core;

public class HigLaboAppLinkHtmlConverter : RegexHtmlConverter
{
    private static readonly HashSet<string> ImageExtensionSet = new(StringComparer.OrdinalIgnoreCase)
    {
        ".gif", ".png", ".jpg", ".jpeg", ".webp", ".svg", ".avif"
    };

    public static class RegexList
    {
        public static Regex P_https = new Regex(@"<p[^>]*>\s*(?<Url>https?://[^\s<]+)\s*</p>", RegexOptions.IgnoreCase);
        public static Regex Https = new Regex("^\\s*(?<Url>(http|https)://[^<\\n\\r]*)[\\n\\r]*", RegexOptions.IgnoreCase | RegexOptions.Multiline);
    }


    protected override IEnumerable<Regex> GetRegexList()
    {
        yield return RegexList.P_https;
        yield return RegexList.Https;
    }
    protected override ValueTask<string> ReplaceAsync(Match match)
    {
        var m = match;
        var url = m.Groups["Url"].Value;

        return ValueTask.FromResult($"<p><a href=\"{HttpUtility.HtmlAttributeEncode(url)}\" target=\"_blank\">{url}</a></p>");
    }
}
