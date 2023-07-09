using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/taskfileattachment-delete?view=graph-rest-1.0
    /// </summary>
    public partial class TaskfileattachmentDeleteParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class TaskfileattachmentDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/taskfileattachment-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/taskfileattachment-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TaskfileattachmentDeleteResponse> TaskfileattachmentDeleteAsync()
        {
            var p = new TaskfileattachmentDeleteParameter();
            return await this.SendAsync<TaskfileattachmentDeleteParameter, TaskfileattachmentDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/taskfileattachment-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TaskfileattachmentDeleteResponse> TaskfileattachmentDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new TaskfileattachmentDeleteParameter();
            return await this.SendAsync<TaskfileattachmentDeleteParameter, TaskfileattachmentDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/taskfileattachment-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TaskfileattachmentDeleteResponse> TaskfileattachmentDeleteAsync(TaskfileattachmentDeleteParameter parameter)
        {
            return await this.SendAsync<TaskfileattachmentDeleteParameter, TaskfileattachmentDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/taskfileattachment-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TaskfileattachmentDeleteResponse> TaskfileattachmentDeleteAsync(TaskfileattachmentDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TaskfileattachmentDeleteParameter, TaskfileattachmentDeleteResponse>(parameter, cancellationToken);
        }
    }
}
