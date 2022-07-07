using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationPostTokenissuancepoliciesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Applications_Id_TokenIssuancePolicies_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Applications_Id_TokenIssuancePolicies_ref: return $"/applications/{Id}/tokenIssuancePolicies/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
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
