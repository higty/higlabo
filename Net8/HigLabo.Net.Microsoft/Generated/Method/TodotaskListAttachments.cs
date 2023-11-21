using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todotask-list-attachments?view=graph-rest-1.0
    /// </summary>
    public partial class TodotaskListAttachmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TodoTaskListId { get; set; }
            public string? TodoTaskId { get; set; }
            public string? UsersId { get; set; }
            public string? ListsId { get; set; }
            public string? TasksId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Todo_Lists_TodoTaskListId_Tasks_TodoTaskId_Attachments: return $"/me/todo/lists/{TodoTaskListId}/tasks/{TodoTaskId}/attachments";
                    case ApiPath.Users_Id_Todo_Lists_Id_Tasks_Id_Attachments: return $"/users/{UsersId}/todo/lists/{ListsId}/tasks/{TasksId}/attachments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ContentBytes,
            ContentType,
            Id,
            LastModifiedDateTime,
            Name,
            Size,
        }
        public enum ApiPath
        {
            Me_Todo_Lists_TodoTaskListId_Tasks_TodoTaskId_Attachments,
            Users_Id_Todo_Lists_Id_Tasks_Id_Attachments,
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
    public partial class TodotaskListAttachmentsResponse : RestApiResponse
    {
        public TaskFileAttachment[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todotask-list-attachments?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotaskListAttachmentsResponse> TodotaskListAttachmentsAsync()
        {
            var p = new TodotaskListAttachmentsParameter();
            return await this.SendAsync<TodotaskListAttachmentsParameter, TodotaskListAttachmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotaskListAttachmentsResponse> TodotaskListAttachmentsAsync(CancellationToken cancellationToken)
        {
            var p = new TodotaskListAttachmentsParameter();
            return await this.SendAsync<TodotaskListAttachmentsParameter, TodotaskListAttachmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotaskListAttachmentsResponse> TodotaskListAttachmentsAsync(TodotaskListAttachmentsParameter parameter)
        {
            return await this.SendAsync<TodotaskListAttachmentsParameter, TodotaskListAttachmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotaskListAttachmentsResponse> TodotaskListAttachmentsAsync(TodotaskListAttachmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TodotaskListAttachmentsParameter, TodotaskListAttachmentsResponse>(parameter, cancellationToken);
        }
    }
}
