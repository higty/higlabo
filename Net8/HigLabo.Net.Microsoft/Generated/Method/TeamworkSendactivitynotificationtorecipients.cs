using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamwork-sendactivitynotificationtorecipients?view=graph-rest-1.0
    /// </summary>
    public partial class TeamworkSendactivitynotificationtorecipientsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teamwork_SendActivityNotificationToRecipients: return $"/teamwork/sendActivityNotificationToRecipients";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teamwork_SendActivityNotificationToRecipients,
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
        public string? TeamsAppId { get; set; }
        public TeamworkNotificationRecipient[]? Recipients { get; set; }
    }
    public partial class TeamworkSendactivitynotificationtorecipientsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamwork-sendactivitynotificationtorecipients?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamwork-sendactivitynotificationtorecipients?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworkSendactivitynotificationtorecipientsResponse> TeamworkSendactivitynotificationtorecipientsAsync()
        {
            var p = new TeamworkSendactivitynotificationtorecipientsParameter();
            return await this.SendAsync<TeamworkSendactivitynotificationtorecipientsParameter, TeamworkSendactivitynotificationtorecipientsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamwork-sendactivitynotificationtorecipients?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworkSendactivitynotificationtorecipientsResponse> TeamworkSendactivitynotificationtorecipientsAsync(CancellationToken cancellationToken)
        {
            var p = new TeamworkSendactivitynotificationtorecipientsParameter();
            return await this.SendAsync<TeamworkSendactivitynotificationtorecipientsParameter, TeamworkSendactivitynotificationtorecipientsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamwork-sendactivitynotificationtorecipients?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworkSendactivitynotificationtorecipientsResponse> TeamworkSendactivitynotificationtorecipientsAsync(TeamworkSendactivitynotificationtorecipientsParameter parameter)
        {
            return await this.SendAsync<TeamworkSendactivitynotificationtorecipientsParameter, TeamworkSendactivitynotificationtorecipientsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamwork-sendactivitynotificationtorecipients?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworkSendactivitynotificationtorecipientsResponse> TeamworkSendactivitynotificationtorecipientsAsync(TeamworkSendactivitynotificationtorecipientsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamworkSendactivitynotificationtorecipientsParameter, TeamworkSendactivitynotificationtorecipientsResponse>(parameter, cancellationToken);
        }
    }
}
