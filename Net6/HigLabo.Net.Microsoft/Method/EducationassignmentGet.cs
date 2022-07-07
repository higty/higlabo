using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationassignmentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Classes_Id_Assignments_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_Id_Assignments_Id: return $"/education/classes/{ClassesId}/assignments/{AssignmentsId}";
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
        public string ClassesId { get; set; }
        public string AssignmentsId { get; set; }
    }
    public partial class EducationassignmentGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentGetResponse> EducationassignmentGetAsync()
        {
            var p = new EducationassignmentGetParameter();
            return await this.SendAsync<EducationassignmentGetParameter, EducationassignmentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentGetResponse> EducationassignmentGetAsync(CancellationToken cancellationToken)
        {
            var p = new EducationassignmentGetParameter();
            return await this.SendAsync<EducationassignmentGetParameter, EducationassignmentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentGetResponse> EducationassignmentGetAsync(EducationassignmentGetParameter parameter)
        {
            return await this.SendAsync<EducationassignmentGetParameter, EducationassignmentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentGetResponse> EducationassignmentGetAsync(EducationassignmentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationassignmentGetParameter, EducationassignmentGetResponse>(parameter, cancellationToken);
        }
    }
}
