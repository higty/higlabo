using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationsubmissionReturnParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Education_Classes_ClassId_Assignments_AssignmentId_Submissions_SubmissionId_Return,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_ClassId_Assignments_AssignmentId_Submissions_SubmissionId_Return: return $"/education/classes/{ClassId}/assignments/{AssignmentId}/submissions/{SubmissionId}/return";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string ClassId { get; set; }
        public string AssignmentId { get; set; }
        public string SubmissionId { get; set; }
    }
    public partial class EducationsubmissionReturnResponse : RestApiResponse
    {
        public enum EducationSubmissionstring
        {
            Working,
            Submitted,
            Released,
            Returned,
            Reassigned,
        }

        public string? Id { get; set; }
        public EducationSubmissionRecipient? Recipient { get; set; }
        public IdentitySet? ReturnedBy { get; set; }
        public DateTimeOffset? ReturnedDateTime { get; set; }
        public string? ResourcesFolderUrl { get; set; }
        public EducationSubmissionstring Status { get; set; }
        public IdentitySet? SubmittedBy { get; set; }
        public DateTimeOffset? SubmittedDateTime { get; set; }
        public IdentitySet? UnsubmittedBy { get; set; }
        public DateTimeOffset? UnsubmittedDateTime { get; set; }
        public IdentitySet? ReassignedBy { get; set; }
        public DateTimeOffset? ReassignedDateTime { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-return?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionReturnResponse> EducationsubmissionReturnAsync()
        {
            var p = new EducationsubmissionReturnParameter();
            return await this.SendAsync<EducationsubmissionReturnParameter, EducationsubmissionReturnResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-return?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionReturnResponse> EducationsubmissionReturnAsync(CancellationToken cancellationToken)
        {
            var p = new EducationsubmissionReturnParameter();
            return await this.SendAsync<EducationsubmissionReturnParameter, EducationsubmissionReturnResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-return?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionReturnResponse> EducationsubmissionReturnAsync(EducationsubmissionReturnParameter parameter)
        {
            return await this.SendAsync<EducationsubmissionReturnParameter, EducationsubmissionReturnResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-return?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionReturnResponse> EducationsubmissionReturnAsync(EducationsubmissionReturnParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationsubmissionReturnParameter, EducationsubmissionReturnResponse>(parameter, cancellationToken);
        }
    }
}
