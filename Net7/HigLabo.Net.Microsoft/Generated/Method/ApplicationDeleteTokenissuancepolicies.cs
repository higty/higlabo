using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-delete-tokenissuancepolicies?view=graph-rest-1.0
    /// </summary>
    public partial class ApplicationDeleteTokenissuancepoliciesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ApplicationsId { get; set; }
            public string? TokenIssuancePoliciesId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Applications_Id_TokenIssuancePolicies_Id_ref: return $"/applications/{ApplicationsId}/tokenIssuancePolicies/{TokenIssuancePoliciesId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Applications_Id_TokenIssuancePolicies_Id_ref,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class ApplicationDeleteTokenissuancepoliciesResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-delete-tokenissuancepolicies?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-delete-tokenissuancepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationDeleteTokenissuancepoliciesResponse> ApplicationDeleteTokenissuancepoliciesAsync()
        {
            var p = new ApplicationDeleteTokenissuancepoliciesParameter();
            return await this.SendAsync<ApplicationDeleteTokenissuancepoliciesParameter, ApplicationDeleteTokenissuancepoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-delete-tokenissuancepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationDeleteTokenissuancepoliciesResponse> ApplicationDeleteTokenissuancepoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationDeleteTokenissuancepoliciesParameter();
            return await this.SendAsync<ApplicationDeleteTokenissuancepoliciesParameter, ApplicationDeleteTokenissuancepoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-delete-tokenissuancepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationDeleteTokenissuancepoliciesResponse> ApplicationDeleteTokenissuancepoliciesAsync(ApplicationDeleteTokenissuancepoliciesParameter parameter)
        {
            return await this.SendAsync<ApplicationDeleteTokenissuancepoliciesParameter, ApplicationDeleteTokenissuancepoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-delete-tokenissuancepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationDeleteTokenissuancepoliciesResponse> ApplicationDeleteTokenissuancepoliciesAsync(ApplicationDeleteTokenissuancepoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationDeleteTokenissuancepoliciesParameter, ApplicationDeleteTokenissuancepoliciesResponse>(parameter, cancellationToken);
        }
    }
}
