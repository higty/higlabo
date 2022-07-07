using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MessageruleDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_MailFolders_Inbox_MessageRules_Id,
            Users_IdOrUserPrincipalName_MailFolders_Inbox_MessageRules_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_MailFolders_Inbox_MessageRules_Id: return $"/me/mailFolders/inbox/messageRules/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Inbox_MessageRules_Id: return $"/users/{IdOrUserPrincipalName}/mailFolders/inbox/messageRules/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class MessageruleDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/messagerule-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageruleDeleteResponse> MessageruleDeleteAsync()
        {
            var p = new MessageruleDeleteParameter();
            return await this.SendAsync<MessageruleDeleteParameter, MessageruleDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/messagerule-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageruleDeleteResponse> MessageruleDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new MessageruleDeleteParameter();
            return await this.SendAsync<MessageruleDeleteParameter, MessageruleDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/messagerule-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageruleDeleteResponse> MessageruleDeleteAsync(MessageruleDeleteParameter parameter)
        {
            return await this.SendAsync<MessageruleDeleteParameter, MessageruleDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/messagerule-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageruleDeleteResponse> MessageruleDeleteAsync(MessageruleDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MessageruleDeleteParameter, MessageruleDeleteResponse>(parameter, cancellationToken);
        }
    }
}
