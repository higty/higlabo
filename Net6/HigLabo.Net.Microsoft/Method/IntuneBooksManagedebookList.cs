using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneBooksManagedebookListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class IntuneBooksManagedebookListResponse : RestApiResponse
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

        public ManagedEBook[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebook-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookListResponse> IntuneBooksManagedebookListAsync()
        {
            var p = new IntuneBooksManagedebookListParameter();
            return await this.SendAsync<IntuneBooksManagedebookListParameter, IntuneBooksManagedebookListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebook-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookListResponse> IntuneBooksManagedebookListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneBooksManagedebookListParameter();
            return await this.SendAsync<IntuneBooksManagedebookListParameter, IntuneBooksManagedebookListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebook-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookListResponse> IntuneBooksManagedebookListAsync(IntuneBooksManagedebookListParameter parameter)
        {
            return await this.SendAsync<IntuneBooksManagedebookListParameter, IntuneBooksManagedebookListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebook-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookListResponse> IntuneBooksManagedebookListAsync(IntuneBooksManagedebookListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneBooksManagedebookListParameter, IntuneBooksManagedebookListResponse>(parameter, cancellationToken);
        }
    }
}
