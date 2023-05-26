using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-updateindex?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverycustodianUpdateindexParameter : IRestApiParameter
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
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_EdiscoveryCustodianId_UpdateIndex: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/custodians/{EdiscoveryCustodianId}/updateIndex";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_EdiscoveryCustodianId_UpdateIndex,
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
    public partial class SecurityEdiscoverycustodianUpdateindexResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-updateindex?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-updateindex?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycustodianUpdateindexResponse> SecurityEdiscoverycustodianUpdateindexAsync()
        {
            var p = new SecurityEdiscoverycustodianUpdateindexParameter();
            return await this.SendAsync<SecurityEdiscoverycustodianUpdateindexParameter, SecurityEdiscoverycustodianUpdateindexResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-updateindex?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycustodianUpdateindexResponse> SecurityEdiscoverycustodianUpdateindexAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverycustodianUpdateindexParameter();
            return await this.SendAsync<SecurityEdiscoverycustodianUpdateindexParameter, SecurityEdiscoverycustodianUpdateindexResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-updateindex?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycustodianUpdateindexResponse> SecurityEdiscoverycustodianUpdateindexAsync(SecurityEdiscoverycustodianUpdateindexParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverycustodianUpdateindexParameter, SecurityEdiscoverycustodianUpdateindexResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-updateindex?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycustodianUpdateindexResponse> SecurityEdiscoverycustodianUpdateindexAsync(SecurityEdiscoverycustodianUpdateindexParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverycustodianUpdateindexParameter, SecurityEdiscoverycustodianUpdateindexResponse>(parameter, cancellationToken);
        }
    }
}
