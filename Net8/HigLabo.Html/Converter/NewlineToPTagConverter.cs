using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Html
{
    public class NewlineToPTagConverter : IHtmlConverter
    {
        public async ValueTask<string> ConvertAsync(string html)
        {
            var sb = new StringBuilder();
            if (html.Contains('\n') == false)
            {
                return html;
            }
            using (var sr = new StringReader(html))
            {
                while (sr.Peek() > -1)
                {
                    var line = sr.ReadLine();
                    if (line == null) { continue; }

                    sb.Append("<p>").Append(line).Append("</p>");
                }
            }
            return await ValueTask.FromResult(sb.ToString());
        }
    }
}
