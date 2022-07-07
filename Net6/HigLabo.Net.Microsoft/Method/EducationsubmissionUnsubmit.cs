using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationsubmissionUnsubmitParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Education_Classes_ClassId_Assignments_AssignmentId_Submissions_SubmissionId_Unsubmit,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_ClassId_Assignments_AssignmentId_Submissions_SubmissionId_Unsubmit: return $"/education/classes/{ClassId}/assignments/{AssignmentId}/submissions/{SubmissionId}/unsubmit";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string ClassId { get; set; }
        public string AssignmentId { get; set; }
        public string SubmissionId { get; set; }
    }
    public partial class EducationsubmissionUnsubmitResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-unsubmit?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionUnsubmitResponse> EducationsubmissionUnsubmitAsync()
        {
            var p = new EducationsubmissionUnsubmitParameter();
            return await this.SendAsync<EducationsubmissionUnsubmitParameter, EducationsubmissionUnsubmitResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-unsubmit?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionUnsubmitResponse> EducationsubmissionUnsubmitAsync(CancellationToken cancellationToken)
        {
            var p = new EducationsubmissionUnsubmitParameter();
            return await this.SendAsync<EducationsubmissionUnsubmitParameter, EducationsubmissionUnsubmitResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-unsubmit?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionUnsubmitResponse> EducationsubmissionUnsubmitAsync(EducationsubmissionUnsubmitParameter parameter)
        {
            return await this.SendAsync<EducationsubmissionUnsubmitParameter, EducationsubmissionUnsubmitResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-unsubmit?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionUnsubmitResponse> EducationsubmissionUnsubmitAsync(EducationsubmissionUnsubmitParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationsubmissionUnsubmitParameter, EducationsubmissionUnsubmitResponse>(parameter, cancellationToken);
        }
    }
}
