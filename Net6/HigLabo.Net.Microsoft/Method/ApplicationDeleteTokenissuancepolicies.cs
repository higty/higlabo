using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationDeleteTokenissuancepoliciesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Applications_Id_TokenIssuancePolicies_Id_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Applications_Id_TokenIssuancePolicies_Id_ref: return $"/applications/{ApplicationsId}/tokenIssuancePolicies/{TokenIssuancePoliciesId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ApplicationsId { get; set; }
        public string TokenIssuancePoliciesId { get; set; }
    }
    public partial class ApplicationDeleteTokenissuancepoliciesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-delete-tokenissuancepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationDeleteTokenissuancepoliciesResponse> ApplicationDeleteTokenissuancepoliciesAsync()
        {
            var p = new ApplicationDeleteTokenissuancepoliciesParameter();
            return await this.SendAsync<ApplicationDeleteTokenissuancepoliciesParameter, ApplicationDeleteTokenissuancepoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-delete-tokenissuancepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationDeleteTokenissuancepoliciesResponse> ApplicationDeleteTokenissuancepoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationDeleteTokenissuancepoliciesParameter();
            return await this.SendAsync<ApplicationDeleteTokenissuancepoliciesParameter, ApplicationDeleteTokenissuancepoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-delete-tokenissuancepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationDeleteTokenissuancepoliciesResponse> ApplicationDeleteTokenissuancepoliciesAsync(ApplicationDeleteTokenissuancepoliciesParameter parameter)
        {
            return await this.SendAsync<ApplicationDeleteTokenissuancepoliciesParameter, ApplicationDeleteTokenissuancepoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-delete-tokenissuancepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationDeleteTokenissuancepoliciesResponse> ApplicationDeleteTokenissuancepoliciesAsync(ApplicationDeleteTokenissuancepoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationDeleteTokenissuancepoliciesParameter, ApplicationDeleteTokenissuancepoliciesResponse>(parameter, cancellationToken);
        }
    }
}
