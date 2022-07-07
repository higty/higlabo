using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationrubricGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Me_Rubrics_Ceb3863e69124ea9Ac413c2bb7b6672d,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Me_Rubrics_Ceb3863e69124ea9Ac413c2bb7b6672d: return $"/education/me/rubrics/ceb3863e-6912-4ea9-ac41-3c2bb7b6672d";
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
    public partial class EducationrubricGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/educationrubric-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationrubricGetResponse> EducationrubricGetAsync()
        {
            var p = new EducationrubricGetParameter();
            return await this.SendAsync<EducationrubricGetParameter, EducationrubricGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationrubric-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationrubricGetResponse> EducationrubricGetAsync(CancellationToken cancellationToken)
        {
            var p = new EducationrubricGetParameter();
            return await this.SendAsync<EducationrubricGetParameter, EducationrubricGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationrubric-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationrubricGetResponse> EducationrubricGetAsync(EducationrubricGetParameter parameter)
        {
            return await this.SendAsync<EducationrubricGetParameter, EducationrubricGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationrubric-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationrubricGetResponse> EducationrubricGetAsync(EducationrubricGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationrubricGetParameter, EducationrubricGetResponse>(parameter, cancellationToken);
        }
    }
}
