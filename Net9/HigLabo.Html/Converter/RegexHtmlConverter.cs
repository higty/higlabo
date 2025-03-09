using System.Text;
using System.Text.RegularExpressions;

namespace HigLabo.Html;

public abstract class RegexHtmlConverter : IHtmlConverter
{
    public async ValueTask<String> ConvertAsync(String html)
    {
        var convertedHtml = html;
        foreach (var rx in GetRegexList())
        {
            convertedHtml = await ReplaceAsync(rx, convertedHtml);
        }
        return convertedHtml;
    }
    private async ValueTask<string> ReplaceAsync(Regex regex, string input)
    {
        var mm = regex.Matches(input);
        if (mm.Count == 0) { return input; }

        var sb = new StringBuilder();
        var lastIndex = 0;

        foreach (Match m in mm)
        {
            sb.Append(input.AsSpan()[lastIndex..m.Index]);
            sb.Append(await ReplaceAsync(m));
            lastIndex = m.Index + m.Length;
        }
        sb.Append(input.AsSpan()[lastIndex..]);

        return sb.ToString();
    }
    protected abstract IEnumerable<Regex> GetRegexList();
    protected abstract ValueTask<String> ReplaceAsync(Match match);
}
