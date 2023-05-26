using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userteamwork-sendactivitynotification?view=graph-rest-1.0
    /// </summary>
    public partial class UserteamworkSendactivitynotificationParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? UserIdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Users_UserIdOrUserPrincipalName_Teamwork_SendActivityNotification: return $"/users/{UserIdOrUserPrincipalName}/teamwork/sendActivityNotification";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Users_UserIdOrUserPrincipalName_Teamwork_SendActivityNotification,
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
    }
    public partial class UserteamworkSendactivitynotificationResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userteamwork-sendactivitynotification?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userteamwork-sendactivitynotification?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkSendactivitynotificationResponse> UserteamworkSendactivitynotificationAsync()
        {
            var p = new UserteamworkSendactivitynotificationParameter();
            return await this.SendAsync<UserteamworkSendactivitynotificationParameter, UserteamworkSendactivitynotificationResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userteamwork-sendactivitynotification?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkSendactivitynotificationResponse> UserteamworkSendactivitynotificationAsync(CancellationToken cancellationToken)
        {
            var p = new UserteamworkSendactivitynotificationParameter();
            return await this.SendAsync<UserteamworkSendactivitynotificationParameter, UserteamworkSendactivitynotificationResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userteamwork-sendactivitynotification?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkSendactivitynotificationResponse> UserteamworkSendactivitynotificationAsync(UserteamworkSendactivitynotificationParameter parameter)
        {
            return await this.SendAsync<UserteamworkSendactivitynotificationParameter, UserteamworkSendactivitynotificationResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userteamwork-sendactivitynotification?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkSendactivitynotificationResponse> UserteamworkSendactivitynotificationAsync(UserteamworkSendactivitynotificationParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserteamworkSendactivitynotificationParameter, UserteamworkSendactivitynotificationResponse>(parameter, cancellationToken);
        }
    }
}
