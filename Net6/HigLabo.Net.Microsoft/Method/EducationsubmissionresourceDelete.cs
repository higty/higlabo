using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationsubmissionresourceDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Education_Classes_ClassId_Assignments_AssignmentId_Submissions_SubmissionId_Resources_ResourceId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_ClassId_Assignments_AssignmentId_Submissions_SubmissionId_Resources_ResourceId: return $"/education/classes/{ClassId}/assignments/{AssignmentId}/submissions/{SubmissionId}/resources/{ResourceId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ClassId { get; set; }
        public string AssignmentId { get; set; }
        public string SubmissionId { get; set; }
        public string ResourceId { get; set; }
    }
    public partial class EducationsubmissionresourceDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmissionresource-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionresourceDeleteResponse> EducationsubmissionresourceDeleteAsync()
        {
            var p = new EducationsubmissionresourceDeleteParameter();
            return await this.SendAsync<EducationsubmissionresourceDeleteParameter, EducationsubmissionresourceDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmissionresource-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionresourceDeleteResponse> EducationsubmissionresourceDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new EducationsubmissionresourceDeleteParameter();
            return await this.SendAsync<EducationsubmissionresourceDeleteParameter, EducationsubmissionresourceDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmissionresource-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionresourceDeleteResponse> EducationsubmissionresourceDeleteAsync(EducationsubmissionresourceDeleteParameter parameter)
        {
            return await this.SendAsync<EducationsubmissionresourceDeleteParameter, EducationsubmissionresourceDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmissionresource-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionresourceDeleteResponse> EducationsubmissionresourceDeleteAsync(EducationsubmissionresourceDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationsubmissionresourceDeleteParameter, EducationsubmissionresourceDeleteResponse>(parameter, cancellationToken);
        }
    }
}
