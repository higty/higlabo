using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ProjectromeGetActivitiesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Activities,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Activities: return $"/me/activities";
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
    public partial class ProjectromeGetActivitiesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/projectrome-get-activities?view=graph-rest-1.0
        /// </summary>
        public async Task<ProjectromeGetActivitiesResponse> ProjectromeGetActivitiesAsync()
        {
            var p = new ProjectromeGetActivitiesParameter();
            return await this.SendAsync<ProjectromeGetActivitiesParameter, ProjectromeGetActivitiesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/projectrome-get-activities?view=graph-rest-1.0
        /// </summary>
        public async Task<ProjectromeGetActivitiesResponse> ProjectromeGetActivitiesAsync(CancellationToken cancellationToken)
        {
            var p = new ProjectromeGetActivitiesParameter();
            return await this.SendAsync<ProjectromeGetActivitiesParameter, ProjectromeGetActivitiesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/projectrome-get-activities?view=graph-rest-1.0
        /// </summary>
        public async Task<ProjectromeGetActivitiesResponse> ProjectromeGetActivitiesAsync(ProjectromeGetActivitiesParameter parameter)
        {
            return await this.SendAsync<ProjectromeGetActivitiesParameter, ProjectromeGetActivitiesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/projectrome-get-activities?view=graph-rest-1.0
        /// </summary>
        public async Task<ProjectromeGetActivitiesResponse> ProjectromeGetActivitiesAsync(ProjectromeGetActivitiesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ProjectromeGetActivitiesParameter, ProjectromeGetActivitiesResponse>(parameter, cancellationToken);
        }
    }
}
