using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentityproviderbaseAvailableprovidertypesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_IdentityProviders_AvailableProviderTypes,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_IdentityProviders_AvailableProviderTypes: return $"/identity/identityProviders/availableProviderTypes";
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
    public partial class IdentityproviderbaseAvailableprovidertypesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityproviderbase-availableprovidertypes?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderbaseAvailableprovidertypesResponse> IdentityproviderbaseAvailableprovidertypesAsync()
        {
            var p = new IdentityproviderbaseAvailableprovidertypesParameter();
            return await this.SendAsync<IdentityproviderbaseAvailableprovidertypesParameter, IdentityproviderbaseAvailableprovidertypesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityproviderbase-availableprovidertypes?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderbaseAvailableprovidertypesResponse> IdentityproviderbaseAvailableprovidertypesAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityproviderbaseAvailableprovidertypesParameter();
            return await this.SendAsync<IdentityproviderbaseAvailableprovidertypesParameter, IdentityproviderbaseAvailableprovidertypesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityproviderbase-availableprovidertypes?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderbaseAvailableprovidertypesResponse> IdentityproviderbaseAvailableprovidertypesAsync(IdentityproviderbaseAvailableprovidertypesParameter parameter)
        {
            return await this.SendAsync<IdentityproviderbaseAvailableprovidertypesParameter, IdentityproviderbaseAvailableprovidertypesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityproviderbase-availableprovidertypes?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderbaseAvailableprovidertypesResponse> IdentityproviderbaseAvailableprovidertypesAsync(IdentityproviderbaseAvailableprovidertypesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityproviderbaseAvailableprovidertypesParameter, IdentityproviderbaseAvailableprovidertypesResponse>(parameter, cancellationToken);
        }
    }
}
