using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-books-iosvppebook?view=graph-rest-1.0
    /// </summary>
    public partial class IosVppEBook
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public string? Publisher { get; set; }
        public DateTimeOffset? PublishedDateTime { get; set; }
        public MimeContent? LargeCover { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? InformationUrl { get; set; }
        public string? PrivacyInformationUrl { get; set; }
        public Guid? VppTokenId { get; set; }
        public string? AppleId { get; set; }
        public string? VppOrganizationName { get; set; }
        public String[]? Genres { get; set; }
        public string? Language { get; set; }
        public string? Seller { get; set; }
        public Int32? TotalLicenseCount { get; set; }
        public Int32? UsedLicenseCount { get; set; }
    }
}
