using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TodotaskPostChecklistitemsParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public DateTimeOffset? CheckedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public bool? IsChecked { get; set; }
        public string TodoTaskListId { get; set; }
        public string TodoTaskId { get; set; }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class TodotaskPostChecklistitemsResponse : RestApiResponse
    {
        public DateTimeOffset? CheckedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsChecked { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotask-post-checklistitems?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotaskPostChecklistitemsResponse> TodotaskPostChecklistitemsAsync()
        {
            var p = new TodotaskPostChecklistitemsParameter();
            return await this.SendAsync<TodotaskPostChecklistitemsParameter, TodotaskPostChecklistitemsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotask-post-checklistitems?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotaskPostChecklistitemsResponse> TodotaskPostChecklistitemsAsync(CancellationToken cancellationToken)
        {
            var p = new TodotaskPostChecklistitemsParameter();
            return await this.SendAsync<TodotaskPostChecklistitemsParameter, TodotaskPostChecklistitemsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotask-post-checklistitems?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotaskPostChecklistitemsResponse> TodotaskPostChecklistitemsAsync(TodotaskPostChecklistitemsParameter parameter)
        {
            return await this.SendAsync<TodotaskPostChecklistitemsParameter, TodotaskPostChecklistitemsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotask-post-checklistitems?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotaskPostChecklistitemsResponse> TodotaskPostChecklistitemsAsync(TodotaskPostChecklistitemsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TodotaskPostChecklistitemsParameter, TodotaskPostChecklistitemsResponse>(parameter, cancellationToken);
        }
    }
}
