using HigLabo.Html.Converter;
using System.Text.RegularExpressions;

namespace HigLabo.Html;

public class VimeoEmbedHtmlConverter : RegexHtmlConverter, IUrlConverter
{
    public static class RegexList
    {
        public static Regex P_https_vimeo_com = new Regex("<p>(?<Url>https://vimeo.com/[^<]*)</p>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    }
    public List<string> UrlList { get; init; } = new List<string>();

    protected override IEnumerable<Regex> GetRegexList()
    {
        yield return RegexList.P_https_vimeo_com;
    }
    protected override ValueTask<String> ReplaceAsync(Match match)
    {
        var m = match;
        var url = m.Groups["Url"].Value;
        this.UrlList.Add(url);

        var videoID = GetVideoID(url);
        var html = CreateEmbedHtml(videoID);
        return ValueTask.FromResult(html);
    }
    public static String GetVideoID(String url)
    {
        if (url.StartsWith("https://vimeo.com/"))
        {
            return url.Substring(18, url.Length - 18);
        }
        return "";
    }
    public static String CreateEmbedHtml(String videoID)
    {
        return String.Format("<iframe src=\"https://player.vimeo.com/video/{0}\"", videoID)
             + " frameborder=\"0\" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>";
    }
}
