using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationPostTokenissuancepoliciesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Applications_Id_TokenIssuancePolicies_ref: return $"/applications/{Id}/tokenIssuancePolicies/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Applications_Id_TokenIssuancePolicies_ref,
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
    public partial class ApplicationPostTokenissuancepoliciesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-tokenissuancepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostTokenissuancepoliciesResponse> ApplicationPostTokenissuancepoliciesAsync()
        {
            var p = new ApplicationPostTokenissuancepoliciesParameter();
            return await this.SendAsync<ApplicationPostTokenissuancepoliciesParameter, ApplicationPostTokenissuancepoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-tokenissuancepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostTokenissuancepoliciesResponse> ApplicationPostTokenissuancepoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationPostTokenissuancepoliciesParameter();
            return await this.SendAsync<ApplicationPostTokenissuancepoliciesParameter, ApplicationPostTokenissuancepoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-tokenissuancepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostTokenissuancepoliciesResponse> ApplicationPostTokenissuancepoliciesAsync(ApplicationPostTokenissuancepoliciesParameter parameter)
        {
            return await this.SendAsync<ApplicationPostTokenissuancepoliciesParameter, ApplicationPostTokenissuancepoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-tokenissuancepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostTokenissuancepoliciesResponse> ApplicationPostTokenissuancepoliciesAsync(ApplicationPostTokenissuancepoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationPostTokenissuancepoliciesParameter, ApplicationPostTokenissuancepoliciesResponse>(parameter, cancellationToken);
        }
    }
}
