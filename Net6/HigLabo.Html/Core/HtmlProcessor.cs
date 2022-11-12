namespace HigLabo.Html
{
    public class HtmlProcessor
    {
        public List<IHtmlConverter> Converters { get; init; } = new();

        public HtmlProcessResult Process(String html)
        {
            var result = new HtmlProcessResult(html);

            foreach (var converter in this.Converters)
            {
                result.Html = converter.Convert(result.Html);
            }
            return result;
        }
    }
}