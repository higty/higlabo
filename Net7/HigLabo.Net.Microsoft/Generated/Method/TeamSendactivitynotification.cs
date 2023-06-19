using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-sendactivitynotification?view=graph-rest-1.0
    /// </summary>
    public partial class TeamSendactivitynotificationParameter : IRestApiParameter
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
    public partial class TeamSendactivitynotificationResponse : RestApiResponse
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
        public async ValueTask<TeamSendactivitynotificationResponse> TeamSendactivitynotificationAsync()
        {
            var p = new TeamSendactivitynotificationParameter();
            return await this.SendAsync<TeamSendactivitynotificationParameter, TeamSendactivitynotificationResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-sendactivitynotification?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamSendactivitynotificationResponse> TeamSendactivitynotificationAsync(CancellationToken cancellationToken)
        {
            var p = new TeamSendactivitynotificationParameter();
            return await this.SendAsync<TeamSendactivitynotificationParameter, TeamSendactivitynotificationResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-sendactivitynotification?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamSendactivitynotificationResponse> TeamSendactivitynotificationAsync(TeamSendactivitynotificationParameter parameter)
        {
            return await this.SendAsync<TeamSendactivitynotificationParameter, TeamSendactivitynotificationResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-sendactivitynotification?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamSendactivitynotificationResponse> TeamSendactivitynotificationAsync(TeamSendactivitynotificationParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamSendactivitynotificationParameter, TeamSendactivitynotificationResponse>(parameter, cancellationToken);
        }
    }
}
