using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HigLabo.Web.UI
{
    public class HtmlAttributes : Dictionary<String, String>
    {
        public HtmlString GetHtmlString()
        {
            var sb = new StringBuilder();
            foreach (var kv in this)
            {
                sb.Append(HttpUtility.HtmlAttributeEncode(kv.Key));
                sb.Append("=");
                sb.Append("\"").Append(HttpUtility.HtmlAttributeEncode(kv.Value)).Append("\"");
                sb.Append(" ");
            }
            return new HtmlString(sb.ToString());
        }
    }
}
