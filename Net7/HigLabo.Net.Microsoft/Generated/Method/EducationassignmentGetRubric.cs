using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-get-rubric?view=graph-rest-1.0
    /// </summary>
    public partial class EducationAssignmentGetRubricParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Education_Classes_Id_Assignments_Id_Rubric: return $"/education/classes/{ClassesId}/assignments/{AssignmentsId}/rubric";
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
            Education_Classes_Id_Assignments_Id_Rubric,
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
    public partial class EducationAssignmentGetRubricResponse : RestApiResponse
    {
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public ItemBody? Description { get; set; }
        public string? DisplayName { get; set; }
        public EducationAssignmentGradeType? Grading { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public RubricLevel[]? Levels { get; set; }
        public RubricQuality[]? Qualities { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-get-rubric?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-get-rubric?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentGetRubricResponse> EducationAssignmentGetRubricAsync()
        {
            var p = new EducationAssignmentGetRubricParameter();
            return await this.SendAsync<EducationAssignmentGetRubricParameter, EducationAssignmentGetRubricResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-get-rubric?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentGetRubricResponse> EducationAssignmentGetRubricAsync(CancellationToken cancellationToken)
        {
            var p = new EducationAssignmentGetRubricParameter();
            return await this.SendAsync<EducationAssignmentGetRubricParameter, EducationAssignmentGetRubricResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-get-rubric?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentGetRubricResponse> EducationAssignmentGetRubricAsync(EducationAssignmentGetRubricParameter parameter)
        {
            return await this.SendAsync<EducationAssignmentGetRubricParameter, EducationAssignmentGetRubricResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-get-rubric?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentGetRubricResponse> EducationAssignmentGetRubricAsync(EducationAssignmentGetRubricParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationAssignmentGetRubricParameter, EducationAssignmentGetRubricResponse>(parameter, cancellationToken);
        }
    }
}
