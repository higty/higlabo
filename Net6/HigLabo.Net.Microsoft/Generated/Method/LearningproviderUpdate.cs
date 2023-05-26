using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/learningprovider-update?view=graph-rest-1.0
    /// </summary>
    public partial class LearningproviderUpdateParameter : IRestApiParameter
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
    public partial class LearningproviderUpdateResponse : RestApiResponse
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
        public async Task<LearningproviderUpdateResponse> LearningproviderUpdateAsync()
        {
            var p = new LearningproviderUpdateParameter();
            return await this.SendAsync<LearningproviderUpdateParameter, LearningproviderUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/learningprovider-update?view=graph-rest-1.0
        /// </summary>
        public async Task<LearningproviderUpdateResponse> LearningproviderUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new LearningproviderUpdateParameter();
            return await this.SendAsync<LearningproviderUpdateParameter, LearningproviderUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/learningprovider-update?view=graph-rest-1.0
        /// </summary>
        public async Task<LearningproviderUpdateResponse> LearningproviderUpdateAsync(LearningproviderUpdateParameter parameter)
        {
            return await this.SendAsync<LearningproviderUpdateParameter, LearningproviderUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/learningprovider-update?view=graph-rest-1.0
        /// </summary>
        public async Task<LearningproviderUpdateResponse> LearningproviderUpdateAsync(LearningproviderUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<LearningproviderUpdateParameter, LearningproviderUpdateResponse>(parameter, cancellationToken);
        }
    }
}
