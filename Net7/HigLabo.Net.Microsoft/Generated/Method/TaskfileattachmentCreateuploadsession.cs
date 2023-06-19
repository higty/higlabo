using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/taskfileattachment-createuploadsession?view=graph-rest-1.0
    /// </summary>
    public partial class TaskfileattachmentCreateuploadsessionParameter : IRestApiParameter
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
                    case ApiPath.Me_Todo_Lists_Id_Tasks_Id_Attachments_CreateUploadSession: return $"/me/todo/lists/{ListsId}/tasks/{TasksId}/attachments/createUploadSession";
                    case ApiPath.Users_Id_Todo_Lists_Id_Tasks_Id_Attachments_CreateUploadSession: return $"/users/{UsersId}/todo/lists/{ListsId}/tasks/{TasksId}/attachments/createUploadSession";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Todo_Lists_Id_Tasks_Id_Attachments_CreateUploadSession,
            Users_Id_Todo_Lists_Id_Tasks_Id_Attachments_CreateUploadSession,
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
        public AttachmentInfo? AttachmentInfo { get; set; }
        public DateTimeOffset? ExpirationDateTime { get; set; }
        public String[]? NextExpectedRanges { get; set; }
        public string? UploadUrl { get; set; }
    }
    public partial class TaskfileattachmentCreateuploadsessionResponse : RestApiResponse
    {
        public DateTimeOffset? ExpirationDateTime { get; set; }
        public String[]? NextExpectedRanges { get; set; }
        public string? UploadUrl { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/taskfileattachment-createuploadsession?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/taskfileattachment-createuploadsession?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TaskfileattachmentCreateuploadsessionResponse> TaskfileattachmentCreateuploadsessionAsync()
        {
            var p = new TaskfileattachmentCreateuploadsessionParameter();
            return await this.SendAsync<TaskfileattachmentCreateuploadsessionParameter, TaskfileattachmentCreateuploadsessionResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/taskfileattachment-createuploadsession?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TaskfileattachmentCreateuploadsessionResponse> TaskfileattachmentCreateuploadsessionAsync(CancellationToken cancellationToken)
        {
            var p = new TaskfileattachmentCreateuploadsessionParameter();
            return await this.SendAsync<TaskfileattachmentCreateuploadsessionParameter, TaskfileattachmentCreateuploadsessionResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/taskfileattachment-createuploadsession?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TaskfileattachmentCreateuploadsessionResponse> TaskfileattachmentCreateuploadsessionAsync(TaskfileattachmentCreateuploadsessionParameter parameter)
        {
            return await this.SendAsync<TaskfileattachmentCreateuploadsessionParameter, TaskfileattachmentCreateuploadsessionResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/taskfileattachment-createuploadsession?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TaskfileattachmentCreateuploadsessionResponse> TaskfileattachmentCreateuploadsessionAsync(TaskfileattachmentCreateuploadsessionParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TaskfileattachmentCreateuploadsessionParameter, TaskfileattachmentCreateuploadsessionResponse>(parameter, cancellationToken);
        }
    }
}
