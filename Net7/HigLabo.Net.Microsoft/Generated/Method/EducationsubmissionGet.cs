using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationsubmission-get?view=graph-rest-1.0
    /// </summary>
    public partial class EducationsubmissionGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ClassId { get; set; }
            public string? AssignmentId { get; set; }
            public string? SubmissionId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_ClassId_Assignments_AssignmentId_Submissions_SubmissionId: return $"/education/classes/{ClassId}/assignments/{AssignmentId}/submissions/{SubmissionId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Classes_ClassId_Assignments_AssignmentId_Submissions_SubmissionId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    public partial class EducationsubmissionGetResponse : RestApiResponse
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
        public IdentitySet? ReassignedBy { get; set; }
        public DateTimeOffset? ReassignedDateTime { get; set; }
        public EducationSubmissionRecipient? Recipient { get; set; }
        public string? ResourcesFolderUrl { get; set; }
        public IdentitySet? ReturnedBy { get; set; }
        public DateTimeOffset? ReturnedDateTime { get; set; }
        public EducationSubmissionstring Status { get; set; }
        public IdentitySet? SubmittedBy { get; set; }
        public DateTimeOffset? SubmittedDateTime { get; set; }
        public IdentitySet? UnsubmittedBy { get; set; }
        public DateTimeOffset? UnsubmittedDateTime { get; set; }
        public EducationOutcome? Outcomes { get; set; }
        public EducationSubmissionResource[]? Resources { get; set; }
        public EducationSubmissionResource[]? SubmittedResources { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationsubmission-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationsubmission-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationsubmissionGetResponse> EducationsubmissionGetAsync()
        {
            var p = new EducationsubmissionGetParameter();
            return await this.SendAsync<EducationsubmissionGetParameter, EducationsubmissionGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationsubmission-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationsubmissionGetResponse> EducationsubmissionGetAsync(CancellationToken cancellationToken)
        {
            var p = new EducationsubmissionGetParameter();
            return await this.SendAsync<EducationsubmissionGetParameter, EducationsubmissionGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationsubmission-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationsubmissionGetResponse> EducationsubmissionGetAsync(EducationsubmissionGetParameter parameter)
        {
            return await this.SendAsync<EducationsubmissionGetParameter, EducationsubmissionGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationsubmission-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationsubmissionGetResponse> EducationsubmissionGetAsync(EducationsubmissionGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationsubmissionGetParameter, EducationsubmissionGetResponse>(parameter, cancellationToken);
        }
    }
}
