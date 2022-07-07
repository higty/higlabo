using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentitysecuritydefaultsenforcementpolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_IdentitySecurityDefaultsEnforcementPolicy,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_IdentitySecurityDefaultsEnforcementPolicy: return $"/policies/identitySecurityDefaultsEnforcementPolicy";
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
    public partial class IdentitysecuritydefaultsenforcementpolicyGetResponse : RestApiResponse
    {
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsEnabled { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identitysecuritydefaultsenforcementpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitysecuritydefaultsenforcementpolicyGetResponse> IdentitysecuritydefaultsenforcementpolicyGetAsync()
        {
            var p = new IdentitysecuritydefaultsenforcementpolicyGetParameter();
            return await this.SendAsync<IdentitysecuritydefaultsenforcementpolicyGetParameter, IdentitysecuritydefaultsenforcementpolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identitysecuritydefaultsenforcementpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitysecuritydefaultsenforcementpolicyGetResponse> IdentitysecuritydefaultsenforcementpolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new IdentitysecuritydefaultsenforcementpolicyGetParameter();
            return await this.SendAsync<IdentitysecuritydefaultsenforcementpolicyGetParameter, IdentitysecuritydefaultsenforcementpolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identitysecuritydefaultsenforcementpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitysecuritydefaultsenforcementpolicyGetResponse> IdentitysecuritydefaultsenforcementpolicyGetAsync(IdentitysecuritydefaultsenforcementpolicyGetParameter parameter)
        {
            return await this.SendAsync<IdentitysecuritydefaultsenforcementpolicyGetParameter, IdentitysecuritydefaultsenforcementpolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identitysecuritydefaultsenforcementpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitysecuritydefaultsenforcementpolicyGetResponse> IdentitysecuritydefaultsenforcementpolicyGetAsync(IdentitysecuritydefaultsenforcementpolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentitysecuritydefaultsenforcementpolicyGetParameter, IdentitysecuritydefaultsenforcementpolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
