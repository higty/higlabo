using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MessageruleUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }
            public string IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_MailFolders_Inbox_MessageRules_Id: return $"/me/mailFolders/inbox/messageRules/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Inbox_MessageRules_Id: return $"/users/{IdOrUserPrincipalName}/mailFolders/inbox/messageRules/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_MailFolders_Inbox_MessageRules_Id,
            Users_IdOrUserPrincipalName_MailFolders_Inbox_MessageRules_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public MessageRuleActions? Actions { get; set; }
        public MessageRulePredicates? Conditions { get; set; }
        public string? DisplayName { get; set; }
        public MessageRulePredicates? Exceptions { get; set; }
        public bool? IsEnabled { get; set; }
        public bool? IsReadOnly { get; set; }
        public Int32? Sequence { get; set; }
    }
    public partial class MessageruleUpdateResponse : RestApiResponse
    {
        public MessageRuleActions? Actions { get; set; }
        public MessageRulePredicates? Conditions { get; set; }
        public string? DisplayName { get; set; }
        public MessageRulePredicates? Exceptions { get; set; }
        public bool? HasError { get; set; }
        public string? Id { get; set; }
        public bool? IsEnabled { get; set; }
        public bool? IsReadOnly { get; set; }
        public Int32? Sequence { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/messagerule-update?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageruleUpdateResponse> MessageruleUpdateAsync()
        {
            var p = new MessageruleUpdateParameter();
            return await this.SendAsync<MessageruleUpdateParameter, MessageruleUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/messagerule-update?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageruleUpdateResponse> MessageruleUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new MessageruleUpdateParameter();
            return await this.SendAsync<MessageruleUpdateParameter, MessageruleUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/messagerule-update?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageruleUpdateResponse> MessageruleUpdateAsync(MessageruleUpdateParameter parameter)
        {
            return await this.SendAsync<MessageruleUpdateParameter, MessageruleUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/messagerule-update?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageruleUpdateResponse> MessageruleUpdateAsync(MessageruleUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MessageruleUpdateParameter, MessageruleUpdateResponse>(parameter, cancellationToken);
        }
    }
}
