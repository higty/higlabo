using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationsubmissionresourceGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Classes_ClassId_Assignments_AssignmentId_Submissions_SubmissionId_Resources_ResourceId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_ClassId_Assignments_AssignmentId_Submissions_SubmissionId_Resources_ResourceId: return $"/education/classes/{ClassId}/assignments/{AssignmentId}/submissions/{SubmissionId}/resources/{ResourceId}";
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
        public string ClassId { get; set; }
        public string AssignmentId { get; set; }
        public string SubmissionId { get; set; }
        public string ResourceId { get; set; }
    }
    public partial class EducationsubmissionresourceGetResponse : RestApiResponse
    {
        public string? AssignmentResourceUrl { get; set; }
        public string? Id { get; set; }
        public EducationResource? Resource { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmissionresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionresourceGetResponse> EducationsubmissionresourceGetAsync()
        {
            var p = new EducationsubmissionresourceGetParameter();
            return await this.SendAsync<EducationsubmissionresourceGetParameter, EducationsubmissionresourceGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmissionresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionresourceGetResponse> EducationsubmissionresourceGetAsync(CancellationToken cancellationToken)
        {
            var p = new EducationsubmissionresourceGetParameter();
            return await this.SendAsync<EducationsubmissionresourceGetParameter, EducationsubmissionresourceGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmissionresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionresourceGetResponse> EducationsubmissionresourceGetAsync(EducationsubmissionresourceGetParameter parameter)
        {
            return await this.SendAsync<EducationsubmissionresourceGetParameter, EducationsubmissionresourceGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmissionresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionresourceGetResponse> EducationsubmissionresourceGetAsync(EducationsubmissionresourceGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationsubmissionresourceGetParameter, EducationsubmissionresourceGetResponse>(parameter, cancellationToken);
        }
    }
}
