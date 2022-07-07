using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneBooksIosvppebookCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_ManagedEBooks,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_ManagedEBooks: return $"/deviceAppManagement/managedEBooks";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
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
    public partial class IntuneBooksIosvppebookCreateResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-iosvppebook-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksIosvppebookCreateResponse> IntuneBooksIosvppebookCreateAsync()
        {
            var p = new IntuneBooksIosvppebookCreateParameter();
            return await this.SendAsync<IntuneBooksIosvppebookCreateParameter, IntuneBooksIosvppebookCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-iosvppebook-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksIosvppebookCreateResponse> IntuneBooksIosvppebookCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneBooksIosvppebookCreateParameter();
            return await this.SendAsync<IntuneBooksIosvppebookCreateParameter, IntuneBooksIosvppebookCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-iosvppebook-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksIosvppebookCreateResponse> IntuneBooksIosvppebookCreateAsync(IntuneBooksIosvppebookCreateParameter parameter)
        {
            return await this.SendAsync<IntuneBooksIosvppebookCreateParameter, IntuneBooksIosvppebookCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-iosvppebook-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksIosvppebookCreateResponse> IntuneBooksIosvppebookCreateAsync(IntuneBooksIosvppebookCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneBooksIosvppebookCreateParameter, IntuneBooksIosvppebookCreateResponse>(parameter, cancellationToken);
        }
    }
}
