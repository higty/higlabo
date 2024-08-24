using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todotasklist-list-tasks?view=graph-rest-1.0
    /// </summary>
    public partial class TodotasklistListTasksParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TodoTaskListId { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Todo_Lists_TodoTaskListId_Tasks: return $"/me/todo/lists/{TodoTaskListId}/tasks";
                    case ApiPath.Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId_Tasks: return $"/users/{IdOrUserPrincipalName}/todo/lists/{TodoTaskListId}/tasks";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Todo_Lists_TodoTaskListId_Tasks,
            Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId_Tasks,
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
    public partial class TodotasklistListTasksResponse : RestApiResponse<TodoTask>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todotasklist-list-tasks?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotasklist-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotasklistListTasksResponse> TodotasklistListTasksAsync()
        {
            var p = new TodotasklistListTasksParameter();
            return await this.SendAsync<TodotasklistListTasksParameter, TodotasklistListTasksResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotasklist-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotasklistListTasksResponse> TodotasklistListTasksAsync(CancellationToken cancellationToken)
        {
            var p = new TodotasklistListTasksParameter();
            return await this.SendAsync<TodotasklistListTasksParameter, TodotasklistListTasksResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotasklist-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotasklistListTasksResponse> TodotasklistListTasksAsync(TodotasklistListTasksParameter parameter)
        {
            return await this.SendAsync<TodotasklistListTasksParameter, TodotasklistListTasksResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotasklist-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotasklistListTasksResponse> TodotasklistListTasksAsync(TodotasklistListTasksParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TodotasklistListTasksParameter, TodotasklistListTasksResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotasklist-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<TodoTask> TodotasklistListTasksEnumerateAsync(TodotasklistListTasksParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<TodotasklistListTasksParameter, TodotasklistListTasksResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<TodoTask>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
