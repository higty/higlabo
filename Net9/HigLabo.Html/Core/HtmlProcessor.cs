using HigLabo.Core;
using HigLabo.Html.Converter;

namespace HigLabo.Html;

public class HtmlProcessorEventArgs : EventArgs
{
    public IHtmlConverter Converter { get; init; }
    public HtmlProcessResult Result { get; init; }

    public HtmlProcessorEventArgs(IHtmlConverter converter, HtmlProcessResult result)
    {
        Converter = converter;
        Result = result;
    }
}
public class HtmlProcessor
{
    public event EventHandler<HtmlProcessorEventArgs>? Processing;
    public event EventHandler<HtmlProcessorEventArgs>? Processed;
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
            this.Processing?.Invoke(this, new HtmlProcessorEventArgs(converter, result));
            result.Html = await converter.ConvertAsync(result.Html);
            this.Processed?.Invoke(this, new HtmlProcessorEventArgs(converter, result));
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