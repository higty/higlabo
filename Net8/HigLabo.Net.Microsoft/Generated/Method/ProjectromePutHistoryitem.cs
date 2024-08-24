using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/projectrome-put-historyitem?view=graph-rest-1.0
    /// </summary>
    public partial class ProjectromePutHistoryItemParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ActivitiesId { get; set; }
            public string? HistoryItemsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Activities_Id_HistoryItems_Id: return $"/me/activities/{ActivitiesId}/historyItems/{HistoryItemsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Activities_Id_HistoryItems_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PUT";
    }
    public partial class ProjectromePutHistoryItemResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/projectrome-put-historyitem?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/projectrome-put-historyitem?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ProjectromePutHistoryItemResponse> ProjectromePutHistoryItemAsync()
        {
            var p = new ProjectromePutHistoryItemParameter();
            return await this.SendAsync<ProjectromePutHistoryItemParameter, ProjectromePutHistoryItemResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/projectrome-put-historyitem?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ProjectromePutHistoryItemResponse> ProjectromePutHistoryItemAsync(CancellationToken cancellationToken)
        {
            var p = new ProjectromePutHistoryItemParameter();
            return await this.SendAsync<ProjectromePutHistoryItemParameter, ProjectromePutHistoryItemResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/projectrome-put-historyitem?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ProjectromePutHistoryItemResponse> ProjectromePutHistoryItemAsync(ProjectromePutHistoryItemParameter parameter)
        {
            return await this.SendAsync<ProjectromePutHistoryItemParameter, ProjectromePutHistoryItemResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/projectrome-put-historyitem?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ProjectromePutHistoryItemResponse> ProjectromePutHistoryItemAsync(ProjectromePutHistoryItemParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ProjectromePutHistoryItemParameter, ProjectromePutHistoryItemResponse>(parameter, cancellationToken);
        }
    }
}
