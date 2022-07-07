using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TodotasklistListTasksParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Todo_Lists_TodoTaskListId_Tasks,
            Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId_Tasks,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Todo_Lists_TodoTaskListId_Tasks: return $"/me/todo/lists/{TodoTaskListId}/tasks";
                    case ApiPath.Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId_Tasks: return $"/users/{IdOrUserPrincipalName}/todo/lists/{TodoTaskListId}/tasks";
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
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class TodotasklistListTasksResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/todotask?view=graph-rest-1.0
        /// </summary>
        public partial class TodoTask
        {
            public enum TodoTaskImportance
            {
                Low,
                Normal,
                High,
            }
            public enum TodoTaskTaskStatus
            {
                NotStarted,
                InProgress,
                Completed,
                WaitingOnOthers,
                Deferred,
            }

            public ItemBody? Body { get; set; }
            public DateTimeOffset? BodyLastModifiedDateTime { get; set; }
            public String[]? Categories { get; set; }
            public DateTimeTimeZone? CompletedDateTime { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public DateTimeTimeZone? DueDateTime { get; set; }
            public string? Id { get; set; }
            public TodoTaskImportance Importance { get; set; }
            public bool? IsReminderOn { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public PatternedRecurrence? Recurrence { get; set; }
            public DateTimeTimeZone? ReminderDateTime { get; set; }
            public TodoTaskTaskStatus Status { get; set; }
            public string? Title { get; set; }
        }

        public TodoTask[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotasklist-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotasklistListTasksResponse> TodotasklistListTasksAsync()
        {
            var p = new TodotasklistListTasksParameter();
            return await this.SendAsync<TodotasklistListTasksParameter, TodotasklistListTasksResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotasklist-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotasklistListTasksResponse> TodotasklistListTasksAsync(CancellationToken cancellationToken)
        {
            var p = new TodotasklistListTasksParameter();
            return await this.SendAsync<TodotasklistListTasksParameter, TodotasklistListTasksResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotasklist-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotasklistListTasksResponse> TodotasklistListTasksAsync(TodotasklistListTasksParameter parameter)
        {
            return await this.SendAsync<TodotasklistListTasksParameter, TodotasklistListTasksResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotasklist-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotasklistListTasksResponse> TodotasklistListTasksAsync(TodotasklistListTasksParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TodotasklistListTasksParameter, TodotasklistListTasksResponse>(parameter, cancellationToken);
        }
    }
}
