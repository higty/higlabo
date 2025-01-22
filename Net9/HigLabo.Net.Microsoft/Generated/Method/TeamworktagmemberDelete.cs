using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-delete?view=graph-rest-1.0
/// </summary>
public partial class TeamworktagMemberDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? TeamId { get; set; }
        public string? TeamworkTagId { get; set; }
        public string? TeamworkTagMemberId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Teams_TeamId_Tags_TeamworkTagId_Members_TeamworkTagMemberId: return $"/teams/{TeamId}/tags/{TeamworkTagId}/members/{TeamworkTagMemberId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Teams_TeamId_Tags_TeamworkTagId_Members_TeamworkTagMemberId,
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
public partial class TeamworktagMemberDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamworktagMemberDeleteResponse> TeamworktagMemberDeleteAsync()
    {
        var p = new TeamworktagMemberDeleteParameter();
        return await this.SendAsync<TeamworktagMemberDeleteParameter, TeamworktagMemberDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamworktagMemberDeleteResponse> TeamworktagMemberDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new TeamworktagMemberDeleteParameter();
        return await this.SendAsync<TeamworktagMemberDeleteParameter, TeamworktagMemberDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamworktagMemberDeleteResponse> TeamworktagMemberDeleteAsync(TeamworktagMemberDeleteParameter parameter)
    {
        return await this.SendAsync<TeamworktagMemberDeleteParameter, TeamworktagMemberDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamworktagMemberDeleteResponse> TeamworktagMemberDeleteAsync(TeamworktagMemberDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TeamworktagMemberDeleteParameter, TeamworktagMemberDeleteResponse>(parameter, cancellationToken);
    }
}
