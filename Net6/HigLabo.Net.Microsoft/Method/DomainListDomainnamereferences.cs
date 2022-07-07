using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DomainListDomainnamereferencesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Domains_Id_DomainNameReferences,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Domains_Id_DomainNameReferences: return $"/domains/{Id}/domainNameReferences";
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
        public string Id { get; set; }
    }
    public partial class DomainListDomainnamereferencesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/directoryobject?view=graph-rest-1.0
        /// </summary>
        public partial class DirectoryObject
        {
            public DateTimeOffset? DeletedDateTime { get; set; }
            public string? Id { get; set; }
        }

        public DirectoryObject[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-list-domainnamereferences?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainListDomainnamereferencesResponse> DomainListDomainnamereferencesAsync()
        {
            var p = new DomainListDomainnamereferencesParameter();
            return await this.SendAsync<DomainListDomainnamereferencesParameter, DomainListDomainnamereferencesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-list-domainnamereferences?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainListDomainnamereferencesResponse> DomainListDomainnamereferencesAsync(CancellationToken cancellationToken)
        {
            var p = new DomainListDomainnamereferencesParameter();
            return await this.SendAsync<DomainListDomainnamereferencesParameter, DomainListDomainnamereferencesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-list-domainnamereferences?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainListDomainnamereferencesResponse> DomainListDomainnamereferencesAsync(DomainListDomainnamereferencesParameter parameter)
        {
            return await this.SendAsync<DomainListDomainnamereferencesParameter, DomainListDomainnamereferencesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-list-domainnamereferences?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainListDomainnamereferencesResponse> DomainListDomainnamereferencesAsync(DomainListDomainnamereferencesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DomainListDomainnamereferencesParameter, DomainListDomainnamereferencesResponse>(parameter, cancellationToken);
        }
    }
}
