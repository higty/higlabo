using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupListThreadsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Groups_Id_Threads,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_Threads: return $"/groups/{Id}/threads";
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
    public partial class GroupListThreadsResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/group-list-threads?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListThreadsResponse> GroupListThreadsAsync()
        {
            var p = new GroupListThreadsParameter();
            return await this.SendAsync<GroupListThreadsParameter, GroupListThreadsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-threads?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListThreadsResponse> GroupListThreadsAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListThreadsParameter();
            return await this.SendAsync<GroupListThreadsParameter, GroupListThreadsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-threads?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListThreadsResponse> GroupListThreadsAsync(GroupListThreadsParameter parameter)
        {
            return await this.SendAsync<GroupListThreadsParameter, GroupListThreadsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-threads?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListThreadsResponse> GroupListThreadsAsync(GroupListThreadsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListThreadsParameter, GroupListThreadsResponse>(parameter, cancellationToken);
        }
    }
}
