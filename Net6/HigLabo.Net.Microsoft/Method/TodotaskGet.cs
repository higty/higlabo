using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todotask-get?view=graph-rest-1.0
    /// </summary>
    public partial class TodotaskGetParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Me_Todo_Lists_TodoTaskListId_Tasks_TaskId: return $"/me/todo/lists/{TodoTaskListId}/tasks/{TaskId}";
                    case ApiPath.Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId_Tasks_TaskId: return $"/users/{IdOrUserPrincipalName}/todo/lists/{TodoTaskListId}/tasks/{TaskId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Todo_Lists_TodoTaskListId_Tasks_TaskId,
            Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId_Tasks_TaskId,
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
    public partial class TodotaskGetResponse : RestApiResponse
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
        public bool? HasAttachments { get; set; }
        public string? Id { get; set; }
        public TodoTaskImportance Importance { get; set; }
        public bool? IsReminderOn { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public PatternedRecurrence? Recurrence { get; set; }
        public DateTimeTimeZone? ReminderDateTime { get; set; }
        public DateTimeTimeZone? StartDateTime { get; set; }
        public TodoTaskTaskStatus Status { get; set; }
        public string? Title { get; set; }
        public TaskFileAttachment[]? Attachments { get; set; }
        public ChecklistItem[]? ChecklistItems { get; set; }
        public Extension[]? Extensions { get; set; }
        public LinkedResource[]? LinkedResources { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todotask-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotaskGetResponse> TodotaskGetAsync()
        {
            var p = new TodotaskGetParameter();
            return await this.SendAsync<TodotaskGetParameter, TodotaskGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotaskGetResponse> TodotaskGetAsync(CancellationToken cancellationToken)
        {
            var p = new TodotaskGetParameter();
            return await this.SendAsync<TodotaskGetParameter, TodotaskGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotaskGetResponse> TodotaskGetAsync(TodotaskGetParameter parameter)
        {
            return await this.SendAsync<TodotaskGetParameter, TodotaskGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotaskGetResponse> TodotaskGetAsync(TodotaskGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TodotaskGetParameter, TodotaskGetResponse>(parameter, cancellationToken);
        }
    }
}
