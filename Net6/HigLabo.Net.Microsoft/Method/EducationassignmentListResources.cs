using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationassignmentListResourcesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Classes_Id_Assignments_Id_Resources,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_Id_Assignments_Id_Resources: return $"/education/classes/{ClassesId}/assignments/{AssignmentsId}/resources";
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
    public partial class EducationassignmentListResourcesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/educationassignmentresource?view=graph-rest-1.0
        /// </summary>
        public partial class EducationAssignmentResource
        {
            public bool? DistributeForStudentWork { get; set; }
            public string? Id { get; set; }
            public EducationResource? Resource { get; set; }
        }

        public EducationAssignmentResource[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-list-resources?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentListResourcesResponse> EducationassignmentListResourcesAsync()
        {
            var p = new EducationassignmentListResourcesParameter();
            return await this.SendAsync<EducationassignmentListResourcesParameter, EducationassignmentListResourcesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-list-resources?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentListResourcesResponse> EducationassignmentListResourcesAsync(CancellationToken cancellationToken)
        {
            var p = new EducationassignmentListResourcesParameter();
            return await this.SendAsync<EducationassignmentListResourcesParameter, EducationassignmentListResourcesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-list-resources?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentListResourcesResponse> EducationassignmentListResourcesAsync(EducationassignmentListResourcesParameter parameter)
        {
            return await this.SendAsync<EducationassignmentListResourcesParameter, EducationassignmentListResourcesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-list-resources?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentListResourcesResponse> EducationassignmentListResourcesAsync(EducationassignmentListResourcesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationassignmentListResourcesParameter, EducationassignmentListResourcesResponse>(parameter, cancellationToken);
        }
    }
}
