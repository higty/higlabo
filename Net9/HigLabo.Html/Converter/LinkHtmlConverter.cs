using HigLabo.Html.Converter;
using System.Text.RegularExpressions;
using System.Web;

namespace HigLabo.Html;

public class LinkHtmlConverter : RegexHtmlConverter, IUrlConverter
{
    public static class RegexList
    {
        public static Regex P_http = new Regex("<p>(?<Url>http://[^<]*)</p>", RegexOptions.IgnoreCase);
        public static Regex P_https = new Regex("<p>(?<Url>https://[^<]*)</p>", RegexOptions.IgnoreCase);
    }

    public List<string> UrlList { get; init; } = new List<string>();

    protected override IEnumerable<Regex> GetRegexList()
    {
        yield return RegexList.P_http;
        yield return RegexList.P_https;
    }
    protected override ValueTask<String> ReplaceAsync(Match match)
    {
        var m = match;
        var url = m.Groups["Url"].Value;

        this.UrlList.Add(url);
        return ValueTask.FromResult($"<p><a href=\"{HttpUtility.HtmlAttributeEncode(url)}\" target=\"_blank\">{url}</a></p>");
    }
}
