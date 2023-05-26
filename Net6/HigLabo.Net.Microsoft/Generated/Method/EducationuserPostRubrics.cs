using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationuser-post-rubrics?view=graph-rest-1.0
    /// </summary>
    public partial class EducationUserPostRubricsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Me_Rubrics: return $"/education/me/rubrics";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Education_Me_Rubrics,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
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
    public partial class EducationUserPostRubricsResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/educationuser-post-rubrics?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationuser-post-rubrics?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserPostRubricsResponse> EducationUserPostRubricsAsync()
        {
            var p = new EducationUserPostRubricsParameter();
            return await this.SendAsync<EducationUserPostRubricsParameter, EducationUserPostRubricsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationuser-post-rubrics?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserPostRubricsResponse> EducationUserPostRubricsAsync(CancellationToken cancellationToken)
        {
            var p = new EducationUserPostRubricsParameter();
            return await this.SendAsync<EducationUserPostRubricsParameter, EducationUserPostRubricsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationuser-post-rubrics?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserPostRubricsResponse> EducationUserPostRubricsAsync(EducationUserPostRubricsParameter parameter)
        {
            return await this.SendAsync<EducationUserPostRubricsParameter, EducationUserPostRubricsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationuser-post-rubrics?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserPostRubricsResponse> EducationUserPostRubricsAsync(EducationUserPostRubricsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationUserPostRubricsParameter, EducationUserPostRubricsResponse>(parameter, cancellationToken);
        }
    }
}
