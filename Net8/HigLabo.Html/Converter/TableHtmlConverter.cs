using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Html;

public class TableHtmlConverter : IHtmlConverter
{
    private enum ParseContextState
    {
        Ready,
        Processing,
    }
    private class ParseContext
    {
        public ParseContextState State { get; set; } = ParseContextState.Ready;
        public List<string[]> Rows { get; init; } = new();
    }
    public async ValueTask<String> ConvertAsync(String html)
    {
        var sb = new StringBuilder();
        var context = new ParseContext();

        using (var sr = new StringReader(html))
        {
            while (sr.Peek() > -1)
            {
                var line = sr.ReadLine();
                if (line == null) { continue; }

                if (context.State == ParseContextState.Ready)
                {
                    if (line.StartsWith("|") && line.EndsWith("|"))
                    {
                        context.State = ParseContextState.Processing;
                        context.Rows.Add(line.Trim('|').Split('|'));
                        if (sb.Length > 0)
                        {
                            sb.Remove(sb.Length - 1, 1);
                        }
                    }
                    else
                    {
                        sb.Append(line).Append("\n");
                    }
                }
                else
                {
                    if (line.StartsWith("|") && line.EndsWith("|"))
                    {
                        context.Rows.Add(line.Trim('|').Split('|'));
                    }
                    else
                    {
                        sb.Append(CreateTable(context));
                        sb.Append(line).Append("\n");
                        context.State = ParseContextState.Ready;
                    }
                }
            }
        }
        if (context.State == ParseContextState.Processing)
        {
            sb.Append(CreateTable(context));
        }
        return await ValueTask.FromResult(sb.ToString().TrimEnd());
    }
    private String CreateTable(ParseContext context)
    {
        var sb = new StringBuilder();

        sb.Append("<table class=\"record-list-table\">");
        foreach (var row in context.Rows)
        {
            sb.Append("<tr>");
            foreach (var column in row)
            {
                sb.Append("<td>").Append(column).Append("</td>");
            }
            sb.Append("</tr>");
        }
        sb.Append("</table>");

        return sb.ToString();
    }
}
