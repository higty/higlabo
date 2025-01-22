using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/team-sendactivitynotification?view=graph-rest-1.0
/// </summary>
public partial class TeamSendActivitynotificationParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? TeamId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Teams_TeamId_SendActivityNotification: return $"/teams/{TeamId}/sendActivityNotification";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Teams_TeamId_SendActivityNotification,
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
    public TeamworkActivityTopic? Topic { get; set; }
    public string? ActivityType { get; set; }
    public Int64? ChainId { get; set; }
    public ItemBody? PreviewText { get; set; }
    public KeyValuePair[]? TemplateParameters { get; set; }
    public TeamworkNotificationRecipient? Recipient { get; set; }
}
public partial class TeamSendActivitynotificationResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/team-sendactivitynotification?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-sendactivitynotification?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamSendActivitynotificationResponse> TeamSendActivitynotificationAsync()
    {
        var p = new TeamSendActivitynotificationParameter();
        return await this.SendAsync<TeamSendActivitynotificationParameter, TeamSendActivitynotificationResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-sendactivitynotification?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamSendActivitynotificationResponse> TeamSendActivitynotificationAsync(CancellationToken cancellationToken)
    {
        var p = new TeamSendActivitynotificationParameter();
        return await this.SendAsync<TeamSendActivitynotificationParameter, TeamSendActivitynotificationResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-sendactivitynotification?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamSendActivitynotificationResponse> TeamSendActivitynotificationAsync(TeamSendActivitynotificationParameter parameter)
    {
        return await this.SendAsync<TeamSendActivitynotificationParameter, TeamSendActivitynotificationResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-sendactivitynotification?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamSendActivitynotificationResponse> TeamSendActivitynotificationAsync(TeamSendActivitynotificationParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TeamSendActivitynotificationParameter, TeamSendActivitynotificationResponse>(parameter, cancellationToken);
    }
}
