using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ConversationListThreadsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? GroupsId { get; set; }
            public string? ConversationsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_Conversations_Id_Threads: return $"/groups/{GroupsId}/conversations/{ConversationsId}/threads";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            ToRecipients,
            CcRecipients,
            Topic,
            HasAttachments,
            LastDeliveredDateTime,
            UniqueSenders,
            Preview,
            IsLocked,
            Posts,
        }
        public enum ApiPath
        {
            Groups_Id_Conversations_Id_Threads,
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
    public partial class ConversationListThreadsResponse : RestApiResponse
    {
        public ConversationThread[]? Value { get; set; }
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
