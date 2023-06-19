using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/taskfileattachment-get?view=graph-rest-1.0
    /// </summary>
    public partial class TaskfileattachmentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ListsId { get; set; }
            public string? TasksId { get; set; }
            public string? AttachmentsId { get; set; }
            public string? UsersId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Todo_Lists_Id_Tasks_Id_Attachments_Id: return $"/me/todo/lists/{ListsId}/tasks/{TasksId}/attachments/{AttachmentsId}";
                    case ApiPath.Users_Id_Todo_Lists_Id_Tasks_Id_Attachments_Id: return $"/users/{UsersId}/todo/lists/{ListsId}/tasks/{TasksId}/attachments/{AttachmentsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Todo_Lists_Id_Tasks_Id_Attachments_Id,
            Users_Id_Todo_Lists_Id_Tasks_Id_Attachments_Id,
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
    public partial class TaskfileattachmentGetResponse : RestApiResponse
    {
        public string? ContentBytes { get; set; }
        public string? ContentType { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? Name { get; set; }
        public Int32? Size { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/taskfileattachment-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/taskfileattachment-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TaskfileattachmentGetResponse> TaskfileattachmentGetAsync()
        {
            var p = new TaskfileattachmentGetParameter();
            return await this.SendAsync<TaskfileattachmentGetParameter, TaskfileattachmentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/taskfileattachment-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TaskfileattachmentGetResponse> TaskfileattachmentGetAsync(CancellationToken cancellationToken)
        {
            var p = new TaskfileattachmentGetParameter();
            return await this.SendAsync<TaskfileattachmentGetParameter, TaskfileattachmentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/taskfileattachment-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TaskfileattachmentGetResponse> TaskfileattachmentGetAsync(TaskfileattachmentGetParameter parameter)
        {
            return await this.SendAsync<TaskfileattachmentGetParameter, TaskfileattachmentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/taskfileattachment-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TaskfileattachmentGetResponse> TaskfileattachmentGetAsync(TaskfileattachmentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TaskfileattachmentGetParameter, TaskfileattachmentGetResponse>(parameter, cancellationToken);
        }
    }
}
