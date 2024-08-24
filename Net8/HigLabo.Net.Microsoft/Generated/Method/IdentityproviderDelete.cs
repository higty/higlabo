using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprovider-delete?view=graph-rest-1.0
    /// </summary>
    public partial class IdentityProviderDeleteParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class IdentityProviderDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprovider-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityprovider-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityProviderDeleteResponse> IdentityProviderDeleteAsync()
        {
            var p = new IdentityProviderDeleteParameter();
            return await this.SendAsync<IdentityProviderDeleteParameter, IdentityProviderDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityprovider-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityProviderDeleteResponse> IdentityProviderDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityProviderDeleteParameter();
            return await this.SendAsync<IdentityProviderDeleteParameter, IdentityProviderDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityprovider-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityProviderDeleteResponse> IdentityProviderDeleteAsync(IdentityProviderDeleteParameter parameter)
        {
            return await this.SendAsync<IdentityProviderDeleteParameter, IdentityProviderDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityprovider-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityProviderDeleteResponse> IdentityProviderDeleteAsync(IdentityProviderDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityProviderDeleteParameter, IdentityProviderDeleteResponse>(parameter, cancellationToken);
        }
    }
}
