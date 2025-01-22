using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace HigLabo.Html;

public class LinkHtmlConverter : RegexHtmlConverter
{
    public static class RegexList
    {
        public static Regex P_http = new Regex("<p>(?<Url>http://[^<]*)</p>", RegexOptions.IgnoreCase);
        public static Regex P_https = new Regex("<p>(?<Url>https://[^<]*)</p>", RegexOptions.IgnoreCase);
    }
    protected override IEnumerable<Regex> GetRegexList()
    {
        yield return RegexList.P_http;
        yield return RegexList.P_https;
    }
    protected override string Convert(Match match)
    {
        var m = match;
        var url = m.Groups["Url"].Value;

        return String.Format("<p><a href=\"{0}\" target=\"_blank\">{1}</a></p>"
            , HttpUtility.HtmlAttributeEncode(url), url);
    }
}
