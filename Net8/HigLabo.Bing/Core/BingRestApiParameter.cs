using HigLabo.Core;
using HigLabo.RestApi;
using System.Text;

namespace HigLabo.Bing
{
    public enum SafeSearchType
    {
        Off,
        Moderate,
        Strict,
    }
    public enum TextFormat
    {
        Raw,
        Html,
    }
    /// <summary>
    /// See this page.
    /// https://learn.microsoft.com/en-us/bing/search-apis/bing-web-search/reference/query-parameters
    /// </summary>
    public abstract class BingRestApiParameter : IRestApiParameter, IQueryParameter
    {
        public static BingRestApiParameterDefaultSettings Default { get; } = new BingRestApiParameterDefaultSettings();
        public static readonly object EmptyParameter = new object();

        public abstract string HttpMethod { get; }

        public string UserAgent { get; set; } = "";
        public string MSEdgeClientId { get; set; } = "";
        public string MSEdgeClientIP { get; set; } = "";
        public string SearchLocation { get; set; } = "";    

        public string Q { get; set; } = "";
        public BingMarket Market { get; set; } = Default.Market;
        public int? Offset { get; set; }
        public int ResultCount { get; set; } = 10;
        public string ResponseFilter { get; set; } = "";
        public string Category { get; set; } = "";
        public string Promote { get; set; } = "";
        public Freshness? Freshness { get; set; }
        public int? AnswerCount { get; set; }
        public SafeSearchType? SafeSearch { get; set; }
        public string SetLang { get; set; } = "";
        public bool TextDecorations { get; set; } = false;
        public TextFormat TextFormat { get; set; } = TextFormat.Raw;

        public abstract string GetApiPath();
        public virtual string GetQueryString()
        {
            var sb = new StringBuilder(128);
            sb.Append($"q={Uri.EscapeDataString(this.Q)}&mkt={this.Market.GetMarketCode()}&count={this.ResultCount}&textFormat={this.TextFormat}");
            if (this.Offset.HasValue)
            {
                sb.Append($"&offset={this.Offset}");
            }
            if (this.ResponseFilter.HasValue())
            {
                sb.Append($"&responseFilter={this.ResponseFilter}");
            }
            if (this.Category.HasValue())
            {
                sb.Append($"&category={this.Category}");
            }
            if (this.Freshness.HasValue)
            {
                sb.Append($"&freshness={this.Freshness.ToStringFromEnum()}");            
            }
            if (this.AnswerCount.HasValue)
            {
                sb.Append($"&answerCount={this.AnswerCount}");
            }
            if (this.SafeSearch.HasValue)
            {
                sb.Append($"&safeSearch={this.SafeSearch}");
            }
            if (this.SetLang.HasValue())
            {
                sb.Append($"&setLang={this.SetLang}");
            }
            if (this.TextDecorations)
            {
                sb.Append($"&textDecorations={this.TextDecorations}");
            }
            if (this.Promote.HasValue())
            {
                sb.Append($"&promote={this.Promote}");
            }

            return sb.ToString();
        }
        public object? GetRequestBody()
        {
            return null;
        }
    }
}
