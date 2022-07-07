using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentityproviderbaseGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_IdentityProviders_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_IdentityProviders_Id: return $"/identity/identityProviders/{Id}";
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
    public partial class IdentityproviderbaseGetResponse : RestApiResponse
    {
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? IdentityProviderType { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityproviderbase-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderbaseGetResponse> IdentityproviderbaseGetAsync()
        {
            var p = new IdentityproviderbaseGetParameter();
            return await this.SendAsync<IdentityproviderbaseGetParameter, IdentityproviderbaseGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityproviderbase-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderbaseGetResponse> IdentityproviderbaseGetAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityproviderbaseGetParameter();
            return await this.SendAsync<IdentityproviderbaseGetParameter, IdentityproviderbaseGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityproviderbase-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderbaseGetResponse> IdentityproviderbaseGetAsync(IdentityproviderbaseGetParameter parameter)
        {
            return await this.SendAsync<IdentityproviderbaseGetParameter, IdentityproviderbaseGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityproviderbase-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderbaseGetResponse> IdentityproviderbaseGetAsync(IdentityproviderbaseGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityproviderbaseGetParameter, IdentityproviderbaseGetResponse>(parameter, cancellationToken);
        }
    }
}
