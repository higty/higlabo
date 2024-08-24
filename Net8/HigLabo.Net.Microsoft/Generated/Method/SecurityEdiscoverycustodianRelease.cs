using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-release?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEDiscoverycustodianReleaseParameter : IRestApiParameter
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
    public partial class SecurityEDiscoverycustodianReleaseResponse : RestApiResponse
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
        public async ValueTask<SecurityEDiscoverycustodianReleaseResponse> SecurityEDiscoverycustodianReleaseAsync()
        {
            var p = new SecurityEDiscoverycustodianReleaseParameter();
            return await this.SendAsync<SecurityEDiscoverycustodianReleaseParameter, SecurityEDiscoverycustodianReleaseResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-release?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycustodianReleaseResponse> SecurityEDiscoverycustodianReleaseAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEDiscoverycustodianReleaseParameter();
            return await this.SendAsync<SecurityEDiscoverycustodianReleaseParameter, SecurityEDiscoverycustodianReleaseResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-release?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycustodianReleaseResponse> SecurityEDiscoverycustodianReleaseAsync(SecurityEDiscoverycustodianReleaseParameter parameter)
        {
            return await this.SendAsync<SecurityEDiscoverycustodianReleaseParameter, SecurityEDiscoverycustodianReleaseResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-release?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycustodianReleaseResponse> SecurityEDiscoverycustodianReleaseAsync(SecurityEDiscoverycustodianReleaseParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEDiscoverycustodianReleaseParameter, SecurityEDiscoverycustodianReleaseResponse>(parameter, cancellationToken);
        }
    }
}
