using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-removehold?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverycustodianRemoveholdParameter : IRestApiParameter
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
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_RemoveHold: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/custodians/removeHold";
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_EDiscoveryCustodianId_RemoveHold: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/custodians/{EDiscoveryCustodianId}/removeHold";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_RemoveHold,
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_EDiscoveryCustodianId_RemoveHold,
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
    public partial class SecurityEdiscoverycustodianRemoveholdResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-removehold?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-removehold?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycustodianRemoveholdResponse> SecurityEdiscoverycustodianRemoveholdAsync()
        {
            var p = new SecurityEdiscoverycustodianRemoveholdParameter();
            return await this.SendAsync<SecurityEdiscoverycustodianRemoveholdParameter, SecurityEdiscoverycustodianRemoveholdResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-removehold?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycustodianRemoveholdResponse> SecurityEdiscoverycustodianRemoveholdAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverycustodianRemoveholdParameter();
            return await this.SendAsync<SecurityEdiscoverycustodianRemoveholdParameter, SecurityEdiscoverycustodianRemoveholdResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-removehold?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycustodianRemoveholdResponse> SecurityEdiscoverycustodianRemoveholdAsync(SecurityEdiscoverycustodianRemoveholdParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverycustodianRemoveholdParameter, SecurityEdiscoverycustodianRemoveholdResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-removehold?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycustodianRemoveholdResponse> SecurityEdiscoverycustodianRemoveholdAsync(SecurityEdiscoverycustodianRemoveholdParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverycustodianRemoveholdParameter, SecurityEdiscoverycustodianRemoveholdResponse>(parameter, cancellationToken);
        }
    }
}
