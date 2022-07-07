using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentityproviderListAvailableprovidertypesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityProviders_AvailableProviderTypes,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityProviders_AvailableProviderTypes: return $"/identityProviders/availableProviderTypes";
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
    public partial class IdentityproviderListAvailableprovidertypesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityprovider-list-availableprovidertypes?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderListAvailableprovidertypesResponse> IdentityproviderListAvailableprovidertypesAsync()
        {
            var p = new IdentityproviderListAvailableprovidertypesParameter();
            return await this.SendAsync<IdentityproviderListAvailableprovidertypesParameter, IdentityproviderListAvailableprovidertypesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityprovider-list-availableprovidertypes?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderListAvailableprovidertypesResponse> IdentityproviderListAvailableprovidertypesAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityproviderListAvailableprovidertypesParameter();
            return await this.SendAsync<IdentityproviderListAvailableprovidertypesParameter, IdentityproviderListAvailableprovidertypesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityprovider-list-availableprovidertypes?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderListAvailableprovidertypesResponse> IdentityproviderListAvailableprovidertypesAsync(IdentityproviderListAvailableprovidertypesParameter parameter)
        {
            return await this.SendAsync<IdentityproviderListAvailableprovidertypesParameter, IdentityproviderListAvailableprovidertypesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityprovider-list-availableprovidertypes?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderListAvailableprovidertypesResponse> IdentityproviderListAvailableprovidertypesAsync(IdentityproviderListAvailableprovidertypesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityproviderListAvailableprovidertypesParameter, IdentityproviderListAvailableprovidertypesResponse>(parameter, cancellationToken);
        }
    }
}
