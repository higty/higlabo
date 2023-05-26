using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/linkedresource-get?view=graph-rest-1.0
    /// </summary>
    public partial class LinkedResourceGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class LinkedResourceGetResponse : RestApiResponse
    {
        public string? ApplicationName { get; set; }
        public string? DisplayName { get; set; }
        public string? ExternalId { get; set; }
        public string? Id { get; set; }
        public string? WebUrl { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/linkedresource-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/linkedresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<LinkedResourceGetResponse> LinkedResourceGetAsync()
        {
            var p = new LinkedResourceGetParameter();
            return await this.SendAsync<LinkedResourceGetParameter, LinkedResourceGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/linkedresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<LinkedResourceGetResponse> LinkedResourceGetAsync(CancellationToken cancellationToken)
        {
            var p = new LinkedResourceGetParameter();
            return await this.SendAsync<LinkedResourceGetParameter, LinkedResourceGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/linkedresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<LinkedResourceGetResponse> LinkedResourceGetAsync(LinkedResourceGetParameter parameter)
        {
            return await this.SendAsync<LinkedResourceGetParameter, LinkedResourceGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/linkedresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<LinkedResourceGetResponse> LinkedResourceGetAsync(LinkedResourceGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<LinkedResourceGetParameter, LinkedResourceGetResponse>(parameter, cancellationToken);
        }
    }
}
