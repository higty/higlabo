using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationuserListRubricsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Me_Rubrics,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Me_Rubrics: return $"/education/me/rubrics";
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
    public partial class EducationuserListRubricsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/educationrubric?view=graph-rest-1.0
        /// </summary>
        public partial class EducationRubric
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

        public EducationRubric[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list-rubrics?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserListRubricsResponse> EducationuserListRubricsAsync()
        {
            var p = new EducationuserListRubricsParameter();
            return await this.SendAsync<EducationuserListRubricsParameter, EducationuserListRubricsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list-rubrics?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserListRubricsResponse> EducationuserListRubricsAsync(CancellationToken cancellationToken)
        {
            var p = new EducationuserListRubricsParameter();
            return await this.SendAsync<EducationuserListRubricsParameter, EducationuserListRubricsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list-rubrics?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserListRubricsResponse> EducationuserListRubricsAsync(EducationuserListRubricsParameter parameter)
        {
            return await this.SendAsync<EducationuserListRubricsParameter, EducationuserListRubricsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list-rubrics?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserListRubricsResponse> EducationuserListRubricsAsync(EducationuserListRubricsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationuserListRubricsParameter, EducationuserListRubricsResponse>(parameter, cancellationToken);
        }
    }
}
