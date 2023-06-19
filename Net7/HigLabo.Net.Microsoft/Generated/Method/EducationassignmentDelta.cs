using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-delta?view=graph-rest-1.0
    /// </summary>
    public partial class EducationAssignmentDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EducationClassId { get; set; }
            public string? EducationUserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_EducationClassId_Assignments_Delta: return $"/education/classes/{EducationClassId}/assignments/delta";
                    case ApiPath.Education_Classes_EducationClassId_Members_EducationUserId_Assignments_Delta: return $"/education/classes/{EducationClassId}/members/{EducationUserId}/assignments/delta";
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
            Education_Classes_EducationClassId_Assignments_Delta,
            Education_Classes_EducationClassId_Members_EducationUserId_Assignments_Delta,
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
    public partial class EducationAssignmentDeltaResponse : RestApiResponse
    {
        public EducationAssignment[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-delta?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentDeltaResponse> EducationAssignmentDeltaAsync()
        {
            var p = new EducationAssignmentDeltaParameter();
            return await this.SendAsync<EducationAssignmentDeltaParameter, EducationAssignmentDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentDeltaResponse> EducationAssignmentDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new EducationAssignmentDeltaParameter();
            return await this.SendAsync<EducationAssignmentDeltaParameter, EducationAssignmentDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentDeltaResponse> EducationAssignmentDeltaAsync(EducationAssignmentDeltaParameter parameter)
        {
            return await this.SendAsync<EducationAssignmentDeltaParameter, EducationAssignmentDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentDeltaResponse> EducationAssignmentDeltaAsync(EducationAssignmentDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationAssignmentDeltaParameter, EducationAssignmentDeltaResponse>(parameter, cancellationToken);
        }
    }
}
