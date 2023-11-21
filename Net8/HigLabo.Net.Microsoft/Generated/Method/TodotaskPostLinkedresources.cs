using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todotask-post-linkedresources?view=graph-rest-1.0
    /// </summary>
    public partial class TodotaskPostLinkedResourcesParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? WebUrl { get; set; }
        public string? ApplicationName { get; set; }
        public string? DisplayName { get; set; }
        public string? ExternalId { get; set; }
    }
    public partial class TodotaskPostLinkedResourcesResponse : RestApiResponse
    {
        public string? ApplicationName { get; set; }
        public string? DisplayName { get; set; }
        public string? ExternalId { get; set; }
        public string? Id { get; set; }
        public string? WebUrl { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todotask-post-linkedresources?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-post-linkedresources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotaskPostLinkedResourcesResponse> TodotaskPostLinkedResourcesAsync()
        {
            var p = new TodotaskPostLinkedResourcesParameter();
            return await this.SendAsync<TodotaskPostLinkedResourcesParameter, TodotaskPostLinkedResourcesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-post-linkedresources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotaskPostLinkedResourcesResponse> TodotaskPostLinkedResourcesAsync(CancellationToken cancellationToken)
        {
            var p = new TodotaskPostLinkedResourcesParameter();
            return await this.SendAsync<TodotaskPostLinkedResourcesParameter, TodotaskPostLinkedResourcesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-post-linkedresources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotaskPostLinkedResourcesResponse> TodotaskPostLinkedResourcesAsync(TodotaskPostLinkedResourcesParameter parameter)
        {
            return await this.SendAsync<TodotaskPostLinkedResourcesParameter, TodotaskPostLinkedResourcesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-post-linkedresources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotaskPostLinkedResourcesResponse> TodotaskPostLinkedResourcesAsync(TodotaskPostLinkedResourcesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TodotaskPostLinkedResourcesParameter, TodotaskPostLinkedResourcesResponse>(parameter, cancellationToken);
        }
    }
}
