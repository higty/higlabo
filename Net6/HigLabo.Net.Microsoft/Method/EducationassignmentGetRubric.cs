using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationassignmentGetRubricParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Classes_Acdefc6b2dc64e71B1e96d9810ab1793_Assignments_Cf6005fc9e1344a2A6acA53322006454_Rubric,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_Acdefc6b2dc64e71B1e96d9810ab1793_Assignments_Cf6005fc9e1344a2A6acA53322006454_Rubric: return $"/education/classes/acdefc6b-2dc6-4e71-b1e9-6d9810ab1793/assignments/cf6005fc-9e13-44a2-a6ac-a53322006454/rubric";
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
    }
    public partial class EducationassignmentGetRubricResponse : RestApiResponse
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
        public async Task<EducationassignmentGetRubricResponse> EducationassignmentGetRubricAsync()
        {
            var p = new EducationassignmentGetRubricParameter();
            return await this.SendAsync<EducationassignmentGetRubricParameter, EducationassignmentGetRubricResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-get-rubric?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentGetRubricResponse> EducationassignmentGetRubricAsync(CancellationToken cancellationToken)
        {
            var p = new EducationassignmentGetRubricParameter();
            return await this.SendAsync<EducationassignmentGetRubricParameter, EducationassignmentGetRubricResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-get-rubric?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentGetRubricResponse> EducationassignmentGetRubricAsync(EducationassignmentGetRubricParameter parameter)
        {
            return await this.SendAsync<EducationassignmentGetRubricParameter, EducationassignmentGetRubricResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-get-rubric?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentGetRubricResponse> EducationassignmentGetRubricAsync(EducationassignmentGetRubricParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationassignmentGetRubricParameter, EducationassignmentGetRubricResponse>(parameter, cancellationToken);
        }
    }
}
