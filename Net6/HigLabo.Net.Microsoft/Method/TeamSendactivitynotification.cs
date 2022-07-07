using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TeamSendactivitynotificationParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Teams_TeamId_SendActivityNotification,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_SendActivityNotification: return $"/teams/{TeamId}/sendActivityNotification";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public TeamworkActivityTopic? Topic { get; set; }
        public string? ActivityType { get; set; }
        public Int64? ChainId { get; set; }
        public ItemBody? PreviewText { get; set; }
        public KeyValuePair[]? TemplateParameters { get; set; }
        public TeamworkNotificationRecipient? Recipient { get; set; }
        public string TeamId { get; set; }
    }
    public partial class TeamSendactivitynotificationResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-sendactivitynotification?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamSendactivitynotificationResponse> TeamSendactivitynotificationAsync()
        {
            var p = new TeamSendactivitynotificationParameter();
            return await this.SendAsync<TeamSendactivitynotificationParameter, TeamSendactivitynotificationResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-sendactivitynotification?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamSendactivitynotificationResponse> TeamSendactivitynotificationAsync(CancellationToken cancellationToken)
        {
            var p = new TeamSendactivitynotificationParameter();
            return await this.SendAsync<TeamSendactivitynotificationParameter, TeamSendactivitynotificationResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-sendactivitynotification?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamSendactivitynotificationResponse> TeamSendactivitynotificationAsync(TeamSendactivitynotificationParameter parameter)
        {
            return await this.SendAsync<TeamSendactivitynotificationParameter, TeamSendactivitynotificationResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-sendactivitynotification?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamSendactivitynotificationResponse> TeamSendactivitynotificationAsync(TeamSendactivitynotificationParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamSendactivitynotificationParameter, TeamSendactivitynotificationResponse>(parameter, cancellationToken);
        }
    }
}
