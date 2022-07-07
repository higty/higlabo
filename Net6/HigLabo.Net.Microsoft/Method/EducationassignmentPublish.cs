using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationassignmentPublishParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Education_Classes_Id_Assignments_Id_Publish,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_Id_Assignments_Id_Publish: return $"/education/classes/{ClassesId}/assignments/{AssignmentsId}/publish";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string ClassesId { get; set; }
        public string AssignmentsId { get; set; }
    }
    public partial class EducationassignmentPublishResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-publish?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentPublishResponse> EducationassignmentPublishAsync()
        {
            var p = new EducationassignmentPublishParameter();
            return await this.SendAsync<EducationassignmentPublishParameter, EducationassignmentPublishResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-publish?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentPublishResponse> EducationassignmentPublishAsync(CancellationToken cancellationToken)
        {
            var p = new EducationassignmentPublishParameter();
            return await this.SendAsync<EducationassignmentPublishParameter, EducationassignmentPublishResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-publish?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentPublishResponse> EducationassignmentPublishAsync(EducationassignmentPublishParameter parameter)
        {
            return await this.SendAsync<EducationassignmentPublishParameter, EducationassignmentPublishResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-publish?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentPublishResponse> EducationassignmentPublishAsync(EducationassignmentPublishParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationassignmentPublishParameter, EducationassignmentPublishResponse>(parameter, cancellationToken);
        }
    }
}
