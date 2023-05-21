using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-list-identityproviders?view=graph-rest-1.0
    /// </summary>
    public partial class IdentitycontainerListIdentityprovidersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_IdentityProviders: return $"/identity/identityProviders";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ClientId,
            ClientSecret,
            DisplayName,
            Id,
            IdentityProviderType,
        }
        public enum ApiPath
        {
            Identity_IdentityProviders,
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
    public partial class IdentitycontainerListIdentityprovidersResponse : RestApiResponse
    {
        public SocialIdentityProvider[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-list-identityproviders?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-list-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitycontainerListIdentityprovidersResponse> IdentitycontainerListIdentityprovidersAsync()
        {
            var p = new IdentitycontainerListIdentityprovidersParameter();
            return await this.SendAsync<IdentitycontainerListIdentityprovidersParameter, IdentitycontainerListIdentityprovidersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-list-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitycontainerListIdentityprovidersResponse> IdentitycontainerListIdentityprovidersAsync(CancellationToken cancellationToken)
        {
            var p = new IdentitycontainerListIdentityprovidersParameter();
            return await this.SendAsync<IdentitycontainerListIdentityprovidersParameter, IdentitycontainerListIdentityprovidersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-list-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitycontainerListIdentityprovidersResponse> IdentitycontainerListIdentityprovidersAsync(IdentitycontainerListIdentityprovidersParameter parameter)
        {
            return await this.SendAsync<IdentitycontainerListIdentityprovidersParameter, IdentitycontainerListIdentityprovidersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-list-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitycontainerListIdentityprovidersResponse> IdentitycontainerListIdentityprovidersAsync(IdentitycontainerListIdentityprovidersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentitycontainerListIdentityprovidersParameter, IdentitycontainerListIdentityprovidersResponse>(parameter, cancellationToken);
        }
    }
}
