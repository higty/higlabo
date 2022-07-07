using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationassignmentListSubmissionsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Classes_Id_Assignments_Id_Submissions,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_Id_Assignments_Id_Submissions: return $"/education/classes/{ClassesId}/assignments/{AssignmentsId}/submissions";
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
    public partial class EducationassignmentListSubmissionsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/educationsubmission?view=graph-rest-1.0
        /// </summary>
        public partial class EducationSubmission
        {
            public enum EducationSubmissionstring
            {
                Working,
                Submitted,
                Released,
                Returned,
                Reassigned,
            }

            public string? Id { get; set; }
            public EducationSubmissionRecipient? Recipient { get; set; }
            public IdentitySet? ReturnedBy { get; set; }
            public DateTimeOffset? ReturnedDateTime { get; set; }
            public string? ResourcesFolderUrl { get; set; }
            public EducationSubmissionstring Status { get; set; }
            public IdentitySet? SubmittedBy { get; set; }
            public DateTimeOffset? SubmittedDateTime { get; set; }
            public IdentitySet? UnsubmittedBy { get; set; }
            public DateTimeOffset? UnsubmittedDateTime { get; set; }
            public IdentitySet? ReassignedBy { get; set; }
            public DateTimeOffset? ReassignedDateTime { get; set; }
        }

        public EducationSubmission[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-list-submissions?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentListSubmissionsResponse> EducationassignmentListSubmissionsAsync()
        {
            var p = new EducationassignmentListSubmissionsParameter();
            return await this.SendAsync<EducationassignmentListSubmissionsParameter, EducationassignmentListSubmissionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-list-submissions?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentListSubmissionsResponse> EducationassignmentListSubmissionsAsync(CancellationToken cancellationToken)
        {
            var p = new EducationassignmentListSubmissionsParameter();
            return await this.SendAsync<EducationassignmentListSubmissionsParameter, EducationassignmentListSubmissionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-list-submissions?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentListSubmissionsResponse> EducationassignmentListSubmissionsAsync(EducationassignmentListSubmissionsParameter parameter)
        {
            return await this.SendAsync<EducationassignmentListSubmissionsParameter, EducationassignmentListSubmissionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-list-submissions?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentListSubmissionsResponse> EducationassignmentListSubmissionsAsync(EducationassignmentListSubmissionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationassignmentListSubmissionsParameter, EducationassignmentListSubmissionsResponse>(parameter, cancellationToken);
        }
    }
}
