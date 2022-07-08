using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChecklistitemDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string TodoTaskListId { get; set; }
            public string TodoTaskId { get; set; }
            public string ChecklistItemId { get; set; }
            public string IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Todo_Lists_TodoTaskListId_Tasks_TodoTaskId_ChecklistItems_ChecklistItemId: return $"/me/todo/lists/{TodoTaskListId}/tasks/{TodoTaskId}/checklistItems/{ChecklistItemId}";
                    case ApiPath.Users_IdOrUserPrincipalName_Todo_Lists_TodoTaskListId_Tasks_TodoTaskId_ChecklistItems_ChecklistItemId: return $"/users/{IdOrUserPrincipalName}/todo/lists/{TodoTaskListId}/tasks/{TodoTaskId}/checklistItems/{ChecklistItemId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Todo_Lists_TodoTaskListId_Tasks_TodoTaskId_ChecklistItems_ChecklistItemId,
            Users_IdOrUserPrincipalName_Todo_Lists_TodoTaskListId_Tasks_TodoTaskId_ChecklistItems_ChecklistItemId,
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
    public partial class ChecklistitemDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/checklistitem-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ChecklistitemDeleteResponse> ChecklistitemDeleteAsync()
        {
            var p = new ChecklistitemDeleteParameter();
            return await this.SendAsync<ChecklistitemDeleteParameter, ChecklistitemDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/checklistitem-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ChecklistitemDeleteResponse> ChecklistitemDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ChecklistitemDeleteParameter();
            return await this.SendAsync<ChecklistitemDeleteParameter, ChecklistitemDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/checklistitem-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ChecklistitemDeleteResponse> ChecklistitemDeleteAsync(ChecklistitemDeleteParameter parameter)
        {
            return await this.SendAsync<ChecklistitemDeleteParameter, ChecklistitemDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/checklistitem-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ChecklistitemDeleteResponse> ChecklistitemDeleteAsync(ChecklistitemDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChecklistitemDeleteParameter, ChecklistitemDeleteResponse>(parameter, cancellationToken);
        }
    }
}
