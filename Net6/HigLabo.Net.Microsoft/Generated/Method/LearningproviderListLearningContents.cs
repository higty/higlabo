using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/learningprovider-list-learningcontents?view=graph-rest-1.0
    /// </summary>
    public partial class LearningproviderListLearningContentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? LearningProviderId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
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
    public partial class LearningproviderListLearningContentsResponse : RestApiResponse
    {
        public LearningContent[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/learningprovider-list-learningcontents?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/learningprovider-list-learningcontents?view=graph-rest-1.0
        /// </summary>
        public async Task<LearningproviderListLearningContentsResponse> LearningproviderListLearningContentsAsync()
        {
            var p = new LearningproviderListLearningContentsParameter();
            return await this.SendAsync<LearningproviderListLearningContentsParameter, LearningproviderListLearningContentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/learningprovider-list-learningcontents?view=graph-rest-1.0
        /// </summary>
        public async Task<LearningproviderListLearningContentsResponse> LearningproviderListLearningContentsAsync(CancellationToken cancellationToken)
        {
            var p = new LearningproviderListLearningContentsParameter();
            return await this.SendAsync<LearningproviderListLearningContentsParameter, LearningproviderListLearningContentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/learningprovider-list-learningcontents?view=graph-rest-1.0
        /// </summary>
        public async Task<LearningproviderListLearningContentsResponse> LearningproviderListLearningContentsAsync(LearningproviderListLearningContentsParameter parameter)
        {
            return await this.SendAsync<LearningproviderListLearningContentsParameter, LearningproviderListLearningContentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/learningprovider-list-learningcontents?view=graph-rest-1.0
        /// </summary>
        public async Task<LearningproviderListLearningContentsResponse> LearningproviderListLearningContentsAsync(LearningproviderListLearningContentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<LearningproviderListLearningContentsParameter, LearningproviderListLearningContentsResponse>(parameter, cancellationToken);
        }
    }
}
