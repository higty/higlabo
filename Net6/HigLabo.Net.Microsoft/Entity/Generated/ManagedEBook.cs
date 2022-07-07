using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-books-managedebook?view=graph-rest-1.0
    /// </summary>
    public partial class ManagedEBook
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
    }
}
