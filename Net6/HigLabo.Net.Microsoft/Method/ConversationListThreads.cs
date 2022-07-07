using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ConversationListThreadsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Groups_Id_Conversations_Id_Threads,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_Conversations_Id_Threads: return $"/groups/{GroupsId}/conversations/{ConversationsId}/threads";
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
        public string GroupsId { get; set; }
        public string ConversationsId { get; set; }
    }
    public partial class ConversationListThreadsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/conversationthread?view=graph-rest-1.0
        /// </summary>
        public partial class ConversationThread
        {
            public string? Id { get; set; }
            public Recipient[]? ToRecipients { get; set; }
            public Recipient[]? CcRecipients { get; set; }
            public string? Topic { get; set; }
            public bool? HasAttachments { get; set; }
            public DateTimeOffset? LastDeliveredDateTime { get; set; }
            public String[]? UniqueSenders { get; set; }
            public string? Preview { get; set; }
            public bool? IsLocked { get; set; }
        }

        public ConversationThread[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conversation-list-threads?view=graph-rest-1.0
        /// </summary>
        public async Task<ConversationListThreadsResponse> ConversationListThreadsAsync()
        {
            var p = new ConversationListThreadsParameter();
            return await this.SendAsync<ConversationListThreadsParameter, ConversationListThreadsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conversation-list-threads?view=graph-rest-1.0
        /// </summary>
        public async Task<ConversationListThreadsResponse> ConversationListThreadsAsync(CancellationToken cancellationToken)
        {
            var p = new ConversationListThreadsParameter();
            return await this.SendAsync<ConversationListThreadsParameter, ConversationListThreadsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conversation-list-threads?view=graph-rest-1.0
        /// </summary>
        public async Task<ConversationListThreadsResponse> ConversationListThreadsAsync(ConversationListThreadsParameter parameter)
        {
            return await this.SendAsync<ConversationListThreadsParameter, ConversationListThreadsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conversation-list-threads?view=graph-rest-1.0
        /// </summary>
        public async Task<ConversationListThreadsResponse> ConversationListThreadsAsync(ConversationListThreadsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationListThreadsParameter, ConversationListThreadsResponse>(parameter, cancellationToken);
        }
    }
}
