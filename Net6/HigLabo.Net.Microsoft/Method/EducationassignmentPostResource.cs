using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationassignmentPostResourceParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Education_Classes_ClassId_Assignments_AssignmentId_Resources,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_ClassId_Assignments_AssignmentId_Resources: return $"/education/classes/{ClassId}/assignments/{AssignmentId}/resources";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string ClassId { get; set; }
        public string AssignmentId { get; set; }
    }
    public partial class EducationassignmentPostResourceResponse : RestApiResponse
    {
        public bool? DistributeForStudentWork { get; set; }
        public string? Id { get; set; }
        public EducationResource? Resource { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-post-resource?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentPostResourceResponse> EducationassignmentPostResourceAsync()
        {
            var p = new EducationassignmentPostResourceParameter();
            return await this.SendAsync<EducationassignmentPostResourceParameter, EducationassignmentPostResourceResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-post-resource?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentPostResourceResponse> EducationassignmentPostResourceAsync(CancellationToken cancellationToken)
        {
            var p = new EducationassignmentPostResourceParameter();
            return await this.SendAsync<EducationassignmentPostResourceParameter, EducationassignmentPostResourceResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-post-resource?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentPostResourceResponse> EducationassignmentPostResourceAsync(EducationassignmentPostResourceParameter parameter)
        {
            return await this.SendAsync<EducationassignmentPostResourceParameter, EducationassignmentPostResourceResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-post-resource?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentPostResourceResponse> EducationassignmentPostResourceAsync(EducationassignmentPostResourceParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationassignmentPostResourceParameter, EducationassignmentPostResourceResponse>(parameter, cancellationToken);
        }
    }
}
