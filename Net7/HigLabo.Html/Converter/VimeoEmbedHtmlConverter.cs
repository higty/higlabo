using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HigLabo.Html
{
    public class VimeoEmbedHtmlConverter : RegexHtmlConverter
    {
        public static class RegexList
        {
            public static Regex P_https_vimeo_com = new Regex("<p>(?<Url>https://vimeo.com/[^<]*)</p>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }

        protected override IEnumerable<Regex> GetRegexList()
        {
            yield return RegexList.P_https_vimeo_com;
        }
        public static String GetVideoID(String url)
        {
            if (url.StartsWith("https://vimeo.com/"))
            {
                return url.Substring(18, url.Length - 18);
            }
            return "";
        }
        protected override String Convert(Match match)
        {
            var m = match;
            var url = m.Groups["Url"].Value;

            var videoID = GetVideoID(url);
            var html = CreateEmbedHtml(videoID);
            return html;
        }
        public static String CreateEmbedHtml(String videoID)
        {
            return String.Format("<iframe src=\"https://player.vimeo.com/video/{0}\"", videoID)
                 + " frameborder=\"0\" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>";
        }
    }
}
