using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ConversationPostThreadsParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public Recipient[]? ToRecipients { get; set; }
        public Recipient[]? CcRecipients { get; set; }
        public string? Topic { get; set; }
        public bool? HasAttachments { get; set; }
        public DateTimeOffset? LastDeliveredDateTime { get; set; }
        public String[]? UniqueSenders { get; set; }
        public string? Preview { get; set; }
        public bool? IsLocked { get; set; }
        public Post[]? Posts { get; set; }
    }
    public partial class ConversationPostThreadsResponse : RestApiResponse
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
        public Post[]? Posts { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conversation-post-threads?view=graph-rest-1.0
        /// </summary>
        public async Task<ConversationPostThreadsResponse> ConversationPostThreadsAsync()
        {
            var p = new ConversationPostThreadsParameter();
            return await this.SendAsync<ConversationPostThreadsParameter, ConversationPostThreadsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conversation-post-threads?view=graph-rest-1.0
        /// </summary>
        public async Task<ConversationPostThreadsResponse> ConversationPostThreadsAsync(CancellationToken cancellationToken)
        {
            var p = new ConversationPostThreadsParameter();
            return await this.SendAsync<ConversationPostThreadsParameter, ConversationPostThreadsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conversation-post-threads?view=graph-rest-1.0
        /// </summary>
        public async Task<ConversationPostThreadsResponse> ConversationPostThreadsAsync(ConversationPostThreadsParameter parameter)
        {
            return await this.SendAsync<ConversationPostThreadsParameter, ConversationPostThreadsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conversation-post-threads?view=graph-rest-1.0
        /// </summary>
        public async Task<ConversationPostThreadsResponse> ConversationPostThreadsAsync(ConversationPostThreadsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationPostThreadsParameter, ConversationPostThreadsResponse>(parameter, cancellationToken);
        }
    }
}
