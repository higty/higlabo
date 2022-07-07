using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserGetmailtipsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_GetMailTips,
            Users_IdOruserPrincipalName_GetMailTips,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_GetMailTips: return $"/me/getMailTips";
                    case ApiPath.Users_IdOruserPrincipalName_GetMailTips: return $"/users/{IdOrUserPrincipalName}/getMailTips";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public String[]? EmailAddresses { get; set; }
        public string? MailTipsOptions { get; set; }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class UserGetmailtipsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/mailtips?view=graph-rest-1.0
        /// </summary>
        public partial class MailTips
        {
            public enum MailTipsRecipientScopeType
            {
                None,
                Internal,
                External,
                ExternalPartner,
                ExternalNonParther,
            }

            public AutomaticRepliesMailTips? AutomaticReplies { get; set; }
            public string? CustomMailTip { get; set; }
            public bool? DeliveryRestricted { get; set; }
            public EmailAddress? EmailAddress { get; set; }
            public MailTipsError? Error { get; set; }
            public Int32? ExternalMemberCount { get; set; }
            public bool? IsModerated { get; set; }
            public bool? MailboxFull { get; set; }
            public Int32? MaxMessageSize { get; set; }
            public MailTipsRecipientScopeType RecipientScope { get; set; }
            public Recipient[]? RecipientSuggestions { get; set; }
            public Int32? TotalMemberCount { get; set; }
        }

        public MailTips[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-getmailtips?view=graph-rest-1.0
        /// </summary>
        public async Task<UserGetmailtipsResponse> UserGetmailtipsAsync()
        {
            var p = new UserGetmailtipsParameter();
            return await this.SendAsync<UserGetmailtipsParameter, UserGetmailtipsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-getmailtips?view=graph-rest-1.0
        /// </summary>
        public async Task<UserGetmailtipsResponse> UserGetmailtipsAsync(CancellationToken cancellationToken)
        {
            var p = new UserGetmailtipsParameter();
            return await this.SendAsync<UserGetmailtipsParameter, UserGetmailtipsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-getmailtips?view=graph-rest-1.0
        /// </summary>
        public async Task<UserGetmailtipsResponse> UserGetmailtipsAsync(UserGetmailtipsParameter parameter)
        {
            return await this.SendAsync<UserGetmailtipsParameter, UserGetmailtipsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-getmailtips?view=graph-rest-1.0
        /// </summary>
        public async Task<UserGetmailtipsResponse> UserGetmailtipsAsync(UserGetmailtipsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserGetmailtipsParameter, UserGetmailtipsResponse>(parameter, cancellationToken);
        }
    }
}
