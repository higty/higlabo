using HigLabo.Core;
using HigLabo.Html.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HigLabo.Html;

public class YoutubeEmbedHtmlConverter : RegexHtmlConverter, IUrlConverter
{
    public static class RegexList
    {
        public static Regex P_https_www_youtube_com = new Regex("<p>(?<Url>https://www.youtube.com/[^<]*)</p>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        public static Regex P_https_youtu_be = new Regex("<p>(?<Url>https://youtu.be/[^<]*)</p>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    }

    public List<string> UrlList { get; init; } = new List<string>();

    protected override IEnumerable<Regex> GetRegexList()
    {
        yield return RegexList.P_https_www_youtube_com;
        yield return RegexList.P_https_youtu_be;
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
        var id = "";
        id = GetVideoIDFromUrl(url);
        if (id.IsNullOrEmpty() == false) { return id; }
        id = GetYoutubeIDFromShortUrl(url);
        if (id.IsNullOrEmpty() == false) { return id; }
        return "";
    }
    private static String GetVideoIDFromUrl(String url)
    {
        if (url.StartsWith("https://www.youtube.com/watch?v="))
        {
            return url.ExtractString('=', null);
        }
        return "";
    }
    private static String GetYoutubeIDFromShortUrl(String url)
    {
        if (url.StartsWith("https://youtu.be/"))
        {
            return url.Substring(17, url.Length - 17);
        }
        return "";
    }
    public static String CreateEmbedHtml(String videoID)
    {
        return String.Format("<iframe src=\"//www.youtube.com/embed/{0}?rel=0\"", videoID)
             + " frameborder=\"0\" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>";
    }
}
