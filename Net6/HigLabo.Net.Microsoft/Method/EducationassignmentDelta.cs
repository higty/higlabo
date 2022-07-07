using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationassignmentDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Classes_EducationClassId_Assignments_Delta,
            Education_Classes_EducationClassId_Members_EducationUserId_Assignments_Delta,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_EducationClassId_Assignments_Delta: return $"/education/classes/{EducationClassId}/assignments/delta";
                    case ApiPath.Education_Classes_EducationClassId_Members_EducationUserId_Assignments_Delta: return $"/education/classes/{EducationClassId}/members/{EducationUserId}/assignments/delta";
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
        public string EducationClassId { get; set; }
        public string EducationUserId { get; set; }
    }
    public partial class EducationassignmentDeltaResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentDeltaResponse> EducationassignmentDeltaAsync()
        {
            var p = new EducationassignmentDeltaParameter();
            return await this.SendAsync<EducationassignmentDeltaParameter, EducationassignmentDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentDeltaResponse> EducationassignmentDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new EducationassignmentDeltaParameter();
            return await this.SendAsync<EducationassignmentDeltaParameter, EducationassignmentDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentDeltaResponse> EducationassignmentDeltaAsync(EducationassignmentDeltaParameter parameter)
        {
            return await this.SendAsync<EducationassignmentDeltaParameter, EducationassignmentDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentDeltaResponse> EducationassignmentDeltaAsync(EducationassignmentDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationassignmentDeltaParameter, EducationassignmentDeltaResponse>(parameter, cancellationToken);
        }
    }
}
