using HigLabo.Core;

namespace HigLabo.Bing
{
    public class NewsArticle
    {
        public string Category { get; set; } = "";
        public NewsArticle[]? ClusteredArticles { get; set; } 
        public TextAttribution[]? ContractualRules { get; set; }
        public string DatePublished { get; set; } = "";
        public DateTimeOffset? PublishTime
        {
            get
            {
                return this.DatePublished.ToDateTimeOffset();
            }
        }
        public string Description { get; set; } = "";
        public bool? Headline { get; set; }
        public string Id { get; set; } = "";
        public Image? Image { get; set; } 
        public Thing[]? Mentions { get; set; } 
        public string Name { get; set; } = "";
        public Organization[]? Provider { get; set; } 
        public string Url { get; set; } = "";
        public Video? Video { get; set; } 
    }
}
