using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SiteDeletePermissionParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string SitesId { get; set; }
            public string PermissionId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SitesId_Permissions_PermissionId: return $"/sites/{SitesId}/permissions/{PermissionId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Sites_SitesId_Permissions_PermissionId,
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
    public partial class SiteDeletePermissionResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-delete-permission?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteDeletePermissionResponse> SiteDeletePermissionAsync()
        {
            var p = new SiteDeletePermissionParameter();
            return await this.SendAsync<SiteDeletePermissionParameter, SiteDeletePermissionResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-delete-permission?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteDeletePermissionResponse> SiteDeletePermissionAsync(CancellationToken cancellationToken)
        {
            var p = new SiteDeletePermissionParameter();
            return await this.SendAsync<SiteDeletePermissionParameter, SiteDeletePermissionResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-delete-permission?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteDeletePermissionResponse> SiteDeletePermissionAsync(SiteDeletePermissionParameter parameter)
        {
            return await this.SendAsync<SiteDeletePermissionParameter, SiteDeletePermissionResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-delete-permission?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteDeletePermissionResponse> SiteDeletePermissionAsync(SiteDeletePermissionParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SiteDeletePermissionParameter, SiteDeletePermissionResponse>(parameter, cancellationToken);
        }
    }
}
