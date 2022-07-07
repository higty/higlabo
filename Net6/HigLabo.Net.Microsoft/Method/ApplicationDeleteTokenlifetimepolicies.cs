using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationDeleteTokenlifetimepoliciesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Applications_Id_TokenLifetimePolicies_Id_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Applications_Id_TokenLifetimePolicies_Id_ref: return $"/applications/{ApplicationsId}/tokenLifetimePolicies/{TokenLifetimePoliciesId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ApplicationsId { get; set; }
        public string TokenLifetimePoliciesId { get; set; }
    }
    public partial class ApplicationDeleteTokenlifetimepoliciesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-delete-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationDeleteTokenlifetimepoliciesResponse> ApplicationDeleteTokenlifetimepoliciesAsync()
        {
            var p = new ApplicationDeleteTokenlifetimepoliciesParameter();
            return await this.SendAsync<ApplicationDeleteTokenlifetimepoliciesParameter, ApplicationDeleteTokenlifetimepoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-delete-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationDeleteTokenlifetimepoliciesResponse> ApplicationDeleteTokenlifetimepoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationDeleteTokenlifetimepoliciesParameter();
            return await this.SendAsync<ApplicationDeleteTokenlifetimepoliciesParameter, ApplicationDeleteTokenlifetimepoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-delete-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationDeleteTokenlifetimepoliciesResponse> ApplicationDeleteTokenlifetimepoliciesAsync(ApplicationDeleteTokenlifetimepoliciesParameter parameter)
        {
            return await this.SendAsync<ApplicationDeleteTokenlifetimepoliciesParameter, ApplicationDeleteTokenlifetimepoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-delete-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationDeleteTokenlifetimepoliciesResponse> ApplicationDeleteTokenlifetimepoliciesAsync(ApplicationDeleteTokenlifetimepoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationDeleteTokenlifetimepoliciesParameter, ApplicationDeleteTokenlifetimepoliciesResponse>(parameter, cancellationToken);
        }
    }
}
