using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ProjectromePutActivityParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Activities_AppActivityId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Activities_AppActivityId: return $"/me/activities/{AppActivityId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PUT";
        public string AppActivityId { get; set; }
    }
    public partial class ProjectromePutActivityResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/projectrome-put-activity?view=graph-rest-1.0
        /// </summary>
        public async Task<ProjectromePutActivityResponse> ProjectromePutActivityAsync()
        {
            var p = new ProjectromePutActivityParameter();
            return await this.SendAsync<ProjectromePutActivityParameter, ProjectromePutActivityResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/projectrome-put-activity?view=graph-rest-1.0
        /// </summary>
        public async Task<ProjectromePutActivityResponse> ProjectromePutActivityAsync(CancellationToken cancellationToken)
        {
            var p = new ProjectromePutActivityParameter();
            return await this.SendAsync<ProjectromePutActivityParameter, ProjectromePutActivityResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/projectrome-put-activity?view=graph-rest-1.0
        /// </summary>
        public async Task<ProjectromePutActivityResponse> ProjectromePutActivityAsync(ProjectromePutActivityParameter parameter)
        {
            return await this.SendAsync<ProjectromePutActivityParameter, ProjectromePutActivityResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/projectrome-put-activity?view=graph-rest-1.0
        /// </summary>
        public async Task<ProjectromePutActivityResponse> ProjectromePutActivityAsync(ProjectromePutActivityParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ProjectromePutActivityParameter, ProjectromePutActivityResponse>(parameter, cancellationToken);
        }
    }
}
