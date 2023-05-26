using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-list-assignments?view=graph-rest-1.0
    /// </summary>
    public partial class EducationclassListAssignmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_Id_Assignments: return $"/education/classes/{Id}/assignments";
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
            Education_Classes_Id_Assignments,
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
    public partial class EducationclassListAssignmentsResponse : RestApiResponse
    {
        public EducationAssignment[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-list-assignments?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-list-assignments?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassListAssignmentsResponse> EducationclassListAssignmentsAsync()
        {
            var p = new EducationclassListAssignmentsParameter();
            return await this.SendAsync<EducationclassListAssignmentsParameter, EducationclassListAssignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-list-assignments?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassListAssignmentsResponse> EducationclassListAssignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new EducationclassListAssignmentsParameter();
            return await this.SendAsync<EducationclassListAssignmentsParameter, EducationclassListAssignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-list-assignments?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassListAssignmentsResponse> EducationclassListAssignmentsAsync(EducationclassListAssignmentsParameter parameter)
        {
            return await this.SendAsync<EducationclassListAssignmentsParameter, EducationclassListAssignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-list-assignments?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassListAssignmentsResponse> EducationclassListAssignmentsAsync(EducationclassListAssignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationclassListAssignmentsParameter, EducationclassListAssignmentsResponse>(parameter, cancellationToken);
        }
    }
}
