using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ProjectromeGetRecentActivitiesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Activities_Recent,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Activities_Recent: return $"/me/activities/recent";
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
    }
    public partial class ProjectromeGetRecentActivitiesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/projectrome-get-recent-activities?view=graph-rest-1.0
        /// </summary>
        public async Task<ProjectromeGetRecentActivitiesResponse> ProjectromeGetRecentActivitiesAsync()
        {
            var p = new ProjectromeGetRecentActivitiesParameter();
            return await this.SendAsync<ProjectromeGetRecentActivitiesParameter, ProjectromeGetRecentActivitiesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/projectrome-get-recent-activities?view=graph-rest-1.0
        /// </summary>
        public async Task<ProjectromeGetRecentActivitiesResponse> ProjectromeGetRecentActivitiesAsync(CancellationToken cancellationToken)
        {
            var p = new ProjectromeGetRecentActivitiesParameter();
            return await this.SendAsync<ProjectromeGetRecentActivitiesParameter, ProjectromeGetRecentActivitiesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/projectrome-get-recent-activities?view=graph-rest-1.0
        /// </summary>
        public async Task<ProjectromeGetRecentActivitiesResponse> ProjectromeGetRecentActivitiesAsync(ProjectromeGetRecentActivitiesParameter parameter)
        {
            return await this.SendAsync<ProjectromeGetRecentActivitiesParameter, ProjectromeGetRecentActivitiesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/projectrome-get-recent-activities?view=graph-rest-1.0
        /// </summary>
        public async Task<ProjectromeGetRecentActivitiesResponse> ProjectromeGetRecentActivitiesAsync(ProjectromeGetRecentActivitiesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ProjectromeGetRecentActivitiesParameter, ProjectromeGetRecentActivitiesResponse>(parameter, cancellationToken);
        }
    }
}
