using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/learningprovider-update?view=graph-rest-1.0
    /// </summary>
    public partial class LearningProviderUpdateParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? DisplayName { get; set; }
        public string? LoginWebUrl { get; set; }
        public string? LongLogoWebUrlForDarkTheme { get; set; }
        public string? LongLogoWebUrlForLightTheme { get; set; }
        public string? SquareLogoWebUrlForDarkTheme { get; set; }
        public string? SquareLogoWebUrlForLightTheme { get; set; }
    }
    public partial class LearningProviderUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/learningprovider-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/learningprovider-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<LearningProviderUpdateResponse> LearningProviderUpdateAsync()
        {
            var p = new LearningProviderUpdateParameter();
            return await this.SendAsync<LearningProviderUpdateParameter, LearningProviderUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/learningprovider-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<LearningProviderUpdateResponse> LearningProviderUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new LearningProviderUpdateParameter();
            return await this.SendAsync<LearningProviderUpdateParameter, LearningProviderUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/learningprovider-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<LearningProviderUpdateResponse> LearningProviderUpdateAsync(LearningProviderUpdateParameter parameter)
        {
            return await this.SendAsync<LearningProviderUpdateParameter, LearningProviderUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/learningprovider-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<LearningProviderUpdateResponse> LearningProviderUpdateAsync(LearningProviderUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<LearningProviderUpdateParameter, LearningProviderUpdateResponse>(parameter, cancellationToken);
        }
    }
}
