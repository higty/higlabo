using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/projectrome-delete-historyitem?view=graph-rest-1.0
    /// </summary>
    public partial class ProjectromeDeleteHistoryItemParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class ProjectromeDeleteHistoryItemResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/projectrome-delete-historyitem?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/projectrome-delete-historyitem?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ProjectromeDeleteHistoryItemResponse> ProjectromeDeleteHistoryItemAsync()
        {
            var p = new ProjectromeDeleteHistoryItemParameter();
            return await this.SendAsync<ProjectromeDeleteHistoryItemParameter, ProjectromeDeleteHistoryItemResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/projectrome-delete-historyitem?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ProjectromeDeleteHistoryItemResponse> ProjectromeDeleteHistoryItemAsync(CancellationToken cancellationToken)
        {
            var p = new ProjectromeDeleteHistoryItemParameter();
            return await this.SendAsync<ProjectromeDeleteHistoryItemParameter, ProjectromeDeleteHistoryItemResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/projectrome-delete-historyitem?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ProjectromeDeleteHistoryItemResponse> ProjectromeDeleteHistoryItemAsync(ProjectromeDeleteHistoryItemParameter parameter)
        {
            return await this.SendAsync<ProjectromeDeleteHistoryItemParameter, ProjectromeDeleteHistoryItemResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/projectrome-delete-historyitem?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ProjectromeDeleteHistoryItemResponse> ProjectromeDeleteHistoryItemAsync(ProjectromeDeleteHistoryItemParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ProjectromeDeleteHistoryItemParameter, ProjectromeDeleteHistoryItemResponse>(parameter, cancellationToken);
        }
    }
}
