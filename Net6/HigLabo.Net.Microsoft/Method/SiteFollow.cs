using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SiteFollowParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UserId_FollowedSites_Add,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UserId_FollowedSites_Add: return $"/users/{UserId}/followedSites/add";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string UserId { get; set; }
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
