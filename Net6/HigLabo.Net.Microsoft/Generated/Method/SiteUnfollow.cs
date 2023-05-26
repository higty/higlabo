using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-unfollow?view=graph-rest-1.0
    /// </summary>
    public partial class SiteUnfollowParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Users_UserId_FollowedSites_Remove: return $"/users/{UserId}/followedSites/remove";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Users_UserId_FollowedSites_Remove,
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
    public partial class SiteUnfollowResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-unfollow?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-unfollow?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteUnfollowResponse> SiteUnfollowAsync()
        {
            var p = new SiteUnfollowParameter();
            return await this.SendAsync<SiteUnfollowParameter, SiteUnfollowResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-unfollow?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteUnfollowResponse> SiteUnfollowAsync(CancellationToken cancellationToken)
        {
            var p = new SiteUnfollowParameter();
            return await this.SendAsync<SiteUnfollowParameter, SiteUnfollowResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-unfollow?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteUnfollowResponse> SiteUnfollowAsync(SiteUnfollowParameter parameter)
        {
            return await this.SendAsync<SiteUnfollowParameter, SiteUnfollowResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-unfollow?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteUnfollowResponse> SiteUnfollowAsync(SiteUnfollowParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SiteUnfollowParameter, SiteUnfollowResponse>(parameter, cancellationToken);
        }
    }
}
