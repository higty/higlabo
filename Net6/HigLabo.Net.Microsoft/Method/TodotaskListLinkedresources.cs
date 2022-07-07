using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TodotaskListLinkedresourcesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        public string TaskId { get; set; }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class TodotaskListLinkedresourcesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/linkedresource?view=graph-rest-1.0
        /// </summary>
        public partial class LinkedResource
        {
            public string? ApplicationName { get; set; }
            public string? DisplayName { get; set; }
            public string? ExternalId { get; set; }
            public string? Id { get; set; }
            public string? WebUrl { get; set; }
        }

        public LinkedResource[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotask-list-linkedresources?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotaskListLinkedresourcesResponse> TodotaskListLinkedresourcesAsync()
        {
            var p = new TodotaskListLinkedresourcesParameter();
            return await this.SendAsync<TodotaskListLinkedresourcesParameter, TodotaskListLinkedresourcesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotask-list-linkedresources?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotaskListLinkedresourcesResponse> TodotaskListLinkedresourcesAsync(CancellationToken cancellationToken)
        {
            var p = new TodotaskListLinkedresourcesParameter();
            return await this.SendAsync<TodotaskListLinkedresourcesParameter, TodotaskListLinkedresourcesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotask-list-linkedresources?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotaskListLinkedresourcesResponse> TodotaskListLinkedresourcesAsync(TodotaskListLinkedresourcesParameter parameter)
        {
            return await this.SendAsync<TodotaskListLinkedresourcesParameter, TodotaskListLinkedresourcesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotask-list-linkedresources?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotaskListLinkedresourcesResponse> TodotaskListLinkedresourcesAsync(TodotaskListLinkedresourcesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TodotaskListLinkedresourcesParameter, TodotaskListLinkedresourcesResponse>(parameter, cancellationToken);
        }
    }
}
