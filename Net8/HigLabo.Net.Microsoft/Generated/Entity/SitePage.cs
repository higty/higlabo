using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/sitepage?view=graph-rest-1.0
    /// </summary>
    public partial class SitePage
    {
        public enum SitePagePageLayoutType
        {
            MicrosoftReserved,
            Article,
            Home,
            UnknownFutureValue,
        }
        public enum SitePagePagePromotionType
        {
            MicrosoftReserved,
            Page,
            NewsPost,
            UnknownFutureValue,
        }

        public ContentTypeInfo? ContentType { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? ETag { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? Name { get; set; }
        public BaseSitePage? PageLayout { get; set; }
        public ItemReference? ParentReference { get; set; }
        public SitePage? PromotionKind { get; set; }
        public PublicationFacet? PublishingState { get; set; }
        public ReActionsFacet? Reactions { get; set; }
        public bool? ShowComments { get; set; }
        public bool? ShowRecommendedPages { get; set; }
        public string? ThumbnailWebUrl { get; set; }
        public string? Title { get; set; }
        public TitleArea? TitleArea { get; set; }
        public string? WebUrl { get; set; }
        public CanvasLayout? CanvasLayout { get; set; }
        public User? CreatedByUser { get; set; }
        public User? LastModifiedByUser { get; set; }
        public WebPart[]? WebParts { get; set; }
    }
}
