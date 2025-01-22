using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-applyhold?view=graph-rest-1.0
/// </summary>
public partial class SecurityEDiscoverynoncustodialdatasourceApplyholdParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? EdiscoveryCaseId { get; set; }
        public string? EdiscoverynoncustodialDatasourceId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_NoncustodialDataSources_ApplyHold: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/noncustodialDataSources/applyHold";
                case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_NoncustodialDataSources_EdiscoverynoncustodialDatasourceId_ApplyHold: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/noncustodialDataSources/{EdiscoverynoncustodialDatasourceId}/applyHold";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Security_Cases_EdiscoveryCases_EdiscoveryCaseId_NoncustodialDataSources_ApplyHold,
        Security_Cases_EdiscoveryCases_EdiscoveryCaseId_NoncustodialDataSources_EdiscoverynoncustodialDatasourceId_ApplyHold,
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
public partial class SecurityEDiscoverynoncustodialdatasourceApplyholdResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-applyhold?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-applyhold?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverynoncustodialdatasourceApplyholdResponse> SecurityEDiscoverynoncustodialdatasourceApplyholdAsync()
    {
        var p = new SecurityEDiscoverynoncustodialdatasourceApplyholdParameter();
        return await this.SendAsync<SecurityEDiscoverynoncustodialdatasourceApplyholdParameter, SecurityEDiscoverynoncustodialdatasourceApplyholdResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-applyhold?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverynoncustodialdatasourceApplyholdResponse> SecurityEDiscoverynoncustodialdatasourceApplyholdAsync(CancellationToken cancellationToken)
    {
        var p = new SecurityEDiscoverynoncustodialdatasourceApplyholdParameter();
        return await this.SendAsync<SecurityEDiscoverynoncustodialdatasourceApplyholdParameter, SecurityEDiscoverynoncustodialdatasourceApplyholdResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-applyhold?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverynoncustodialdatasourceApplyholdResponse> SecurityEDiscoverynoncustodialdatasourceApplyholdAsync(SecurityEDiscoverynoncustodialdatasourceApplyholdParameter parameter)
    {
        return await this.SendAsync<SecurityEDiscoverynoncustodialdatasourceApplyholdParameter, SecurityEDiscoverynoncustodialdatasourceApplyholdResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-applyhold?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverynoncustodialdatasourceApplyholdResponse> SecurityEDiscoverynoncustodialdatasourceApplyholdAsync(SecurityEDiscoverynoncustodialdatasourceApplyholdParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityEDiscoverynoncustodialdatasourceApplyholdParameter, SecurityEDiscoverynoncustodialdatasourceApplyholdResponse>(parameter, cancellationToken);
    }
}
