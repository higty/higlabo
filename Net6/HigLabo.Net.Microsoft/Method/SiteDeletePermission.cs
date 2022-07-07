using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SiteDeletePermissionParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Sites_SitesId_Permissions_PermissionId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Sites_SitesId_Permissions_PermissionId: return $"/sites/{SitesId}/permissions/{PermissionId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string SitesId { get; set; }
        public string PermissionId { get; set; }
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
