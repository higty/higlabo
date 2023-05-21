using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/learningcontent-get?view=graph-rest-1.0
    /// </summary>
    public partial class LearningContentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? LearningProviderId { get; set; }
            public string? LearningContentId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.EmployeeExperience_LearningProviders_LearningProviderId_LearningContents_LearningContentId: return $"/employeeExperience/learningProviders/{LearningProviderId}/learningContents/{LearningContentId}";
                    case ApiPath.EmployeeExperience_LearningProviders_LearningProviderId_LearningContents: return $"/employeeExperience/learningProviders/{LearningProviderId}/learningContents";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AdditionalTags,
            ContentWebUrl,
            Contributors,
            CreatedDateTime,
            Description,
            Duration,
            ExternalId,
            Format,
            Id,
            IsActive,
            IsPremium,
            IsSearchable,
            LanguageTag,
            LastModifiedDateTime,
            NumberOfPages,
            SkillTags,
            SourceName,
            ThumbnailWebUrl,
            Title,
        }
        public enum ApiPath
        {
            EmployeeExperience_LearningProviders_LearningProviderId_LearningContents_LearningContentId,
            EmployeeExperience_LearningProviders_LearningProviderId_LearningContents,
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
    public partial class LearningContentGetResponse : RestApiResponse
    {
        public String[]? AdditionalTags { get; set; }
        public string? ContentWebUrl { get; set; }
        public String[]? Contributors { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? Duration { get; set; }
        public string? ExternalId { get; set; }
        public string? Format { get; set; }
        public string? Id { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPremium { get; set; }
        public bool? IsSearchable { get; set; }
        public string? LanguageTag { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public Int32? NumberOfPages { get; set; }
        public String[]? SkillTags { get; set; }
        public string? SourceName { get; set; }
        public string? ThumbnailWebUrl { get; set; }
        public string? Title { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/learningcontent-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/learningcontent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<LearningContentGetResponse> LearningContentGetAsync()
        {
            var p = new LearningContentGetParameter();
            return await this.SendAsync<LearningContentGetParameter, LearningContentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/learningcontent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<LearningContentGetResponse> LearningContentGetAsync(CancellationToken cancellationToken)
        {
            var p = new LearningContentGetParameter();
            return await this.SendAsync<LearningContentGetParameter, LearningContentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/learningcontent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<LearningContentGetResponse> LearningContentGetAsync(LearningContentGetParameter parameter)
        {
            return await this.SendAsync<LearningContentGetParameter, LearningContentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/learningcontent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<LearningContentGetResponse> LearningContentGetAsync(LearningContentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<LearningContentGetParameter, LearningContentGetResponse>(parameter, cancellationToken);
        }
    }
}
