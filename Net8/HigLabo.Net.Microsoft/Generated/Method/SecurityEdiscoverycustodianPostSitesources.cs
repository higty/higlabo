using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-post-sitesources?view=graph-rest-1.0
/// </summary>
public partial class SecurityEDiscoverycustodianPostSitesourcesParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? EdiscoveryCaseId { get; set; }
        public string? CustodianId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_CustodianId_SiteSources: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/custodians/{CustodianId}/siteSources";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum SiteSourceSecurityDataSourceHoldStatus
    {
        NotApplied,
        Applied,
        Applying,
        Removing,
        Partial,
    }
    public enum ApiPath
    {
        Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_CustodianId_SiteSources,
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
    public string? Site { get; set; }
    public IdentitySet? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public SiteSourceSecurityDataSourceHoldStatus HoldStatus { get; set; }
}
public partial class SecurityEDiscoverycustodianPostSitesourcesResponse : RestApiResponse
{
    public enum SiteSourceSecurityDataSourceHoldStatus
    {
        NotApplied,
        Applied,
        Applying,
        Removing,
        Partial,
    }

    public IdentitySet? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public SiteSourceSecurityDataSourceHoldStatus HoldStatus { get; set; }
    public Site? Site { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-post-sitesources?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-post-sitesources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycustodianPostSitesourcesResponse> SecurityEDiscoverycustodianPostSitesourcesAsync()
    {
        var p = new SecurityEDiscoverycustodianPostSitesourcesParameter();
        return await this.SendAsync<SecurityEDiscoverycustodianPostSitesourcesParameter, SecurityEDiscoverycustodianPostSitesourcesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-post-sitesources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycustodianPostSitesourcesResponse> SecurityEDiscoverycustodianPostSitesourcesAsync(CancellationToken cancellationToken)
    {
        var p = new SecurityEDiscoverycustodianPostSitesourcesParameter();
        return await this.SendAsync<SecurityEDiscoverycustodianPostSitesourcesParameter, SecurityEDiscoverycustodianPostSitesourcesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-post-sitesources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycustodianPostSitesourcesResponse> SecurityEDiscoverycustodianPostSitesourcesAsync(SecurityEDiscoverycustodianPostSitesourcesParameter parameter)
    {
        return await this.SendAsync<SecurityEDiscoverycustodianPostSitesourcesParameter, SecurityEDiscoverycustodianPostSitesourcesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-post-sitesources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycustodianPostSitesourcesResponse> SecurityEDiscoverycustodianPostSitesourcesAsync(SecurityEDiscoverycustodianPostSitesourcesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityEDiscoverycustodianPostSitesourcesParameter, SecurityEDiscoverycustodianPostSitesourcesResponse>(parameter, cancellationToken);
    }
}
