using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todotask-list-checklistitems?view=graph-rest-1.0
    /// </summary>
    public partial class TodotaskListChecklistItemsParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
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
    public partial class TodotaskListChecklistItemsResponse : RestApiResponse<ChecklistItem>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todotask-list-checklistitems?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-list-checklistitems?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotaskListChecklistItemsResponse> TodotaskListChecklistItemsAsync()
        {
            var p = new TodotaskListChecklistItemsParameter();
            return await this.SendAsync<TodotaskListChecklistItemsParameter, TodotaskListChecklistItemsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-list-checklistitems?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotaskListChecklistItemsResponse> TodotaskListChecklistItemsAsync(CancellationToken cancellationToken)
        {
            var p = new TodotaskListChecklistItemsParameter();
            return await this.SendAsync<TodotaskListChecklistItemsParameter, TodotaskListChecklistItemsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-list-checklistitems?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotaskListChecklistItemsResponse> TodotaskListChecklistItemsAsync(TodotaskListChecklistItemsParameter parameter)
        {
            return await this.SendAsync<TodotaskListChecklistItemsParameter, TodotaskListChecklistItemsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-list-checklistitems?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotaskListChecklistItemsResponse> TodotaskListChecklistItemsAsync(TodotaskListChecklistItemsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TodotaskListChecklistItemsParameter, TodotaskListChecklistItemsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-list-checklistitems?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<ChecklistItem> TodotaskListChecklistItemsEnumerateAsync(TodotaskListChecklistItemsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<TodotaskListChecklistItemsParameter, TodotaskListChecklistItemsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<ChecklistItem>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
