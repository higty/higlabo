using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-post-tokenlifetimepolicies?view=graph-rest-1.0
    /// </summary>
    public partial class ApplicationPostTokenlifetimepoliciesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Applications_Id_TokenLifetimePolicies_ref: return $"/applications/{Id}/tokenLifetimePolicies/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Applications_Id_TokenLifetimePolicies_ref,
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
    }
    public partial class ApplicationPostTokenlifetimepoliciesResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-post-tokenlifetimepolicies?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-post-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostTokenlifetimepoliciesResponse> ApplicationPostTokenlifetimepoliciesAsync()
        {
            var p = new ApplicationPostTokenlifetimepoliciesParameter();
            return await this.SendAsync<ApplicationPostTokenlifetimepoliciesParameter, ApplicationPostTokenlifetimepoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-post-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostTokenlifetimepoliciesResponse> ApplicationPostTokenlifetimepoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationPostTokenlifetimepoliciesParameter();
            return await this.SendAsync<ApplicationPostTokenlifetimepoliciesParameter, ApplicationPostTokenlifetimepoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-post-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostTokenlifetimepoliciesResponse> ApplicationPostTokenlifetimepoliciesAsync(ApplicationPostTokenlifetimepoliciesParameter parameter)
        {
            return await this.SendAsync<ApplicationPostTokenlifetimepoliciesParameter, ApplicationPostTokenlifetimepoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-post-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostTokenlifetimepoliciesResponse> ApplicationPostTokenlifetimepoliciesAsync(ApplicationPostTokenlifetimepoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationPostTokenlifetimepoliciesParameter, ApplicationPostTokenlifetimepoliciesResponse>(parameter, cancellationToken);
        }
    }
}
