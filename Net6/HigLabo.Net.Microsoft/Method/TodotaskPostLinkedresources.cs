using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TodotaskPostLinkedresourcesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Todo_Lists_TodoTaskListId_Tasks_TaskId_LinkedResources,
            Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId_Tasks_TaskId_LinkedResources,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Todo_Lists_TodoTaskListId_Tasks_TaskId_LinkedResources: return $"/me/todo/lists/{TodoTaskListId}/tasks/{TaskId}/linkedResources";
                    case ApiPath.Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId_Tasks_TaskId_LinkedResources: return $"/users/{IdOrUserPrincipalName}/todo/lists/{TodoTaskListId}/tasks/{TaskId}/linkedResources";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? WebUrl { get; set; }
        public string? ApplicationName { get; set; }
        public string? DisplayName { get; set; }
        public string? ExternalId { get; set; }
        public string TodoTaskListId { get; set; }
        public string TaskId { get; set; }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class TodotaskPostLinkedresourcesResponse : RestApiResponse
    {
        public string? ApplicationName { get; set; }
        public string? DisplayName { get; set; }
        public string? ExternalId { get; set; }
        public string? Id { get; set; }
        public string? WebUrl { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotask-post-linkedresources?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotaskPostLinkedresourcesResponse> TodotaskPostLinkedresourcesAsync()
        {
            var p = new TodotaskPostLinkedresourcesParameter();
            return await this.SendAsync<TodotaskPostLinkedresourcesParameter, TodotaskPostLinkedresourcesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotask-post-linkedresources?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotaskPostLinkedresourcesResponse> TodotaskPostLinkedresourcesAsync(CancellationToken cancellationToken)
        {
            var p = new TodotaskPostLinkedresourcesParameter();
            return await this.SendAsync<TodotaskPostLinkedresourcesParameter, TodotaskPostLinkedresourcesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotask-post-linkedresources?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotaskPostLinkedresourcesResponse> TodotaskPostLinkedresourcesAsync(TodotaskPostLinkedresourcesParameter parameter)
        {
            return await this.SendAsync<TodotaskPostLinkedresourcesParameter, TodotaskPostLinkedresourcesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotask-post-linkedresources?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotaskPostLinkedresourcesResponse> TodotaskPostLinkedresourcesAsync(TodotaskPostLinkedresourcesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TodotaskPostLinkedresourcesParameter, TodotaskPostLinkedresourcesResponse>(parameter, cancellationToken);
        }
    }
}
