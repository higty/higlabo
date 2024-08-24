using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userteamwork-sendactivitynotification?view=graph-rest-1.0
    /// </summary>
    public partial class UserteamworkSendActivitynotificationParameter : IRestApiParameter
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
    public partial class UserteamworkSendActivitynotificationResponse : RestApiResponse
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
        public async ValueTask<UserteamworkSendActivitynotificationResponse> UserteamworkSendActivitynotificationAsync()
        {
            var p = new UserteamworkSendActivitynotificationParameter();
            return await this.SendAsync<UserteamworkSendActivitynotificationParameter, UserteamworkSendActivitynotificationResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userteamwork-sendactivitynotification?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserteamworkSendActivitynotificationResponse> UserteamworkSendActivitynotificationAsync(CancellationToken cancellationToken)
        {
            var p = new UserteamworkSendActivitynotificationParameter();
            return await this.SendAsync<UserteamworkSendActivitynotificationParameter, UserteamworkSendActivitynotificationResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userteamwork-sendactivitynotification?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserteamworkSendActivitynotificationResponse> UserteamworkSendActivitynotificationAsync(UserteamworkSendActivitynotificationParameter parameter)
        {
            return await this.SendAsync<UserteamworkSendActivitynotificationParameter, UserteamworkSendActivitynotificationResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userteamwork-sendactivitynotification?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserteamworkSendActivitynotificationResponse> UserteamworkSendActivitynotificationAsync(UserteamworkSendActivitynotificationParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserteamworkSendActivitynotificationParameter, UserteamworkSendActivitynotificationResponse>(parameter, cancellationToken);
        }
    }
}
