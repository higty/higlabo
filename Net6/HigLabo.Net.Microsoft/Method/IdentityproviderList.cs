using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentityproviderListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityProviders,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityProviders: return $"/identityProviders";
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
    public partial class IdentityproviderListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/identityprovider?view=graph-rest-1.0
        /// </summary>
        public partial class IdentityProvider
        {
            public string? ClientId { get; set; }
            public string? ClientSecret { get; set; }
            public string? Id { get; set; }
            public string? Name { get; set; }
            public string? Type { get; set; }
        }

        public IdentityProvider[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityprovider-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderListResponse> IdentityproviderListAsync()
        {
            var p = new IdentityproviderListParameter();
            return await this.SendAsync<IdentityproviderListParameter, IdentityproviderListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityprovider-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderListResponse> IdentityproviderListAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityproviderListParameter();
            return await this.SendAsync<IdentityproviderListParameter, IdentityproviderListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityprovider-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderListResponse> IdentityproviderListAsync(IdentityproviderListParameter parameter)
        {
            return await this.SendAsync<IdentityproviderListParameter, IdentityproviderListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityprovider-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderListResponse> IdentityproviderListAsync(IdentityproviderListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityproviderListParameter, IdentityproviderListResponse>(parameter, cancellationToken);
        }
    }
}
