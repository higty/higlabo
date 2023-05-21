using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-get?view=graph-rest-1.0
    /// </summary>
    public partial class EducationAssignmentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ClassesId { get; set; }
            public string? AssignmentsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_Id_Assignments_Id: return $"/education/classes/{ClassesId}/assignments/{AssignmentsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AddedStudentAction,
            AddToCalendarAction,
            AllowLateSubmissions,
            AllowStudentsToAddResourcesToSubmission,
            AssignDateTime,
            AssignTo,
            AssignedDateTime,
            ClassId,
            CloseDateTime,
            CreatedBy,
            CreatedDateTime,
            DisplayName,
            DueDateTime,
            FeedbackResourcesFolderUrl,
            Grading,
            Id,
            Instructions,
            LastModifiedBy,
            LastModifiedDateTime,
            NotificationChannelUrl,
            ResourcesFolderUrl,
            Status,
            WebUrl,
            Categories,
            Resources,
            Rubric,
            Submissions,
        }
        public enum ApiPath
        {
            Education_Classes_Id_Assignments_Id,
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
    public partial class EducationAssignmentGetResponse : RestApiResponse
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
        public string? FeedbackResourcesFolderUrl { get; set; }
        public EducationAssignmentGradeType? Grading { get; set; }
        public string? Id { get; set; }
        public ItemBody? Instructions { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? NotificationChannelUrl { get; set; }
        public string? ResourcesFolderUrl { get; set; }
        public EducationAssignmentstring Status { get; set; }
        public string? WebUrl { get; set; }
        public EducationCategory[]? Categories { get; set; }
        public EducationAssignmentResource[]? Resources { get; set; }
        public EducationRubric? Rubric { get; set; }
        public EducationSubmission[]? Submissions { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentGetResponse> EducationAssignmentGetAsync()
        {
            var p = new EducationAssignmentGetParameter();
            return await this.SendAsync<EducationAssignmentGetParameter, EducationAssignmentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentGetResponse> EducationAssignmentGetAsync(CancellationToken cancellationToken)
        {
            var p = new EducationAssignmentGetParameter();
            return await this.SendAsync<EducationAssignmentGetParameter, EducationAssignmentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentGetResponse> EducationAssignmentGetAsync(EducationAssignmentGetParameter parameter)
        {
            return await this.SendAsync<EducationAssignmentGetParameter, EducationAssignmentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentGetResponse> EducationAssignmentGetAsync(EducationAssignmentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationAssignmentGetParameter, EducationAssignmentGetResponse>(parameter, cancellationToken);
        }
    }
}
