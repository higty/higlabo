using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-publish?view=graph-rest-1.0
    /// </summary>
    public partial class EducationAssignmentPublishParameter : IRestApiParameter
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
                    case ApiPath.Education_Classes_Id_Assignments_Id_Publish: return $"/education/classes/{ClassesId}/assignments/{AssignmentsId}/publish";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

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
        public enum ApiPath
        {
            Education_Classes_Id_Assignments_Id_Publish,
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
    public partial class EducationAssignmentPublishResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-publish?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-publish?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentPublishResponse> EducationAssignmentPublishAsync()
        {
            var p = new EducationAssignmentPublishParameter();
            return await this.SendAsync<EducationAssignmentPublishParameter, EducationAssignmentPublishResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-publish?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentPublishResponse> EducationAssignmentPublishAsync(CancellationToken cancellationToken)
        {
            var p = new EducationAssignmentPublishParameter();
            return await this.SendAsync<EducationAssignmentPublishParameter, EducationAssignmentPublishResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-publish?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentPublishResponse> EducationAssignmentPublishAsync(EducationAssignmentPublishParameter parameter)
        {
            return await this.SendAsync<EducationAssignmentPublishParameter, EducationAssignmentPublishResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-publish?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentPublishResponse> EducationAssignmentPublishAsync(EducationAssignmentPublishParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationAssignmentPublishParameter, EducationAssignmentPublishResponse>(parameter, cancellationToken);
        }
    }
}
