using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-incident-get?view=graph-rest-1.0
/// </summary>
public partial class SecurityIncidentGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? IncidentId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Security_Incidents_IncidentId: return $"/security/incidents/{IncidentId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Security_Incidents_IncidentId,
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
public partial class SecurityIncidentGetResponse : RestApiResponse
{
    public enum IncidentSecurityAlertClassification
    {
        Unknown,
        FalsePositive,
        TruePositive,
        InformationalExpectedActivity,
        UnknownFutureValue,
    }
    public enum IncidentSecurityAlertDetermination
    {
        Unknown,
        Apt,
        Malware,
        SecurityPersonnel,
        SecurityTesting,
        UnwantedSoftware,
        Other,
        MultiStagedAttack,
        CompromisedUser,
        Phishing,
        MaliciousUserActivity,
        Clean,
        InsufficientData,
        ConfirmedUserActivity,
        LineOfBusinessApplication,
        UnknownFutureValue,
    }
    public enum IncidentAlertSeverity
    {
        Unknown,
        Informational,
        Low,
        Medium,
        High,
        UnknownFutureValue,
    }
    public enum IncidentSecurityIncidentStatus
    {
        Active,
        Resolved,
        InProgress,
        Redirected,
        UnknownFutureValue,
    }

    public string? AssignedTo { get; set; }
    public IncidentSecurityAlertClassification Classification { get; set; }
    public AlertComment[]? Comments { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public String[]? CustomTags { get; set; }
    public IncidentSecurityAlertDetermination Determination { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public string? IncidentWebUrl { get; set; }
    public DateTimeOffset? LastUpdateDateTime { get; set; }
    public string? RedirectIncidentId { get; set; }
    public IncidentAlertSeverity Severity { get; set; }
    public IncidentSecurityIncidentStatus Status { get; set; }
    public string? TenantId { get; set; }
    public SecurityAlert[]? Alerts { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-incident-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-incident-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityIncidentGetResponse> SecurityIncidentGetAsync()
    {
        var p = new SecurityIncidentGetParameter();
        return await this.SendAsync<SecurityIncidentGetParameter, SecurityIncidentGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-incident-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityIncidentGetResponse> SecurityIncidentGetAsync(CancellationToken cancellationToken)
    {
        var p = new SecurityIncidentGetParameter();
        return await this.SendAsync<SecurityIncidentGetParameter, SecurityIncidentGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-incident-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityIncidentGetResponse> SecurityIncidentGetAsync(SecurityIncidentGetParameter parameter)
    {
        return await this.SendAsync<SecurityIncidentGetParameter, SecurityIncidentGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-incident-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityIncidentGetResponse> SecurityIncidentGetAsync(SecurityIncidentGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityIncidentGetParameter, SecurityIncidentGetResponse>(parameter, cancellationToken);
    }
}
