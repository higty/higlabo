using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SiteFollowParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Users_UserId_FollowedSites_Add: return $"/users/{UserId}/followedSites/add";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Users_UserId_FollowedSites_Add,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
    }
    public partial class SiteFollowResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-follow?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteFollowResponse> SiteFollowAsync()
        {
            var p = new SiteFollowParameter();
            return await this.SendAsync<SiteFollowParameter, SiteFollowResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-follow?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteFollowResponse> SiteFollowAsync(CancellationToken cancellationToken)
        {
            var p = new SiteFollowParameter();
            return await this.SendAsync<SiteFollowParameter, SiteFollowResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-follow?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteFollowResponse> SiteFollowAsync(SiteFollowParameter parameter)
        {
            return await this.SendAsync<SiteFollowParameter, SiteFollowResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-follow?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteFollowResponse> SiteFollowAsync(SiteFollowParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SiteFollowParameter, SiteFollowResponse>(parameter, cancellationToken);
        }
    }
}
