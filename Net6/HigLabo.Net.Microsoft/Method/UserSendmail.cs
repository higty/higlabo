using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserSendmailParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_SendMail,
            Users_IdOrUserPrincipalName_SendMail,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_SendMail: return $"/me/sendMail";
                    case ApiPath.Users_IdOrUserPrincipalName_SendMail: return $"/users/{IdOrUserPrincipalName}/sendMail";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public Message? Message { get; set; }
        public bool? SaveToSentItems { get; set; }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class UserSendmailResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-sendmail?view=graph-rest-1.0
        /// </summary>
        public async Task<UserSendmailResponse> UserSendmailAsync()
        {
            var p = new UserSendmailParameter();
            return await this.SendAsync<UserSendmailParameter, UserSendmailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-sendmail?view=graph-rest-1.0
        /// </summary>
        public async Task<UserSendmailResponse> UserSendmailAsync(CancellationToken cancellationToken)
        {
            var p = new UserSendmailParameter();
            return await this.SendAsync<UserSendmailParameter, UserSendmailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-sendmail?view=graph-rest-1.0
        /// </summary>
        public async Task<UserSendmailResponse> UserSendmailAsync(UserSendmailParameter parameter)
        {
            return await this.SendAsync<UserSendmailParameter, UserSendmailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-sendmail?view=graph-rest-1.0
        /// </summary>
        public async Task<UserSendmailResponse> UserSendmailAsync(UserSendmailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserSendmailParameter, UserSendmailResponse>(parameter, cancellationToken);
        }
    }
}
