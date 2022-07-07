using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserteamworkSendactivitynotificationParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UserIdOrUserPrincipalName_Teamwork_SendActivityNotification,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UserIdOrUserPrincipalName_Teamwork_SendActivityNotification: return $"/users/{UserIdOrUserPrincipalName}/teamwork/sendActivityNotification";
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
        public string UserIdOrUserPrincipalName { get; set; }
    }
    public partial class UserteamworkSendactivitynotificationResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userteamwork-sendactivitynotification?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkSendactivitynotificationResponse> UserteamworkSendactivitynotificationAsync()
        {
            var p = new UserteamworkSendactivitynotificationParameter();
            return await this.SendAsync<UserteamworkSendactivitynotificationParameter, UserteamworkSendactivitynotificationResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userteamwork-sendactivitynotification?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkSendactivitynotificationResponse> UserteamworkSendactivitynotificationAsync(CancellationToken cancellationToken)
        {
            var p = new UserteamworkSendactivitynotificationParameter();
            return await this.SendAsync<UserteamworkSendactivitynotificationParameter, UserteamworkSendactivitynotificationResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userteamwork-sendactivitynotification?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkSendactivitynotificationResponse> UserteamworkSendactivitynotificationAsync(UserteamworkSendactivitynotificationParameter parameter)
        {
            return await this.SendAsync<UserteamworkSendactivitynotificationParameter, UserteamworkSendactivitynotificationResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userteamwork-sendactivitynotification?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkSendactivitynotificationResponse> UserteamworkSendactivitynotificationAsync(UserteamworkSendactivitynotificationParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserteamworkSendactivitynotificationParameter, UserteamworkSendactivitynotificationResponse>(parameter, cancellationToken);
        }
    }
}
