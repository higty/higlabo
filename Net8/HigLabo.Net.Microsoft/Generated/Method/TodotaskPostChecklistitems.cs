using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todotask-post-checklistitems?view=graph-rest-1.0
    /// </summary>
    public partial class TodotaskPostChecklistItemsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TodoTaskListId { get; set; }
            public string? TodoTaskId { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Todo_Lists_TodoTaskListId_Tasks_TodoTaskId_ChecklistItems: return $"/me/todo/lists/{TodoTaskListId}/tasks/{TodoTaskId}/checklistItems";
                    case ApiPath.Users_IdOrUserPrincipalName_Todo_Lists_TodoTaskListId_Tasks_TodoTaskId_ChecklistItems: return $"/users/{IdOrUserPrincipalName}/todo/lists/{TodoTaskListId}/tasks/{TodoTaskId}/checklistItems";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Todo_Lists_TodoTaskListId_Tasks_TodoTaskId_ChecklistItems,
            Users_IdOrUserPrincipalName_Todo_Lists_TodoTaskListId_Tasks_TodoTaskId_ChecklistItems,
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
        public DateTimeOffset? CheckedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public bool? IsChecked { get; set; }
        public string? Id { get; set; }
    }
    public partial class TodotaskPostChecklistItemsResponse : RestApiResponse
    {
        public DateTimeOffset? CheckedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsChecked { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todotask-post-checklistitems?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-post-checklistitems?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotaskPostChecklistItemsResponse> TodotaskPostChecklistItemsAsync()
        {
            var p = new TodotaskPostChecklistItemsParameter();
            return await this.SendAsync<TodotaskPostChecklistItemsParameter, TodotaskPostChecklistItemsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-post-checklistitems?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotaskPostChecklistItemsResponse> TodotaskPostChecklistItemsAsync(CancellationToken cancellationToken)
        {
            var p = new TodotaskPostChecklistItemsParameter();
            return await this.SendAsync<TodotaskPostChecklistItemsParameter, TodotaskPostChecklistItemsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-post-checklistitems?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotaskPostChecklistItemsResponse> TodotaskPostChecklistItemsAsync(TodotaskPostChecklistItemsParameter parameter)
        {
            return await this.SendAsync<TodotaskPostChecklistItemsParameter, TodotaskPostChecklistItemsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-post-checklistitems?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotaskPostChecklistItemsResponse> TodotaskPostChecklistItemsAsync(TodotaskPostChecklistItemsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TodotaskPostChecklistItemsParameter, TodotaskPostChecklistItemsResponse>(parameter, cancellationToken);
        }
    }
}
