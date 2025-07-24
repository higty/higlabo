using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Html;

public class LineToPTagConverter : IHtmlConverter
{
    private Func<string, bool> _IsProcess = line => true;
    public Func<string, bool> IsProcess
    {
        get { return this._IsProcess; }
        set
        {
            if (value == null) { return; }
            _IsProcess = value;
        }
    }

    public async ValueTask<string> ConvertAsync(string html)
    {
        var sb = new StringBuilder();
        if (html.Contains('\n') == false)
        {
            return $"<p>{html}</p>";
        }
        using (var sr = new StringReader(html))
        {
            while (sr.Peek() > -1)
            {
                var line = sr.ReadLine();
                if (line == null) { continue; }

                if (this.IsProcess(line) == true)
                {
                    sb.Append("<p>").Append(line).Append("</p>");
                }
                else
                {
                    sb.Append(line).Append("\n");
                }
            }
        }
        return await ValueTask.FromResult(sb.ToString());
    }
}
