using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-get?view=graph-rest-1.0
/// </summary>
public partial class SecurityEDiscoverycustodianGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? EdiscoveryCaseId { get; set; }
        public string? EdiscoveryCustodianId { get; set; }
        public string? EdiscoveryReviewSetId { get; set; }
        public string? EdiscoveryFileId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_EdiscoveryCustodianId: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/custodians/{EdiscoveryCustodianId}";
                case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_ReviewSets_EdiscoveryReviewSetId_Files_EdiscoveryFileId_Custodian: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/reviewSets/{EdiscoveryReviewSetId}/files/{EdiscoveryFileId}/custodian";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_EdiscoveryCustodianId,
        Security_Cases_EdiscoveryCases_EdiscoveryCaseId_ReviewSets_EdiscoveryReviewSetId_Files_EdiscoveryFileId_Custodian,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
    IQueryParameter IQueryParameterProperty.Query
    {
        get
        {
            return this.Query;
        }
    }
}
public partial class SecurityEDiscoverycustodianGetResponse : RestApiResponse
{
    public enum EDiscoveryCustodianSecurityDataSourceHoldStatus
    {
        NotApplied,
        Applied,
        Applying,
        Removing,
        Partial,
    }
    public enum EDiscoveryCustodianSecurityCustodianStatus
    {
        Active,
        Released,
    }

    public DateTimeOffset? AcknowledgedDateTime { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? DisplayName { get; set; }
    public string? Email { get; set; }
    public EDiscoveryCustodianSecurityDataSourceHoldStatus HoldStatus { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public DateTimeOffset? ReleasedDateTime { get; set; }
    public EDiscoveryCustodianSecurityCustodianStatus Status { get; set; }
    public EDiscoveryIndexOperation? LastIndexOperation { get; set; }
    public SiteSource[]? SiteSources { get; set; }
    public UnifiedGroupSource[]? UnifiedGroupSources { get; set; }
    public UserSource[]? UserSources { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycustodianGetResponse> SecurityEDiscoverycustodianGetAsync()
    {
        var p = new SecurityEDiscoverycustodianGetParameter();
        return await this.SendAsync<SecurityEDiscoverycustodianGetParameter, SecurityEDiscoverycustodianGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycustodianGetResponse> SecurityEDiscoverycustodianGetAsync(CancellationToken cancellationToken)
    {
        var p = new SecurityEDiscoverycustodianGetParameter();
        return await this.SendAsync<SecurityEDiscoverycustodianGetParameter, SecurityEDiscoverycustodianGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycustodianGetResponse> SecurityEDiscoverycustodianGetAsync(SecurityEDiscoverycustodianGetParameter parameter)
    {
        return await this.SendAsync<SecurityEDiscoverycustodianGetParameter, SecurityEDiscoverycustodianGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycustodianGetResponse> SecurityEDiscoverycustodianGetAsync(SecurityEDiscoverycustodianGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityEDiscoverycustodianGetParameter, SecurityEDiscoverycustodianGetResponse>(parameter, cancellationToken);
    }
}
