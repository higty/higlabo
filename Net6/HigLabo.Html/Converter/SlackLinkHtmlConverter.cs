using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HigLabo.Html
{
    public class SlackLinkHtmlConverter : RegexHtmlConverter
    {
        public static class RegexList
        {
            public static Regex Http_url = new Regex("<http(?<Url>[^>]*)>", RegexOptions.IgnoreCase);
        }
        protected override IEnumerable<Regex> GetRegexList()
        {
            yield return RegexList.Http_url;
        }
        protected override String Convert(Match match)
        {
            var m = match;
            var urlList = "http" + m.Groups["Url"].Value;

            foreach (var url in urlList.Split('|'))
            {
                return $"<a href=\"{url}\" target=\"_blank\">{url}</a>";
            }
            {
                var url = urlList;
                return $"<a href=\"{url}\" target=\"_blank\">{url}</a>";
            }
        }

    }
}
