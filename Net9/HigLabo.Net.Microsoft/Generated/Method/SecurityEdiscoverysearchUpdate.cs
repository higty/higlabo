using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-update?view=graph-rest-1.0
/// </summary>
public partial class SecurityEDiscoverysearchUpdateParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? EdiscoveryCaseId { get; set; }
        public string? EdiscoverySearchId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/searches/{EdiscoverySearchId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum SecurityEDiscoverysearchUpdateParameterSecurityDataSourceScopes
    {
        None,
        AllTenantMailboxes,
        AllTenantSites,
        AllCaseCustodians,
        AllCaseNoncustodialDataSources,
    }
    public enum ApiPath
    {
        Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "PATCH";
    public string? ContentQuery { get; set; }
    public SecurityEDiscoverysearchUpdateParameterSecurityDataSourceScopes DataSourceScopes { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
}
public partial class SecurityEDiscoverysearchUpdateResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverysearchUpdateResponse> SecurityEDiscoverysearchUpdateAsync()
    {
        var p = new SecurityEDiscoverysearchUpdateParameter();
        return await this.SendAsync<SecurityEDiscoverysearchUpdateParameter, SecurityEDiscoverysearchUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverysearchUpdateResponse> SecurityEDiscoverysearchUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new SecurityEDiscoverysearchUpdateParameter();
        return await this.SendAsync<SecurityEDiscoverysearchUpdateParameter, SecurityEDiscoverysearchUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverysearchUpdateResponse> SecurityEDiscoverysearchUpdateAsync(SecurityEDiscoverysearchUpdateParameter parameter)
    {
        return await this.SendAsync<SecurityEDiscoverysearchUpdateParameter, SecurityEDiscoverysearchUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverysearchUpdateResponse> SecurityEDiscoverysearchUpdateAsync(SecurityEDiscoverysearchUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityEDiscoverysearchUpdateParameter, SecurityEDiscoverysearchUpdateResponse>(parameter, cancellationToken);
    }
}
