using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MailfolderListMessagerulesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_MailFolders_Inbox_MessageRules,
            Users_IdOrUserPrincipalName_MailFolders_Inbox_MessageRules,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_MailFolders_Inbox_MessageRules: return $"/me/mailFolders/inbox/messageRules";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Inbox_MessageRules: return $"/users/{IdOrUserPrincipalName}/mailFolders/inbox/messageRules";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class MailfolderListMessagerulesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/messagerule?view=graph-rest-1.0
        /// </summary>
        public partial class MessageRule
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

        public MessageRule[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-list-messagerules?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderListMessagerulesResponse> MailfolderListMessagerulesAsync()
        {
            var p = new MailfolderListMessagerulesParameter();
            return await this.SendAsync<MailfolderListMessagerulesParameter, MailfolderListMessagerulesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-list-messagerules?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderListMessagerulesResponse> MailfolderListMessagerulesAsync(CancellationToken cancellationToken)
        {
            var p = new MailfolderListMessagerulesParameter();
            return await this.SendAsync<MailfolderListMessagerulesParameter, MailfolderListMessagerulesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-list-messagerules?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderListMessagerulesResponse> MailfolderListMessagerulesAsync(MailfolderListMessagerulesParameter parameter)
        {
            return await this.SendAsync<MailfolderListMessagerulesParameter, MailfolderListMessagerulesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-list-messagerules?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderListMessagerulesResponse> MailfolderListMessagerulesAsync(MailfolderListMessagerulesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MailfolderListMessagerulesParameter, MailfolderListMessagerulesResponse>(parameter, cancellationToken);
        }
    }
}
