using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationAssignmentGetRubricParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_Acdefc6b2dc64e71B1e96d9810ab1793_Assignments_Cf6005fc9e1344a2A6acA53322006454_Rubric: return $"/education/classes/acdefc6b-2dc6-4e71-b1e9-6d9810ab1793/assignments/cf6005fc-9e13-44a2-a6ac-a53322006454/rubric";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
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
            Grading,
            Instructions,
            LastModifiedBy,
            LastModifiedDateTime,
            NotificationChannelUrl,
            Status,
            WebUrl,
            ResourcesFolderUrl,
            Resources,
            Submissions,
            Categories,
            Rubric,
        }
        public enum ApiPath
        {
            Education_Classes_Acdefc6b2dc64e71B1e96d9810ab1793_Assignments_Cf6005fc9e1344a2A6acA53322006454_Rubric,
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
        public string? Id { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public ItemBody? Description { get; set; }
        public string? DisplayName { get; set; }
        public EducationAssignmentGradeType? Grading { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public RubricLevel[]? Levels { get; set; }
        public RubricQuality[]? Qualities { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-get-rubric?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentGetRubricResponse> EducationAssignmentGetRubricAsync()
        {
            var p = new EducationAssignmentGetRubricParameter();
            return await this.SendAsync<EducationAssignmentGetRubricParameter, EducationAssignmentGetRubricResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-get-rubric?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentGetRubricResponse> EducationAssignmentGetRubricAsync(CancellationToken cancellationToken)
        {
            var p = new EducationAssignmentGetRubricParameter();
            return await this.SendAsync<EducationAssignmentGetRubricParameter, EducationAssignmentGetRubricResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-get-rubric?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentGetRubricResponse> EducationAssignmentGetRubricAsync(EducationAssignmentGetRubricParameter parameter)
        {
            return await this.SendAsync<EducationAssignmentGetRubricParameter, EducationAssignmentGetRubricResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-get-rubric?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentGetRubricResponse> EducationAssignmentGetRubricAsync(EducationAssignmentGetRubricParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationAssignmentGetRubricParameter, EducationAssignmentGetRubricResponse>(parameter, cancellationToken);
        }
    }
}
