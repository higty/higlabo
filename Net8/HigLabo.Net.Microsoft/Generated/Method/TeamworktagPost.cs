using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamworktag-post?view=graph-rest-1.0
    /// </summary>
    public partial class TeamworktagPostParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Tags: return $"/teams/{TeamId}/tags";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_Tags,
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
        public string? DisplayName { get; set; }
        public TeamworkTagMember[]? Members { get; set; }
        public string? Description { get; set; }
        public string? Id { get; set; }
        public Int32? MemberCount { get; set; }
        public TeamworkTag? TagType { get; set; }
        public string? TeamId { get; set; }
    }
    public partial class TeamworktagPostResponse : RestApiResponse
    {
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public Int32? MemberCount { get; set; }
        public TeamworkTag? TagType { get; set; }
        public string? TeamId { get; set; }
        public TeamworkTagMember[]? Members { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamworktag-post?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktag-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworktagPostResponse> TeamworktagPostAsync()
        {
            var p = new TeamworktagPostParameter();
            return await this.SendAsync<TeamworktagPostParameter, TeamworktagPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktag-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworktagPostResponse> TeamworktagPostAsync(CancellationToken cancellationToken)
        {
            var p = new TeamworktagPostParameter();
            return await this.SendAsync<TeamworktagPostParameter, TeamworktagPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktag-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworktagPostResponse> TeamworktagPostAsync(TeamworktagPostParameter parameter)
        {
            return await this.SendAsync<TeamworktagPostParameter, TeamworktagPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktag-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworktagPostResponse> TeamworktagPostAsync(TeamworktagPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamworktagPostParameter, TeamworktagPostResponse>(parameter, cancellationToken);
        }
    }
}
