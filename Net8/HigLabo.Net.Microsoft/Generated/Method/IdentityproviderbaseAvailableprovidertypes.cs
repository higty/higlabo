using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityproviderbase-availableprovidertypes?view=graph-rest-1.0
    /// </summary>
    public partial class IdentityproviderbaseAvailableproviderTypesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_IdentityProviders_AvailableProviderTypes: return $"/identity/identityProviders/availableProviderTypes";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_IdentityProviders_AvailableProviderTypes,
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
    public partial class IdentityproviderbaseAvailableproviderTypesResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityproviderbase-availableprovidertypes?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityproviderbase-availableprovidertypes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityproviderbaseAvailableproviderTypesResponse> IdentityproviderbaseAvailableproviderTypesAsync()
        {
            var p = new IdentityproviderbaseAvailableproviderTypesParameter();
            return await this.SendAsync<IdentityproviderbaseAvailableproviderTypesParameter, IdentityproviderbaseAvailableproviderTypesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityproviderbase-availableprovidertypes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityproviderbaseAvailableproviderTypesResponse> IdentityproviderbaseAvailableproviderTypesAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityproviderbaseAvailableproviderTypesParameter();
            return await this.SendAsync<IdentityproviderbaseAvailableproviderTypesParameter, IdentityproviderbaseAvailableproviderTypesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityproviderbase-availableprovidertypes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityproviderbaseAvailableproviderTypesResponse> IdentityproviderbaseAvailableproviderTypesAsync(IdentityproviderbaseAvailableproviderTypesParameter parameter)
        {
            return await this.SendAsync<IdentityproviderbaseAvailableproviderTypesParameter, IdentityproviderbaseAvailableproviderTypesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityproviderbase-availableprovidertypes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityproviderbaseAvailableproviderTypesResponse> IdentityproviderbaseAvailableproviderTypesAsync(IdentityproviderbaseAvailableproviderTypesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityproviderbaseAvailableproviderTypesParameter, IdentityproviderbaseAvailableproviderTypesResponse>(parameter, cancellationToken);
        }
    }
}
