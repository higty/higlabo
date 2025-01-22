using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-noncustodialdatasources?view=graph-rest-1.0
/// </summary>
public partial class SecurityEDiscoverycasePostNoncustodialdatasourcesParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? EdiscoveryCaseId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_NoncustodialDataSources: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/noncustodialDataSources";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum EDiscoveryNoncustodialDataSourceSecurityDataSourceHoldStatus
    {
        NotApplied,
        Applied,
        Applying,
        Removing,
        Partial,
    }
    public enum EDiscoveryNoncustodialDataSourceSecurityDataSourceContainerStatus
    {
        Active,
        Released,
    }
    public enum ApiPath
    {
        Security_Cases_EdiscoveryCases_EdiscoveryCaseId_NoncustodialDataSources,
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
    public DataSource? DataSource { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? DisplayName { get; set; }
    public EDiscoveryNoncustodialDataSourceSecurityDataSourceHoldStatus HoldStatus { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public DateTimeOffset? ReleasedDateTime { get; set; }
    public EDiscoveryNoncustodialDataSourceSecurityDataSourceContainerStatus Status { get; set; }
    public EDiscoveryIndexOperation? LastIndexOperation { get; set; }
}
public partial class SecurityEDiscoverycasePostNoncustodialdatasourcesResponse : RestApiResponse
{
    public enum EDiscoveryNoncustodialDataSourceSecurityDataSourceHoldStatus
    {
        NotApplied,
        Applied,
        Applying,
        Removing,
        Partial,
    }
    public enum EDiscoveryNoncustodialDataSourceSecurityDataSourceContainerStatus
    {
        Active,
        Released,
    }

    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? DisplayName { get; set; }
    public EDiscoveryNoncustodialDataSourceSecurityDataSourceHoldStatus HoldStatus { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public DateTimeOffset? ReleasedDateTime { get; set; }
    public EDiscoveryNoncustodialDataSourceSecurityDataSourceContainerStatus Status { get; set; }
    public DataSource? DataSource { get; set; }
    public EDiscoveryIndexOperation? LastIndexOperation { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-noncustodialdatasources?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-noncustodialdatasources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycasePostNoncustodialdatasourcesResponse> SecurityEDiscoverycasePostNoncustodialdatasourcesAsync()
    {
        var p = new SecurityEDiscoverycasePostNoncustodialdatasourcesParameter();
        return await this.SendAsync<SecurityEDiscoverycasePostNoncustodialdatasourcesParameter, SecurityEDiscoverycasePostNoncustodialdatasourcesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-noncustodialdatasources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycasePostNoncustodialdatasourcesResponse> SecurityEDiscoverycasePostNoncustodialdatasourcesAsync(CancellationToken cancellationToken)
    {
        var p = new SecurityEDiscoverycasePostNoncustodialdatasourcesParameter();
        return await this.SendAsync<SecurityEDiscoverycasePostNoncustodialdatasourcesParameter, SecurityEDiscoverycasePostNoncustodialdatasourcesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-noncustodialdatasources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycasePostNoncustodialdatasourcesResponse> SecurityEDiscoverycasePostNoncustodialdatasourcesAsync(SecurityEDiscoverycasePostNoncustodialdatasourcesParameter parameter)
    {
        return await this.SendAsync<SecurityEDiscoverycasePostNoncustodialdatasourcesParameter, SecurityEDiscoverycasePostNoncustodialdatasourcesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-noncustodialdatasources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycasePostNoncustodialdatasourcesResponse> SecurityEDiscoverycasePostNoncustodialdatasourcesAsync(SecurityEDiscoverycasePostNoncustodialdatasourcesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityEDiscoverycasePostNoncustodialdatasourcesParameter, SecurityEDiscoverycasePostNoncustodialdatasourcesResponse>(parameter, cancellationToken);
    }
}
