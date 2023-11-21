using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HigLabo.Html
{
    public abstract class RegexHtmlConverter : IHtmlConverter
    {
        public async ValueTask<String> ConvertAsync(String html)
        {
            var convertedHtml = html;
            foreach (var match in GetRegexList())
            {
                convertedHtml = match.Replace(convertedHtml, m => Convert(m));
            }
            return await ValueTask.FromResult(convertedHtml);
        }
        protected abstract IEnumerable<Regex> GetRegexList();
        protected abstract String Convert(Match match);
    }
}
