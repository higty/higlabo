using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-delete?view=graph-rest-1.0
    /// </summary>
    public partial class Oauth2PermissionGrantDeleteParameter : IRestApiParameter
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
    public partial class Oauth2PermissionGrantDeleteResponse : RestApiResponse
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
        public async ValueTask<Oauth2PermissionGrantDeleteResponse> Oauth2PermissionGrantDeleteAsync()
        {
            var p = new Oauth2PermissionGrantDeleteParameter();
            return await this.SendAsync<Oauth2PermissionGrantDeleteParameter, Oauth2PermissionGrantDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Oauth2PermissionGrantDeleteResponse> Oauth2PermissionGrantDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new Oauth2PermissionGrantDeleteParameter();
            return await this.SendAsync<Oauth2PermissionGrantDeleteParameter, Oauth2PermissionGrantDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Oauth2PermissionGrantDeleteResponse> Oauth2PermissionGrantDeleteAsync(Oauth2PermissionGrantDeleteParameter parameter)
        {
            return await this.SendAsync<Oauth2PermissionGrantDeleteParameter, Oauth2PermissionGrantDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Oauth2PermissionGrantDeleteResponse> Oauth2PermissionGrantDeleteAsync(Oauth2PermissionGrantDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<Oauth2PermissionGrantDeleteParameter, Oauth2PermissionGrantDeleteResponse>(parameter, cancellationToken);
        }
    }
}
