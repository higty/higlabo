using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycasesettings-resettodefault?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverycaseSettingsResettodefaultParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Settings_ResetToDefault: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/settings/resetToDefault";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Settings_ResetToDefault,
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
    public partial class SecurityEdiscoverycaseSettingsResettodefaultResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycasesettings-resettodefault?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycasesettings-resettodefault?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycaseSettingsResettodefaultResponse> SecurityEdiscoverycaseSettingsResettodefaultAsync()
        {
            var p = new SecurityEdiscoverycaseSettingsResettodefaultParameter();
            return await this.SendAsync<SecurityEdiscoverycaseSettingsResettodefaultParameter, SecurityEdiscoverycaseSettingsResettodefaultResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycasesettings-resettodefault?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycaseSettingsResettodefaultResponse> SecurityEdiscoverycaseSettingsResettodefaultAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverycaseSettingsResettodefaultParameter();
            return await this.SendAsync<SecurityEdiscoverycaseSettingsResettodefaultParameter, SecurityEdiscoverycaseSettingsResettodefaultResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycasesettings-resettodefault?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycaseSettingsResettodefaultResponse> SecurityEdiscoverycaseSettingsResettodefaultAsync(SecurityEdiscoverycaseSettingsResettodefaultParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverycaseSettingsResettodefaultParameter, SecurityEdiscoverycaseSettingsResettodefaultResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycasesettings-resettodefault?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycaseSettingsResettodefaultResponse> SecurityEdiscoverycaseSettingsResettodefaultAsync(SecurityEdiscoverycaseSettingsResettodefaultParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverycaseSettingsResettodefaultParameter, SecurityEdiscoverycaseSettingsResettodefaultResponse>(parameter, cancellationToken);
        }
    }
}
