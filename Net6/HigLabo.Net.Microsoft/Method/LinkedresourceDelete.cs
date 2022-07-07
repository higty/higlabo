using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class LinkedresourceDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Todo_Lists_TodoTaskListId_Tasks_TaskId_LinkedResources_LinkedResourcesId,
            Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId_Tasks_TaskId_LinkedResources_LinkedResourcesId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Todo_Lists_TodoTaskListId_Tasks_TaskId_LinkedResources_LinkedResourcesId: return $"/me/todo/lists/{TodoTaskListId}/tasks/{TaskId}/linkedResources/{LinkedResourcesId}";
                    case ApiPath.Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId_Tasks_TaskId_LinkedResources_LinkedResourcesId: return $"/users/{IdOrUserPrincipalName}/todo/lists/{TodoTaskListId}/tasks/{TaskId}/linkedResources/{LinkedResourcesId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string TodoTaskListId { get; set; }
        public string TaskId { get; set; }
        public string LinkedResourcesId { get; set; }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class LinkedresourceDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/linkedresource-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<LinkedresourceDeleteResponse> LinkedresourceDeleteAsync()
        {
            var p = new LinkedresourceDeleteParameter();
            return await this.SendAsync<LinkedresourceDeleteParameter, LinkedresourceDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/linkedresource-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<LinkedresourceDeleteResponse> LinkedresourceDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new LinkedresourceDeleteParameter();
            return await this.SendAsync<LinkedresourceDeleteParameter, LinkedresourceDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/linkedresource-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<LinkedresourceDeleteResponse> LinkedresourceDeleteAsync(LinkedresourceDeleteParameter parameter)
        {
            return await this.SendAsync<LinkedresourceDeleteParameter, LinkedresourceDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/linkedresource-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<LinkedresourceDeleteResponse> LinkedresourceDeleteAsync(LinkedresourceDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<LinkedresourceDeleteParameter, LinkedresourceDeleteResponse>(parameter, cancellationToken);
        }
    }
}
