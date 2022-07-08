using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class Oauth2permissiongrantUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Oauth2PermissionGrants_Id: return $"/oauth2PermissionGrants/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Oauth2PermissionGrants_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? Scope { get; set; }
    }
    public partial class Oauth2permissiongrantUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/oauth2permissiongrant-update?view=graph-rest-1.0
        /// </summary>
        public async Task<Oauth2permissiongrantUpdateResponse> Oauth2permissiongrantUpdateAsync()
        {
            var p = new Oauth2permissiongrantUpdateParameter();
            return await this.SendAsync<Oauth2permissiongrantUpdateParameter, Oauth2permissiongrantUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/oauth2permissiongrant-update?view=graph-rest-1.0
        /// </summary>
        public async Task<Oauth2permissiongrantUpdateResponse> Oauth2permissiongrantUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new Oauth2permissiongrantUpdateParameter();
            return await this.SendAsync<Oauth2permissiongrantUpdateParameter, Oauth2permissiongrantUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/oauth2permissiongrant-update?view=graph-rest-1.0
        /// </summary>
        public async Task<Oauth2permissiongrantUpdateResponse> Oauth2permissiongrantUpdateAsync(Oauth2permissiongrantUpdateParameter parameter)
        {
            return await this.SendAsync<Oauth2permissiongrantUpdateParameter, Oauth2permissiongrantUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/oauth2permissiongrant-update?view=graph-rest-1.0
        /// </summary>
        public async Task<Oauth2permissiongrantUpdateResponse> Oauth2permissiongrantUpdateAsync(Oauth2permissiongrantUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<Oauth2permissiongrantUpdateParameter, Oauth2permissiongrantUpdateResponse>(parameter, cancellationToken);
        }
    }
}
