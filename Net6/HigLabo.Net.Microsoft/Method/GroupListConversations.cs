using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupListConversationsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Groups_Id_Conversations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_Conversations: return $"/groups/{Id}/conversations";
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
        public string Id { get; set; }
    }
    public partial class GroupListConversationsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/conversation?view=graph-rest-1.0
        /// </summary>
        public partial class Conversation
        {
            public bool? HasAttachments { get; set; }
            public string? Id { get; set; }
            public DateTimeOffset? LastDeliveredDateTime { get; set; }
            public string? Preview { get; set; }
            public string? Topic { get; set; }
            public String[]? UniqueSenders { get; set; }
        }

        public Conversation[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-conversations?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListConversationsResponse> GroupListConversationsAsync()
        {
            var p = new GroupListConversationsParameter();
            return await this.SendAsync<GroupListConversationsParameter, GroupListConversationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-conversations?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListConversationsResponse> GroupListConversationsAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListConversationsParameter();
            return await this.SendAsync<GroupListConversationsParameter, GroupListConversationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-conversations?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListConversationsResponse> GroupListConversationsAsync(GroupListConversationsParameter parameter)
        {
            return await this.SendAsync<GroupListConversationsParameter, GroupListConversationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-conversations?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListConversationsResponse> GroupListConversationsAsync(GroupListConversationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListConversationsParameter, GroupListConversationsResponse>(parameter, cancellationToken);
        }
    }
}
