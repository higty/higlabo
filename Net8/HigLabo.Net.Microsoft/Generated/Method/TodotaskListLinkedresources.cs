using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todotask-list-linkedresources?view=graph-rest-1.0
    /// </summary>
    public partial class TodotaskListLinkedResourcesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TodoTaskListId { get; set; }
            public string? TaskId { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Todo_Lists_TodoTaskListId_Tasks_TaskId_LinkedResources: return $"/me/todo/lists/{TodoTaskListId}/tasks/{TaskId}/linkedResources";
                    case ApiPath.Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId_Tasks_TaskId_LinkedResources: return $"/users/{IdOrUserPrincipalName}/todo/lists/{TodoTaskListId}/tasks/{TaskId}/linkedResources";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Todo_Lists_TodoTaskListId_Tasks_TaskId_LinkedResources,
            Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId_Tasks_TaskId_LinkedResources,
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
    public partial class TodotaskListLinkedResourcesResponse : RestApiResponse<LinkedResource>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todotask-list-linkedresources?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-list-linkedresources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotaskListLinkedResourcesResponse> TodotaskListLinkedResourcesAsync()
        {
            var p = new TodotaskListLinkedResourcesParameter();
            return await this.SendAsync<TodotaskListLinkedResourcesParameter, TodotaskListLinkedResourcesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-list-linkedresources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotaskListLinkedResourcesResponse> TodotaskListLinkedResourcesAsync(CancellationToken cancellationToken)
        {
            var p = new TodotaskListLinkedResourcesParameter();
            return await this.SendAsync<TodotaskListLinkedResourcesParameter, TodotaskListLinkedResourcesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-list-linkedresources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotaskListLinkedResourcesResponse> TodotaskListLinkedResourcesAsync(TodotaskListLinkedResourcesParameter parameter)
        {
            return await this.SendAsync<TodotaskListLinkedResourcesParameter, TodotaskListLinkedResourcesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-list-linkedresources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotaskListLinkedResourcesResponse> TodotaskListLinkedResourcesAsync(TodotaskListLinkedResourcesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TodotaskListLinkedResourcesParameter, TodotaskListLinkedResourcesResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-list-linkedresources?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<LinkedResource> TodotaskListLinkedResourcesEnumerateAsync(TodotaskListLinkedResourcesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<TodotaskListLinkedResourcesParameter, TodotaskListLinkedResourcesResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<LinkedResource>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
