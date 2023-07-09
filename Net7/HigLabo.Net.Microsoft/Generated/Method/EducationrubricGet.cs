using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationrubric-get?view=graph-rest-1.0
    /// </summary>
    public partial class EducationrubricGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Me_Rubrics_Id: return $"/education/me/rubrics/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Me_Rubrics_Id,
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
    public partial class EducationrubricGetResponse : RestApiResponse
    {
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public ItemBody? Description { get; set; }
        public string? DisplayName { get; set; }
        public EducationAssignmentGradeType? Grading { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public RubricLevel[]? Levels { get; set; }
        public RubricQuality[]? Qualities { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationrubric-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationrubric-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationrubricGetResponse> EducationrubricGetAsync()
        {
            var p = new EducationrubricGetParameter();
            return await this.SendAsync<EducationrubricGetParameter, EducationrubricGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationrubric-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationrubricGetResponse> EducationrubricGetAsync(CancellationToken cancellationToken)
        {
            var p = new EducationrubricGetParameter();
            return await this.SendAsync<EducationrubricGetParameter, EducationrubricGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationrubric-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationrubricGetResponse> EducationrubricGetAsync(EducationrubricGetParameter parameter)
        {
            return await this.SendAsync<EducationrubricGetParameter, EducationrubricGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationrubric-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationrubricGetResponse> EducationrubricGetAsync(EducationrubricGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationrubricGetParameter, EducationrubricGetResponse>(parameter, cancellationToken);
        }
    }
}
