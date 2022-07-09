using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChecklistitemGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TodoTaskListId { get; set; }
            public string? TodoTaskId { get; set; }
            public string? ChecklistItemId { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

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

        public enum Field
        {
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
    public partial class ChecklistitemGetResponse : RestApiResponse
    {
        public DateTimeOffset? CheckedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsChecked { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/checklistitem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChecklistitemGetResponse> ChecklistitemGetAsync()
        {
            var p = new ChecklistitemGetParameter();
            return await this.SendAsync<ChecklistitemGetParameter, ChecklistitemGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/checklistitem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChecklistitemGetResponse> ChecklistitemGetAsync(CancellationToken cancellationToken)
        {
            var p = new ChecklistitemGetParameter();
            return await this.SendAsync<ChecklistitemGetParameter, ChecklistitemGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/checklistitem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChecklistitemGetResponse> ChecklistitemGetAsync(ChecklistitemGetParameter parameter)
        {
            return await this.SendAsync<ChecklistitemGetParameter, ChecklistitemGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/checklistitem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChecklistitemGetResponse> ChecklistitemGetAsync(ChecklistitemGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChecklistitemGetParameter, ChecklistitemGetResponse>(parameter, cancellationToken);
        }
    }
}
