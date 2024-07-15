using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using HigLabo.Core;
using HigLabo.Html;

namespace HigLabo.Html
{
    public class SourceCodeHtmlConverter : IHtmlConverter
    {
        public static class RegexList
        {
            public static Regex SourceCode_Start = new Regex("^```(?<Language>[a-z]*)", RegexOptions.IgnoreCase);
            public static Regex SourceCode_End = new Regex("^```", RegexOptions.IgnoreCase);
        }
        private enum ParseContextState
        {
            Ready,
            Processing,
        }
        private class ParseContext
        {
            public ParseContextState State { get; set; } = ParseContextState.Ready;
            public string Language { get; set; } = "";
            public StringBuilder Text { get; init; } = new();
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
                        var m = RegexList.SourceCode_Start.Match(line.TrimStart());
                        if (m.Success)
                        {
                            context.State = ParseContextState.Processing;
                            context.Language = m.Groups["Language"].Value;
                            if (sb.Length > 0)
                            {
                                sb.Remove(sb.Length - 1, 1);
                            }
                        }
                        else
                        {
                            sb.Append(line).Append("\r");
                        }
                    }
                    else
                    {
                        var m = RegexList.SourceCode_End.Match(line.TrimStart());
                        if (m.Success)
                        {
                            sb.Append(CreateSourceCodePanel(context.Text.ToString(), context.Language));
                            context.State = ParseContextState.Ready;
                            context.Language = "";
                            context.Text.Clear();
                        }
                        else
                        {
                            switch (context.State)
                            {
                                case ParseContextState.Ready:
                                    sb.Append(line).Append("\n");
                                    break;
                                case ParseContextState.Processing:
                                    context.Text.Append(line).Append("\n");
                                    break;
                                default: throw SwitchStatementNotImplementException.Create(context.State);
                            }
                        }
                    }
                }
            }
            return await ValueTask.FromResult(sb.ToString().TrimEnd());
        }
        private String CreateSourceCodePanel(String sourceCode, String language)
        {
            var sb = new StringBuilder();

            sb.Append("<div class=\"source-code\">");
            sb.Append("<pre class=\"line-numbers\">");

            if (language.IsNullOrEmpty())
            {
                language = "plaintext";
            }
            sb.AppendFormat("<code class=\"language-{1}\">{0}</code>", sourceCode, language.ToLower());
            sb.Append("</pre>");
            sb.AppendLine("</div>");

            return sb.ToString();
        }
    }
}
