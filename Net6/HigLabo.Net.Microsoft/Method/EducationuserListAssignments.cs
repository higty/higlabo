using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationuserListAssignmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Me_Assignments,
            Education_Users_UserId_Assignments,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Me_Assignments: return $"/education/me/assignments";
                    case ApiPath.Education_Users_UserId_Assignments: return $"/education/users/{UserId}/assignments";
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
        public string UserId { get; set; }
    }
    public partial class EducationuserListAssignmentsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/educationassignment?view=graph-rest-1.0
        /// </summary>
        public partial class EducationAssignment
        {
            public enum EducationAssignmentEducationAddToCalendarOptions
            {
                None,
                StudentsAndPublisher,
                StudentsAndTeamOwners,
                UnknownFutureValue,
                StudentsOnly,
            }
            public enum EducationAssignmentstring
            {
                Draft,
                Scheduled,
                Published,
                Assigned,
            }

            public string? Id { get; set; }
            public string? AddedStudentAction { get; set; }
            public EducationAssignmentEducationAddToCalendarOptions AddToCalendarAction { get; set; }
            public bool? AllowLateSubmissions { get; set; }
            public bool? AllowStudentsToAddResourcesToSubmission { get; set; }
            public DateTimeOffset? AssignDateTime { get; set; }
            public EducationAssignmentRecipient? AssignTo { get; set; }
            public DateTimeOffset? AssignedDateTime { get; set; }
            public string? ClassId { get; set; }
            public DateTimeOffset? CloseDateTime { get; set; }
            public IdentitySet? CreatedBy { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? DisplayName { get; set; }
            public DateTimeOffset? DueDateTime { get; set; }
            public EducationAssignmentGradeType? Grading { get; set; }
            public ItemBody? Instructions { get; set; }
            public IdentitySet? LastModifiedBy { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public string? NotificationChannelUrl { get; set; }
            public EducationAssignmentstring Status { get; set; }
            public string? WebUrl { get; set; }
            public string? ResourcesFolderUrl { get; set; }
        }

        public EducationAssignment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list-assignments?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserListAssignmentsResponse> EducationuserListAssignmentsAsync()
        {
            var p = new EducationuserListAssignmentsParameter();
            return await this.SendAsync<EducationuserListAssignmentsParameter, EducationuserListAssignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list-assignments?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserListAssignmentsResponse> EducationuserListAssignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new EducationuserListAssignmentsParameter();
            return await this.SendAsync<EducationuserListAssignmentsParameter, EducationuserListAssignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list-assignments?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserListAssignmentsResponse> EducationuserListAssignmentsAsync(EducationuserListAssignmentsParameter parameter)
        {
            return await this.SendAsync<EducationuserListAssignmentsParameter, EducationuserListAssignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list-assignments?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserListAssignmentsResponse> EducationuserListAssignmentsAsync(EducationuserListAssignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationuserListAssignmentsParameter, EducationuserListAssignmentsResponse>(parameter, cancellationToken);
        }
    }
}
