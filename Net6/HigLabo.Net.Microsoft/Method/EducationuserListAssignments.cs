using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationUserListAssignmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Me_Assignments: return $"/education/me/assignments";
                    case ApiPath.Education_Users_UserId_Assignments: return $"/education/users/{UserId}/assignments";
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
            Education_Me_Assignments,
            Education_Users_UserId_Assignments,
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
    public partial class EducationUserListAssignmentsResponse : RestApiResponse
    {
        public EducationAssignment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list-assignments?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserListAssignmentsResponse> EducationUserListAssignmentsAsync()
        {
            var p = new EducationUserListAssignmentsParameter();
            return await this.SendAsync<EducationUserListAssignmentsParameter, EducationUserListAssignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list-assignments?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserListAssignmentsResponse> EducationUserListAssignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new EducationUserListAssignmentsParameter();
            return await this.SendAsync<EducationUserListAssignmentsParameter, EducationUserListAssignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list-assignments?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserListAssignmentsResponse> EducationUserListAssignmentsAsync(EducationUserListAssignmentsParameter parameter)
        {
            return await this.SendAsync<EducationUserListAssignmentsParameter, EducationUserListAssignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list-assignments?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserListAssignmentsResponse> EducationUserListAssignmentsAsync(EducationUserListAssignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationUserListAssignmentsParameter, EducationUserListAssignmentsResponse>(parameter, cancellationToken);
        }
    }
}
