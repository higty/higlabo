using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todotask-post-attachments?view=graph-rest-1.0
    /// </summary>
    public partial class TodotaskPostAttachmentsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ListsId { get; set; }
            public string? TasksId { get; set; }
            public string? UsersId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Todo_Lists_Id_Tasks_Id_Attachments: return $"/me/todo/lists/{ListsId}/tasks/{TasksId}/attachments";
                    case ApiPath.Users_Id_Todo_Lists_Id_Tasks_Id_Attachments: return $"/users/{UsersId}/todo/lists/{ListsId}/tasks/{TasksId}/attachments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Todo_Lists_Id_Tasks_Id_Attachments,
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? ContentBytes { get; set; }
        public string? ContentType { get; set; }
        public string? Name { get; set; }
        public Int32? Size { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
    }
    public partial class TodotaskPostAttachmentsResponse : RestApiResponse
    {
        public string? ContentBytes { get; set; }
        public string? ContentType { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? Name { get; set; }
        public Int32? Size { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todotask-post-attachments?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotaskPostAttachmentsResponse> TodotaskPostAttachmentsAsync()
        {
            var p = new TodotaskPostAttachmentsParameter();
            return await this.SendAsync<TodotaskPostAttachmentsParameter, TodotaskPostAttachmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotaskPostAttachmentsResponse> TodotaskPostAttachmentsAsync(CancellationToken cancellationToken)
        {
            var p = new TodotaskPostAttachmentsParameter();
            return await this.SendAsync<TodotaskPostAttachmentsParameter, TodotaskPostAttachmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotaskPostAttachmentsResponse> TodotaskPostAttachmentsAsync(TodotaskPostAttachmentsParameter parameter)
        {
            return await this.SendAsync<TodotaskPostAttachmentsParameter, TodotaskPostAttachmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotask-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodotaskPostAttachmentsResponse> TodotaskPostAttachmentsAsync(TodotaskPostAttachmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TodotaskPostAttachmentsParameter, TodotaskPostAttachmentsResponse>(parameter, cancellationToken);
        }
    }
}
