using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationassignmentresourceGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Classes_ClassId_Assignments_AssignmentId_Resources_ResourceId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_ClassId_Assignments_AssignmentId_Resources_ResourceId: return $"/education/classes/{ClassId}/assignments/{AssignmentId}/resources/{ResourceId}";
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
        public string ResourceId { get; set; }
    }
    public partial class EducationassignmentresourceGetResponse : RestApiResponse
    {
        public bool? DistributeForStudentWork { get; set; }
        public string? Id { get; set; }
        public EducationResource? Resource { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignmentresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentresourceGetResponse> EducationassignmentresourceGetAsync()
        {
            var p = new EducationassignmentresourceGetParameter();
            return await this.SendAsync<EducationassignmentresourceGetParameter, EducationassignmentresourceGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignmentresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentresourceGetResponse> EducationassignmentresourceGetAsync(CancellationToken cancellationToken)
        {
            var p = new EducationassignmentresourceGetParameter();
            return await this.SendAsync<EducationassignmentresourceGetParameter, EducationassignmentresourceGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignmentresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentresourceGetResponse> EducationassignmentresourceGetAsync(EducationassignmentresourceGetParameter parameter)
        {
            return await this.SendAsync<EducationassignmentresourceGetParameter, EducationassignmentresourceGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignmentresource-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentresourceGetResponse> EducationassignmentresourceGetAsync(EducationassignmentresourceGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationassignmentresourceGetParameter, EducationassignmentresourceGetResponse>(parameter, cancellationToken);
        }
    }
}
