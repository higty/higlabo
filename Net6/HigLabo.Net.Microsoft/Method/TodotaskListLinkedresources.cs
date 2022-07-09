using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TodotaskListLinkedResourcesParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Me_Todo_Lists_TodoTaskListId_Tasks_TaskId_LinkedResources: return $"/me/todo/lists/{TodoTaskListId}/tasks/{TaskId}/linkedResources";
                    case ApiPath.Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId_Tasks_TaskId_LinkedResources: return $"/users/{IdOrUserPrincipalName}/todo/lists/{TodoTaskListId}/tasks/{TaskId}/linkedResources";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ApplicationName,
            DisplayName,
            ExternalId,
            Id,
            WebUrl,
        }
        public enum ApiPath
        {
            Me_Todo_Lists_TodoTaskListId_Tasks_TaskId_LinkedResources,
            Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId_Tasks_TaskId_LinkedResources,
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
    public partial class TodotaskListLinkedResourcesResponse : RestApiResponse
    {
        public LinkedResource[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotask-list-linkedresources?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotaskListLinkedResourcesResponse> TodotaskListLinkedResourcesAsync()
        {
            var p = new TodotaskListLinkedResourcesParameter();
            return await this.SendAsync<TodotaskListLinkedResourcesParameter, TodotaskListLinkedResourcesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotask-list-linkedresources?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotaskListLinkedResourcesResponse> TodotaskListLinkedResourcesAsync(CancellationToken cancellationToken)
        {
            var p = new TodotaskListLinkedResourcesParameter();
            return await this.SendAsync<TodotaskListLinkedResourcesParameter, TodotaskListLinkedResourcesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotask-list-linkedresources?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotaskListLinkedResourcesResponse> TodotaskListLinkedResourcesAsync(TodotaskListLinkedResourcesParameter parameter)
        {
            return await this.SendAsync<TodotaskListLinkedResourcesParameter, TodotaskListLinkedResourcesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotask-list-linkedresources?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotaskListLinkedResourcesResponse> TodotaskListLinkedResourcesAsync(TodotaskListLinkedResourcesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TodotaskListLinkedResourcesParameter, TodotaskListLinkedResourcesResponse>(parameter, cancellationToken);
        }
    }
}
