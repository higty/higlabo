using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TodotaskListChecklistitemsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Todo_Lists_TodoTaskListId_Tasks_TodoTaskId_ChecklistItems,
            Users_IdOrUserPrincipalName_Todo_Lists_TodoTaskListId_Tasks_TodoTaskId_ChecklistItems,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Todo_Lists_TodoTaskListId_Tasks_TodoTaskId_ChecklistItems: return $"/me/todo/lists/{TodoTaskListId}/tasks/{TodoTaskId}/checklistItems";
                    case ApiPath.Users_IdOrUserPrincipalName_Todo_Lists_TodoTaskListId_Tasks_TodoTaskId_ChecklistItems: return $"/users/{IdOrUserPrincipalName}/todo/lists/{TodoTaskListId}/tasks/{TodoTaskId}/checklistItems";
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
        public string TodoTaskListId { get; set; }
        public string TodoTaskId { get; set; }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class TodotaskListChecklistitemsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/checklistitem?view=graph-rest-1.0
        /// </summary>
        public partial class ChecklistItem
        {
            public DateTimeOffset? CheckedDateTime { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? DisplayName { get; set; }
            public string? Id { get; set; }
            public bool? IsChecked { get; set; }
        }

        public ChecklistItem[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotask-list-checklistitems?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotaskListChecklistitemsResponse> TodotaskListChecklistitemsAsync()
        {
            var p = new TodotaskListChecklistitemsParameter();
            return await this.SendAsync<TodotaskListChecklistitemsParameter, TodotaskListChecklistitemsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotask-list-checklistitems?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotaskListChecklistitemsResponse> TodotaskListChecklistitemsAsync(CancellationToken cancellationToken)
        {
            var p = new TodotaskListChecklistitemsParameter();
            return await this.SendAsync<TodotaskListChecklistitemsParameter, TodotaskListChecklistitemsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotask-list-checklistitems?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotaskListChecklistitemsResponse> TodotaskListChecklistitemsAsync(TodotaskListChecklistitemsParameter parameter)
        {
            return await this.SendAsync<TodotaskListChecklistitemsParameter, TodotaskListChecklistitemsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotask-list-checklistitems?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotaskListChecklistitemsResponse> TodotaskListChecklistitemsAsync(TodotaskListChecklistitemsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TodotaskListChecklistitemsParameter, TodotaskListChecklistitemsResponse>(parameter, cancellationToken);
        }
    }
}
