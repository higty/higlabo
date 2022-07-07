using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class LinkedresourceGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        public string TaskId { get; set; }
        public string LinkedResourcesId { get; set; }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class LinkedresourceGetResponse : RestApiResponse
    {
        public string? ApplicationName { get; set; }
        public string? DisplayName { get; set; }
        public string? ExternalId { get; set; }
        public string? Id { get; set; }
        public string? WebUrl { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/linkedresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<LinkedresourceGetResponse> LinkedresourceGetAsync()
        {
            var p = new LinkedresourceGetParameter();
            return await this.SendAsync<LinkedresourceGetParameter, LinkedresourceGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/linkedresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<LinkedresourceGetResponse> LinkedresourceGetAsync(CancellationToken cancellationToken)
        {
            var p = new LinkedresourceGetParameter();
            return await this.SendAsync<LinkedresourceGetParameter, LinkedresourceGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/linkedresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<LinkedresourceGetResponse> LinkedresourceGetAsync(LinkedresourceGetParameter parameter)
        {
            return await this.SendAsync<LinkedresourceGetParameter, LinkedresourceGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/linkedresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<LinkedresourceGetResponse> LinkedresourceGetAsync(LinkedresourceGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<LinkedresourceGetParameter, LinkedresourceGetResponse>(parameter, cancellationToken);
        }
    }
}
