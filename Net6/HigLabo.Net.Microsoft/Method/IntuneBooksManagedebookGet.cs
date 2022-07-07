using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneBooksManagedebookGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_ManagedEBooks_ManagedEBookId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_ManagedEBooks_ManagedEBookId: return $"/deviceAppManagement/managedEBooks/{ManagedEBookId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string ManagedEBookId { get; set; }
    }
    public partial class IntuneBooksManagedebookGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebook-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookGetResponse> IntuneBooksManagedebookGetAsync()
        {
            var p = new IntuneBooksManagedebookGetParameter();
            return await this.SendAsync<IntuneBooksManagedebookGetParameter, IntuneBooksManagedebookGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebook-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookGetResponse> IntuneBooksManagedebookGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneBooksManagedebookGetParameter();
            return await this.SendAsync<IntuneBooksManagedebookGetParameter, IntuneBooksManagedebookGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebook-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookGetResponse> IntuneBooksManagedebookGetAsync(IntuneBooksManagedebookGetParameter parameter)
        {
            return await this.SendAsync<IntuneBooksManagedebookGetParameter, IntuneBooksManagedebookGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebook-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookGetResponse> IntuneBooksManagedebookGetAsync(IntuneBooksManagedebookGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneBooksManagedebookGetParameter, IntuneBooksManagedebookGetResponse>(parameter, cancellationToken);
        }
    }
}
