using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-delete?view=graph-rest-1.0
    /// </summary>
    public partial class Oauth2permissiongrantDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.OAuth2PermissionGrants_Id: return $"/oAuth2PermissionGrants/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            OAuth2PermissionGrants_Id,
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
    public partial class Oauth2permissiongrantDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Oauth2permissiongrantDeleteResponse> Oauth2permissiongrantDeleteAsync()
        {
            var p = new Oauth2permissiongrantDeleteParameter();
            return await this.SendAsync<Oauth2permissiongrantDeleteParameter, Oauth2permissiongrantDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Oauth2permissiongrantDeleteResponse> Oauth2permissiongrantDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new Oauth2permissiongrantDeleteParameter();
            return await this.SendAsync<Oauth2permissiongrantDeleteParameter, Oauth2permissiongrantDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Oauth2permissiongrantDeleteResponse> Oauth2permissiongrantDeleteAsync(Oauth2permissiongrantDeleteParameter parameter)
        {
            return await this.SendAsync<Oauth2permissiongrantDeleteParameter, Oauth2permissiongrantDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Oauth2permissiongrantDeleteResponse> Oauth2permissiongrantDeleteAsync(Oauth2permissiongrantDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<Oauth2permissiongrantDeleteParameter, Oauth2permissiongrantDeleteResponse>(parameter, cancellationToken);
        }
    }
}
