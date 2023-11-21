using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/browsersitelist?view=graph-rest-1.0
    /// </summary>
    public partial class BrowserSiteList
    {
        public enum BrowserSiteListBrowserSiteListStatus
        {
            Draft,
            Published,
            Pending,
            UnknownFutureValue,
        }

        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public IdentitySet? PublishedBy { get; set; }
        public DateTimeOffset? PublishedDateTime { get; set; }
        public string? Revision { get; set; }
        public BrowserSiteListBrowserSiteListStatus Status { get; set; }
        public BrowserSharedCookie[]? SharedCookies { get; set; }
        public BrowserSite[]? Sites { get; set; }
    }
}
