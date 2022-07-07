using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationuserPostRubricsParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class EducationuserPostRubricsResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-post-rubrics?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserPostRubricsResponse> EducationuserPostRubricsAsync()
        {
            var p = new EducationuserPostRubricsParameter();
            return await this.SendAsync<EducationuserPostRubricsParameter, EducationuserPostRubricsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-post-rubrics?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserPostRubricsResponse> EducationuserPostRubricsAsync(CancellationToken cancellationToken)
        {
            var p = new EducationuserPostRubricsParameter();
            return await this.SendAsync<EducationuserPostRubricsParameter, EducationuserPostRubricsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-post-rubrics?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserPostRubricsResponse> EducationuserPostRubricsAsync(EducationuserPostRubricsParameter parameter)
        {
            return await this.SendAsync<EducationuserPostRubricsParameter, EducationuserPostRubricsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-post-rubrics?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserPostRubricsResponse> EducationuserPostRubricsAsync(EducationuserPostRubricsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationuserPostRubricsParameter, EducationuserPostRubricsResponse>(parameter, cancellationToken);
        }
    }
}
