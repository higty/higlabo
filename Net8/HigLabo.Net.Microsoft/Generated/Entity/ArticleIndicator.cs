using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-articleindicator?view=graph-rest-1.0
    /// </summary>
    public partial class ArticleIndicator
    {
        public enum ArticleIndicatorSecurityIndicatorSource
        {
            Microsoft,
            Osint,
            Public,
            UnknownFutureValue,
        }

        public string? Id { get; set; }
        public ArticleIndicatorSecurityIndicatorSource Source { get; set; }
        public Artifact? Artifact { get; set; }
    }
}
