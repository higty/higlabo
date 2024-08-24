using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-getmailtips?view=graph-rest-1.0
    /// </summary>
    public partial class UserGetmailtipsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_GetMailTips: return $"/me/getMailTips";
                    case ApiPath.Users_IdOruserPrincipalName_GetMailTips: return $"/users/{IdOrUserPrincipalName}/getMailTips";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_GetMailTips,
            Users_IdOruserPrincipalName_GetMailTips,
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
        public String[]? EmailAddresses { get; set; }
        public string? MailTipsOptions { get; set; }
    }
    public partial class UserGetmailtipsResponse : RestApiResponse<MailTips>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-getmailtips?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-getmailtips?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserGetmailtipsResponse> UserGetmailtipsAsync()
        {
            var p = new UserGetmailtipsParameter();
            return await this.SendAsync<UserGetmailtipsParameter, UserGetmailtipsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-getmailtips?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserGetmailtipsResponse> UserGetmailtipsAsync(CancellationToken cancellationToken)
        {
            var p = new UserGetmailtipsParameter();
            return await this.SendAsync<UserGetmailtipsParameter, UserGetmailtipsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-getmailtips?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserGetmailtipsResponse> UserGetmailtipsAsync(UserGetmailtipsParameter parameter)
        {
            return await this.SendAsync<UserGetmailtipsParameter, UserGetmailtipsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-getmailtips?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserGetmailtipsResponse> UserGetmailtipsAsync(UserGetmailtipsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserGetmailtipsParameter, UserGetmailtipsResponse>(parameter, cancellationToken);
        }
    }
}
