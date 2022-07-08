using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentityproviderListAvailableproviderTypesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityProviders_AvailableProviderTypes: return $"/identityProviders/availableProviderTypes";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityProviders_AvailableProviderTypes,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    public partial class IdentityproviderListAvailableproviderTypesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityprovider-list-availableprovidertypes?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderListAvailableproviderTypesResponse> IdentityproviderListAvailableproviderTypesAsync()
        {
            var p = new IdentityproviderListAvailableproviderTypesParameter();
            return await this.SendAsync<IdentityproviderListAvailableproviderTypesParameter, IdentityproviderListAvailableproviderTypesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityprovider-list-availableprovidertypes?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderListAvailableproviderTypesResponse> IdentityproviderListAvailableproviderTypesAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityproviderListAvailableproviderTypesParameter();
            return await this.SendAsync<IdentityproviderListAvailableproviderTypesParameter, IdentityproviderListAvailableproviderTypesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityprovider-list-availableprovidertypes?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderListAvailableproviderTypesResponse> IdentityproviderListAvailableproviderTypesAsync(IdentityproviderListAvailableproviderTypesParameter parameter)
        {
            return await this.SendAsync<IdentityproviderListAvailableproviderTypesParameter, IdentityproviderListAvailableproviderTypesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityprovider-list-availableprovidertypes?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderListAvailableproviderTypesResponse> IdentityproviderListAvailableproviderTypesAsync(IdentityproviderListAvailableproviderTypesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityproviderListAvailableproviderTypesParameter, IdentityproviderListAvailableproviderTypesResponse>(parameter, cancellationToken);
        }
    }
}
