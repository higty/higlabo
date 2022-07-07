using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ProjectromeDeleteHistoryitemParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Activities_Id_HistoryItems_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Activities_Id_HistoryItems_Id: return $"/me/activities/{ActivitiesId}/historyItems/{HistoryItemsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ActivitiesId { get; set; }
        public string HistoryItemsId { get; set; }
    }
    public partial class ProjectromeDeleteHistoryitemResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/projectrome-delete-historyitem?view=graph-rest-1.0
        /// </summary>
        public async Task<ProjectromeDeleteHistoryitemResponse> ProjectromeDeleteHistoryitemAsync()
        {
            var p = new ProjectromeDeleteHistoryitemParameter();
            return await this.SendAsync<ProjectromeDeleteHistoryitemParameter, ProjectromeDeleteHistoryitemResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/projectrome-delete-historyitem?view=graph-rest-1.0
        /// </summary>
        public async Task<ProjectromeDeleteHistoryitemResponse> ProjectromeDeleteHistoryitemAsync(CancellationToken cancellationToken)
        {
            var p = new ProjectromeDeleteHistoryitemParameter();
            return await this.SendAsync<ProjectromeDeleteHistoryitemParameter, ProjectromeDeleteHistoryitemResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/projectrome-delete-historyitem?view=graph-rest-1.0
        /// </summary>
        public async Task<ProjectromeDeleteHistoryitemResponse> ProjectromeDeleteHistoryitemAsync(ProjectromeDeleteHistoryitemParameter parameter)
        {
            return await this.SendAsync<ProjectromeDeleteHistoryitemParameter, ProjectromeDeleteHistoryitemResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/projectrome-delete-historyitem?view=graph-rest-1.0
        /// </summary>
        public async Task<ProjectromeDeleteHistoryitemResponse> ProjectromeDeleteHistoryitemAsync(ProjectromeDeleteHistoryitemParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ProjectromeDeleteHistoryitemParameter, ProjectromeDeleteHistoryitemResponse>(parameter, cancellationToken);
        }
    }
}
