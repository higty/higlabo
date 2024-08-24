using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprovider-get?view=graph-rest-1.0
    /// </summary>
    public partial class IdentityProviderGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityProviders_Id: return $"/identityProviders/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityProviders_Id,
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
    public partial class IdentityProviderGetResponse : RestApiResponse
    {
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprovider-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityprovider-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityProviderGetResponse> IdentityProviderGetAsync()
        {
            var p = new IdentityProviderGetParameter();
            return await this.SendAsync<IdentityProviderGetParameter, IdentityProviderGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityprovider-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityProviderGetResponse> IdentityProviderGetAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityProviderGetParameter();
            return await this.SendAsync<IdentityProviderGetParameter, IdentityProviderGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityprovider-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityProviderGetResponse> IdentityProviderGetAsync(IdentityProviderGetParameter parameter)
        {
            return await this.SendAsync<IdentityProviderGetParameter, IdentityProviderGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityprovider-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityProviderGetResponse> IdentityProviderGetAsync(IdentityProviderGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityProviderGetParameter, IdentityProviderGetResponse>(parameter, cancellationToken);
        }
    }
}
