using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/browsersitehistory?view=graph-rest-1.0
    /// </summary>
    public partial class BrowserSiteHistory
    {
        public enum BrowserSiteHistoryBrowserSiteCompatibilityMode
        {
            Default,
            InternetExplorer8Enterprise,
            InternetExplorer7Enterprise,
            InternetExplorer11,
            InternetExplorer10,
            InternetExplorer9,
            InternetExplorer8,
            InternetExplorer7,
            InternetExplorer5,
            UnknownFutureValue,
        }
        public enum BrowserSiteHistoryBrowserSiteMergeType
        {
            NoMerge,
            Default,
            UnknownFutureValue,
        }
        public enum BrowserSiteHistoryBrowserSiteTargetEnvironment
        {
            InternetExplorerMode,
            InternetExplorer11,
            MicrosoftEdge,
            Configurable,
            None,
            UnknownFutureValue,
        }

        public bool? AllowRedirect { get; set; }
        public string? Comment { get; set; }
        public BrowserSiteHistoryBrowserSiteCompatibilityMode CompatibilityMode { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public BrowserSiteHistoryBrowserSiteMergeType MergeType { get; set; }
        public DateTimeOffset? PublishedDateTime { get; set; }
        public BrowserSiteHistoryBrowserSiteTargetEnvironment TargetEnvironment { get; set; }
    }
}
