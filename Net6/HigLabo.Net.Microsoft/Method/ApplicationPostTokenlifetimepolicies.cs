using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationPostTokenlifetimepoliciesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Applications_Id_TokenLifetimePolicies_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Applications_Id_TokenLifetimePolicies_ref: return $"/applications/{Id}/tokenLifetimePolicies/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class ApplicationPostTokenlifetimepoliciesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostTokenlifetimepoliciesResponse> ApplicationPostTokenlifetimepoliciesAsync()
        {
            var p = new ApplicationPostTokenlifetimepoliciesParameter();
            return await this.SendAsync<ApplicationPostTokenlifetimepoliciesParameter, ApplicationPostTokenlifetimepoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostTokenlifetimepoliciesResponse> ApplicationPostTokenlifetimepoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationPostTokenlifetimepoliciesParameter();
            return await this.SendAsync<ApplicationPostTokenlifetimepoliciesParameter, ApplicationPostTokenlifetimepoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostTokenlifetimepoliciesResponse> ApplicationPostTokenlifetimepoliciesAsync(ApplicationPostTokenlifetimepoliciesParameter parameter)
        {
            return await this.SendAsync<ApplicationPostTokenlifetimepoliciesParameter, ApplicationPostTokenlifetimepoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostTokenlifetimepoliciesResponse> ApplicationPostTokenlifetimepoliciesAsync(ApplicationPostTokenlifetimepoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationPostTokenlifetimepoliciesParameter, ApplicationPostTokenlifetimepoliciesResponse>(parameter, cancellationToken);
        }
    }
}
