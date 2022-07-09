using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MessageruleGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

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

        public enum Field
        {
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class MessageruleGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/messagerule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageruleGetResponse> MessageruleGetAsync()
        {
            var p = new MessageruleGetParameter();
            return await this.SendAsync<MessageruleGetParameter, MessageruleGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/messagerule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageruleGetResponse> MessageruleGetAsync(CancellationToken cancellationToken)
        {
            var p = new MessageruleGetParameter();
            return await this.SendAsync<MessageruleGetParameter, MessageruleGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/messagerule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageruleGetResponse> MessageruleGetAsync(MessageruleGetParameter parameter)
        {
            return await this.SendAsync<MessageruleGetParameter, MessageruleGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/messagerule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageruleGetResponse> MessageruleGetAsync(MessageruleGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MessageruleGetParameter, MessageruleGetResponse>(parameter, cancellationToken);
        }
    }
}
