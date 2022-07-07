using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationsubmissionListSubmittedresourcesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Classes_Id_Assignments_Id_Submissions_Id_SubmittedResources,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_Id_Assignments_Id_Submissions_Id_SubmittedResources: return $"/education/classes/{ClassesId}/assignments/{AssignmentsId}/submissions/{SubmissionsId}/submittedResources";
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
        public string SubmissionsId { get; set; }
    }
    public partial class EducationsubmissionListSubmittedresourcesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/educationsubmissionresource?view=graph-rest-1.0
        /// </summary>
        public partial class EducationSubmissionResource
        {
            public string? AssignmentResourceUrl { get; set; }
            public string? Id { get; set; }
            public EducationResource? Resource { get; set; }
        }

        public EducationSubmissionResource[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-list-submittedresources?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionListSubmittedresourcesResponse> EducationsubmissionListSubmittedresourcesAsync()
        {
            var p = new EducationsubmissionListSubmittedresourcesParameter();
            return await this.SendAsync<EducationsubmissionListSubmittedresourcesParameter, EducationsubmissionListSubmittedresourcesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-list-submittedresources?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionListSubmittedresourcesResponse> EducationsubmissionListSubmittedresourcesAsync(CancellationToken cancellationToken)
        {
            var p = new EducationsubmissionListSubmittedresourcesParameter();
            return await this.SendAsync<EducationsubmissionListSubmittedresourcesParameter, EducationsubmissionListSubmittedresourcesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-list-submittedresources?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionListSubmittedresourcesResponse> EducationsubmissionListSubmittedresourcesAsync(EducationsubmissionListSubmittedresourcesParameter parameter)
        {
            return await this.SendAsync<EducationsubmissionListSubmittedresourcesParameter, EducationsubmissionListSubmittedresourcesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-list-submittedresources?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionListSubmittedresourcesResponse> EducationsubmissionListSubmittedresourcesAsync(EducationsubmissionListSubmittedresourcesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationsubmissionListSubmittedresourcesParameter, EducationsubmissionListSubmittedresourcesResponse>(parameter, cancellationToken);
        }
    }
}
