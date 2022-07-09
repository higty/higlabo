using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class LinkedResourceDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TodoTaskListId { get; set; }
            public string? TaskId { get; set; }
            public string? LinkedResourcesId { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Todo_Lists_TodoTaskListId_Tasks_TaskId_LinkedResources_LinkedResourcesId: return $"/me/todo/lists/{TodoTaskListId}/tasks/{TaskId}/linkedResources/{LinkedResourcesId}";
                    case ApiPath.Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId_Tasks_TaskId_LinkedResources_LinkedResourcesId: return $"/users/{IdOrUserPrincipalName}/todo/lists/{TodoTaskListId}/tasks/{TaskId}/linkedResources/{LinkedResourcesId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Todo_Lists_TodoTaskListId_Tasks_TaskId_LinkedResources_LinkedResourcesId,
            Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId_Tasks_TaskId_LinkedResources_LinkedResourcesId,
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
    public partial class LinkedResourceDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/linkedresource-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<LinkedResourceDeleteResponse> LinkedResourceDeleteAsync()
        {
            var p = new LinkedResourceDeleteParameter();
            return await this.SendAsync<LinkedResourceDeleteParameter, LinkedResourceDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/linkedresource-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<LinkedResourceDeleteResponse> LinkedResourceDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new LinkedResourceDeleteParameter();
            return await this.SendAsync<LinkedResourceDeleteParameter, LinkedResourceDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/linkedresource-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<LinkedResourceDeleteResponse> LinkedResourceDeleteAsync(LinkedResourceDeleteParameter parameter)
        {
            return await this.SendAsync<LinkedResourceDeleteParameter, LinkedResourceDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/linkedresource-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<LinkedResourceDeleteResponse> LinkedResourceDeleteAsync(LinkedResourceDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<LinkedResourceDeleteParameter, LinkedResourceDeleteResponse>(parameter, cancellationToken);
        }
    }
}
