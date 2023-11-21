using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-applyhold?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverycustodianApplyholdParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }
            public string? EDiscoveryCustodianId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_ApplyHold: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/custodians/applyHold";
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_EDiscoveryCustodianId_ApplyHold: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/custodians/{EDiscoveryCustodianId}/applyHold";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_ApplyHold,
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_EDiscoveryCustodianId_ApplyHold,
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
        public String[]? Ids { get; set; }
    }
    public partial class SecurityEdiscoverycustodianApplyholdResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-applyhold?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-applyhold?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycustodianApplyholdResponse> SecurityEdiscoverycustodianApplyholdAsync()
        {
            var p = new SecurityEdiscoverycustodianApplyholdParameter();
            return await this.SendAsync<SecurityEdiscoverycustodianApplyholdParameter, SecurityEdiscoverycustodianApplyholdResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-applyhold?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycustodianApplyholdResponse> SecurityEdiscoverycustodianApplyholdAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverycustodianApplyholdParameter();
            return await this.SendAsync<SecurityEdiscoverycustodianApplyholdParameter, SecurityEdiscoverycustodianApplyholdResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-applyhold?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycustodianApplyholdResponse> SecurityEdiscoverycustodianApplyholdAsync(SecurityEdiscoverycustodianApplyholdParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverycustodianApplyholdParameter, SecurityEdiscoverycustodianApplyholdResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-applyhold?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycustodianApplyholdResponse> SecurityEdiscoverycustodianApplyholdAsync(SecurityEdiscoverycustodianApplyholdParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverycustodianApplyholdParameter, SecurityEdiscoverycustodianApplyholdResponse>(parameter, cancellationToken);
        }
    }
}
