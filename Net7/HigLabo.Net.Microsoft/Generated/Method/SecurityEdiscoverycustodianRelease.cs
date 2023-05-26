using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-release?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverycustodianReleaseParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }
            public string? EdiscoveryCustodianId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_EdiscoveryCustodianId_Release: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/custodians/{EdiscoveryCustodianId}/release";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_EdiscoveryCustodianId_Release,
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
    public partial class SecurityEdiscoverycustodianReleaseResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-release?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-release?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycustodianReleaseResponse> SecurityEdiscoverycustodianReleaseAsync()
        {
            var p = new SecurityEdiscoverycustodianReleaseParameter();
            return await this.SendAsync<SecurityEdiscoverycustodianReleaseParameter, SecurityEdiscoverycustodianReleaseResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-release?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycustodianReleaseResponse> SecurityEdiscoverycustodianReleaseAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverycustodianReleaseParameter();
            return await this.SendAsync<SecurityEdiscoverycustodianReleaseParameter, SecurityEdiscoverycustodianReleaseResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-release?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycustodianReleaseResponse> SecurityEdiscoverycustodianReleaseAsync(SecurityEdiscoverycustodianReleaseParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverycustodianReleaseParameter, SecurityEdiscoverycustodianReleaseResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-release?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycustodianReleaseResponse> SecurityEdiscoverycustodianReleaseAsync(SecurityEdiscoverycustodianReleaseParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverycustodianReleaseParameter, SecurityEdiscoverycustodianReleaseResponse>(parameter, cancellationToken);
        }
    }
}
