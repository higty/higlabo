using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-activate?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverycustodianActivateParameter : IRestApiParameter
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
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_EdiscoveryCustodianId_Activate: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/custodians/{EdiscoveryCustodianId}/activate";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_EdiscoveryCustodianId_Activate,
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
    public partial class SecurityEdiscoverycustodianActivateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-activate?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-activate?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycustodianActivateResponse> SecurityEdiscoverycustodianActivateAsync()
        {
            var p = new SecurityEdiscoverycustodianActivateParameter();
            return await this.SendAsync<SecurityEdiscoverycustodianActivateParameter, SecurityEdiscoverycustodianActivateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-activate?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycustodianActivateResponse> SecurityEdiscoverycustodianActivateAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverycustodianActivateParameter();
            return await this.SendAsync<SecurityEdiscoverycustodianActivateParameter, SecurityEdiscoverycustodianActivateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-activate?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycustodianActivateResponse> SecurityEdiscoverycustodianActivateAsync(SecurityEdiscoverycustodianActivateParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverycustodianActivateParameter, SecurityEdiscoverycustodianActivateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-activate?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycustodianActivateResponse> SecurityEdiscoverycustodianActivateAsync(SecurityEdiscoverycustodianActivateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverycustodianActivateParameter, SecurityEdiscoverycustodianActivateResponse>(parameter, cancellationToken);
        }
    }
}
