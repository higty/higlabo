using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationsubmissionReassignParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string ClassesId { get; set; }
            public string AssignmentsId { get; set; }
            public string SubmissionsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_Id_Assignments_Id_Submissions_Id_Reassign: return $"/education/classes/{ClassesId}/assignments/{AssignmentsId}/submissions/{SubmissionsId}/reassign";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum EducationSubmissionstring
        {
            Working,
            Submitted,
            Released,
            Returned,
            Reassigned,
        }
        public enum ApiPath
        {
            Education_Classes_Id_Assignments_Id_Submissions_Id_Reassign,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
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
        public EducationSubmissionResource[]? Resources { get; set; }
        public EducationSubmissionResource[]? SubmittedResources { get; set; }
        public EducationOutcome? Outcomes { get; set; }
    }
    public partial class EducationsubmissionReassignResponse : RestApiResponse
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
        public EducationSubmissionResource[]? Resources { get; set; }
        public EducationSubmissionResource[]? SubmittedResources { get; set; }
        public EducationOutcome? Outcomes { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-reassign?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionReassignResponse> EducationsubmissionReassignAsync()
        {
            var p = new EducationsubmissionReassignParameter();
            return await this.SendAsync<EducationsubmissionReassignParameter, EducationsubmissionReassignResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-reassign?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionReassignResponse> EducationsubmissionReassignAsync(CancellationToken cancellationToken)
        {
            var p = new EducationsubmissionReassignParameter();
            return await this.SendAsync<EducationsubmissionReassignParameter, EducationsubmissionReassignResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-reassign?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionReassignResponse> EducationsubmissionReassignAsync(EducationsubmissionReassignParameter parameter)
        {
            return await this.SendAsync<EducationsubmissionReassignParameter, EducationsubmissionReassignResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-reassign?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionReassignResponse> EducationsubmissionReassignAsync(EducationsubmissionReassignParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationsubmissionReassignParameter, EducationsubmissionReassignResponse>(parameter, cancellationToken);
        }
    }
}
