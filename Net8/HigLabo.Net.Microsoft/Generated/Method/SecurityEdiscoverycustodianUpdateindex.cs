using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-updateindex?view=graph-rest-1.0
/// </summary>
public partial class SecurityEDiscoverycustodianUpdateindexParameter : IRestApiParameter
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
public partial class SecurityEDiscoverycustodianUpdateindexResponse : RestApiResponse
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
    public async ValueTask<SecurityEDiscoverycustodianUpdateindexResponse> SecurityEDiscoverycustodianUpdateindexAsync()
    {
        var p = new SecurityEDiscoverycustodianUpdateindexParameter();
        return await this.SendAsync<SecurityEDiscoverycustodianUpdateindexParameter, SecurityEDiscoverycustodianUpdateindexResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-updateindex?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycustodianUpdateindexResponse> SecurityEDiscoverycustodianUpdateindexAsync(CancellationToken cancellationToken)
    {
        var p = new SecurityEDiscoverycustodianUpdateindexParameter();
        return await this.SendAsync<SecurityEDiscoverycustodianUpdateindexParameter, SecurityEDiscoverycustodianUpdateindexResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-updateindex?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycustodianUpdateindexResponse> SecurityEDiscoverycustodianUpdateindexAsync(SecurityEDiscoverycustodianUpdateindexParameter parameter)
    {
        return await this.SendAsync<SecurityEDiscoverycustodianUpdateindexParameter, SecurityEDiscoverycustodianUpdateindexResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-updateindex?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycustodianUpdateindexResponse> SecurityEDiscoverycustodianUpdateindexAsync(SecurityEDiscoverycustodianUpdateindexParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityEDiscoverycustodianUpdateindexParameter, SecurityEDiscoverycustodianUpdateindexResponse>(parameter, cancellationToken);
    }
}
