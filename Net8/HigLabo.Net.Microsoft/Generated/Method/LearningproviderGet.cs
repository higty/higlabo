using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/learningprovider-get?view=graph-rest-1.0
    /// </summary>
    public partial class LearningProviderGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? LearningProviderId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.EmployeeExperience_LearningProviders_LearningProviderId: return $"/employeeExperience/learningProviders/{LearningProviderId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            EmployeeExperience_LearningProviders_LearningProviderId,
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
    public partial class LearningProviderGetResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? LoginWebUrl { get; set; }
        public string? LongLogoWebUrlForDarkTheme { get; set; }
        public string? LongLogoWebUrlForLightTheme { get; set; }
        public string? SquareLogoWebUrlForDarkTheme { get; set; }
        public string? SquareLogoWebUrlForLightTheme { get; set; }
        public LearningContent[]? LearningContents { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/learningprovider-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/learningprovider-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<LearningProviderGetResponse> LearningProviderGetAsync()
        {
            var p = new LearningProviderGetParameter();
            return await this.SendAsync<LearningProviderGetParameter, LearningProviderGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/learningprovider-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<LearningProviderGetResponse> LearningProviderGetAsync(CancellationToken cancellationToken)
        {
            var p = new LearningProviderGetParameter();
            return await this.SendAsync<LearningProviderGetParameter, LearningProviderGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/learningprovider-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<LearningProviderGetResponse> LearningProviderGetAsync(LearningProviderGetParameter parameter)
        {
            return await this.SendAsync<LearningProviderGetParameter, LearningProviderGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/learningprovider-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<LearningProviderGetResponse> LearningProviderGetAsync(LearningProviderGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<LearningProviderGetParameter, LearningProviderGetResponse>(parameter, cancellationToken);
        }
    }
}
