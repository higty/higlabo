using HigLabo.Core;
using HigLabo.Html.Converter;

namespace HigLabo.Html;

public class HtmlProcessor
{
    public List<IHtmlConverter> Converters { get; init; } = new();

    public async ValueTask<HtmlProcessResult> ProcessAsync(String html)
    {
        var result = new HtmlProcessResult(html);
        if (html.IsNullOrEmpty())
        {
            result.Html = "";
            return result;
        }
        
        foreach (var converter in this.Converters)
        {
            result.Html = await converter.ConvertAsync(result.Html);
            if (converter is IUrlConverter cv)
            {
                result.UrlList.AddRange(cv.UrlList);
            }
        }
        return result;
    }
    public async ValueTask<string> GetHtmlAsync(string html)
    {
        var rs = await this.ProcessAsync(html);
        return rs.Html;
    }
}