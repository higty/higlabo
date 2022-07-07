using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationsubmissionPostResourcesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Education_Classes_ClassId_Assignments_AssignmentId_Submissions_SubmissionId_Resources,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_ClassId_Assignments_AssignmentId_Submissions_SubmissionId_Resources: return $"/education/classes/{ClassId}/assignments/{AssignmentId}/submissions/{SubmissionId}/resources";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string ClassId { get; set; }
        public string AssignmentId { get; set; }
        public string SubmissionId { get; set; }
    }
    public partial class EducationsubmissionPostResourcesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-post-resources?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionPostResourcesResponse> EducationsubmissionPostResourcesAsync()
        {
            var p = new EducationsubmissionPostResourcesParameter();
            return await this.SendAsync<EducationsubmissionPostResourcesParameter, EducationsubmissionPostResourcesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-post-resources?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionPostResourcesResponse> EducationsubmissionPostResourcesAsync(CancellationToken cancellationToken)
        {
            var p = new EducationsubmissionPostResourcesParameter();
            return await this.SendAsync<EducationsubmissionPostResourcesParameter, EducationsubmissionPostResourcesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-post-resources?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionPostResourcesResponse> EducationsubmissionPostResourcesAsync(EducationsubmissionPostResourcesParameter parameter)
        {
            return await this.SendAsync<EducationsubmissionPostResourcesParameter, EducationsubmissionPostResourcesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-post-resources?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionPostResourcesResponse> EducationsubmissionPostResourcesAsync(EducationsubmissionPostResourcesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationsubmissionPostResourcesParameter, EducationsubmissionPostResourcesResponse>(parameter, cancellationToken);
        }
    }
}
