using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ProjectromePutHistoryitemParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string ActivitiesId { get; set; }
            public string HistoryItemsId { get; set; }

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
    public partial class ProjectromePutHistoryitemResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/projectrome-put-historyitem?view=graph-rest-1.0
        /// </summary>
        public async Task<ProjectromePutHistoryitemResponse> ProjectromePutHistoryitemAsync()
        {
            var p = new ProjectromePutHistoryitemParameter();
            return await this.SendAsync<ProjectromePutHistoryitemParameter, ProjectromePutHistoryitemResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/projectrome-put-historyitem?view=graph-rest-1.0
        /// </summary>
        public async Task<ProjectromePutHistoryitemResponse> ProjectromePutHistoryitemAsync(CancellationToken cancellationToken)
        {
            var p = new ProjectromePutHistoryitemParameter();
            return await this.SendAsync<ProjectromePutHistoryitemParameter, ProjectromePutHistoryitemResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/projectrome-put-historyitem?view=graph-rest-1.0
        /// </summary>
        public async Task<ProjectromePutHistoryitemResponse> ProjectromePutHistoryitemAsync(ProjectromePutHistoryitemParameter parameter)
        {
            return await this.SendAsync<ProjectromePutHistoryitemParameter, ProjectromePutHistoryitemResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/projectrome-put-historyitem?view=graph-rest-1.0
        /// </summary>
        public async Task<ProjectromePutHistoryitemResponse> ProjectromePutHistoryitemAsync(ProjectromePutHistoryitemParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ProjectromePutHistoryitemParameter, ProjectromePutHistoryitemResponse>(parameter, cancellationToken);
        }
    }
}
