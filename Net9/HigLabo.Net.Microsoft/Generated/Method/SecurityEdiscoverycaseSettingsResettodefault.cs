using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycasesettings-resettodefault?view=graph-rest-1.0
/// </summary>
public partial class SecurityEDiscoverycaseSettingsResettodefaultParameter : IRestApiParameter
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
public partial class SecurityEDiscoverycaseSettingsResettodefaultResponse : RestApiResponse
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
    public async ValueTask<SecurityEDiscoverycaseSettingsResettodefaultResponse> SecurityEDiscoverycaseSettingsResettodefaultAsync()
    {
        var p = new SecurityEDiscoverycaseSettingsResettodefaultParameter();
        return await this.SendAsync<SecurityEDiscoverycaseSettingsResettodefaultParameter, SecurityEDiscoverycaseSettingsResettodefaultResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycasesettings-resettodefault?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycaseSettingsResettodefaultResponse> SecurityEDiscoverycaseSettingsResettodefaultAsync(CancellationToken cancellationToken)
    {
        var p = new SecurityEDiscoverycaseSettingsResettodefaultParameter();
        return await this.SendAsync<SecurityEDiscoverycaseSettingsResettodefaultParameter, SecurityEDiscoverycaseSettingsResettodefaultResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycasesettings-resettodefault?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycaseSettingsResettodefaultResponse> SecurityEDiscoverycaseSettingsResettodefaultAsync(SecurityEDiscoverycaseSettingsResettodefaultParameter parameter)
    {
        return await this.SendAsync<SecurityEDiscoverycaseSettingsResettodefaultParameter, SecurityEDiscoverycaseSettingsResettodefaultResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycasesettings-resettodefault?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycaseSettingsResettodefaultResponse> SecurityEDiscoverycaseSettingsResettodefaultAsync(SecurityEDiscoverycaseSettingsResettodefaultParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityEDiscoverycaseSettingsResettodefaultParameter, SecurityEDiscoverycaseSettingsResettodefaultResponse>(parameter, cancellationToken);
    }
}
