using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-alert-update?view=graph-rest-1.0
/// </summary>
public partial class SecurityAlertUpdateParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? AlertId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Security_Alerts_v2_AlertId: return $"/security/alerts_v2/{AlertId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum SecurityAlertUpdateParameterSecurityAlertStatus
    {
        New,
        InProgress,
        Resolved,
        UnknownFutureValue,
    }
    public enum SecurityAlertUpdateParameterSecurityAlertClassification
    {
        Unknown,
        FalsePositive,
        TruePositive,
        BenignPositive,
        UnknownFutureValue,
    }
    public enum SecurityAlertUpdateParameterSecurityAlertDetermination
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
    public enum ApiPath
    {
        Security_Alerts_v2_AlertId,
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
    public SecurityAlertUpdateParameterSecurityAlertStatus Status { get; set; }
    public SecurityAlertUpdateParameterSecurityAlertClassification Classification { get; set; }
    public SecurityAlertUpdateParameterSecurityAlertDetermination Determination { get; set; }
    public string? AssignedTo { get; set; }
}
public partial class SecurityAlertUpdateResponse : RestApiResponse
{
    public enum SecurityAlertSecurityAlertClassification
    {
        Unknown,
        FalsePositive,
        TruePositive,
        BenignPositive,
        UnknownFutureValue,
    }
    public enum SecurityAlertSecurityAlertDetermination
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
    public enum SecurityAlertSecurityServiceSource
    {
        MicrosoftDefenderForEndpoint,
        MicrosoftDefenderForIdentity,
        MicrosoftCloudAppSecurity,
        MicrosoftDefenderForOffice365,
        Microsoft365Defender,
        AadIdentityProtection,
        AppGovernance,
        DataLossPrevention,
    }
    public enum SecurityAlertSecurityAlertSeverity
    {
        Unknown,
        Informational,
        Low,
        Medium,
        High,
        UnknownFutureValue,
    }
    public enum SecurityAlertSecurityAlertStatus
    {
        New,
        InProgress,
        Resolved,
        UnknownFutureValue,
    }

    public string? ActorDisplayName { get; set; }
    public string? AlertWebUrl { get; set; }
    public string? AssignedTo { get; set; }
    public string? Category { get; set; }
    public SecurityAlertSecurityAlertClassification Classification { get; set; }
    public AlertComment[]? Comments { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Description { get; set; }
    public SecurityDetectionSource? DetectionSource { get; set; }
    public string? DetectorId { get; set; }
    public SecurityAlertSecurityAlertDetermination Determination { get; set; }
    public AlertEvidence[]? Evidence { get; set; }
    public DateTimeOffset? FirstActivityDateTime { get; set; }
    public string? Id { get; set; }
    public string? IncidentId { get; set; }
    public string? IncidentWebUrl { get; set; }
    public DateTimeOffset? LastActivityDateTime { get; set; }
    public DateTimeOffset? LastUpdateDateTime { get; set; }
    public string[]? MitreTechniques { get; set; }
    public string? ProviderAlertId { get; set; }
    public string? RecommendedActions { get; set; }
    public DateTimeOffset? ResolvedDateTime { get; set; }
    public SecurityAlertSecurityServiceSource ServiceSource { get; set; }
    public SecurityAlertSecurityAlertSeverity Severity { get; set; }
    public SecurityAlertSecurityAlertStatus Status { get; set; }
    public string? TenantId { get; set; }
    public string? ThreatDisplayName { get; set; }
    public string? ThreatFamilyName { get; set; }
    public string? Title { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-alert-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-alert-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityAlertUpdateResponse> SecurityAlertUpdateAsync()
    {
        var p = new SecurityAlertUpdateParameter();
        return await this.SendAsync<SecurityAlertUpdateParameter, SecurityAlertUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-alert-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityAlertUpdateResponse> SecurityAlertUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new SecurityAlertUpdateParameter();
        return await this.SendAsync<SecurityAlertUpdateParameter, SecurityAlertUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-alert-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityAlertUpdateResponse> SecurityAlertUpdateAsync(SecurityAlertUpdateParameter parameter)
    {
        return await this.SendAsync<SecurityAlertUpdateParameter, SecurityAlertUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-alert-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityAlertUpdateResponse> SecurityAlertUpdateAsync(SecurityAlertUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityAlertUpdateParameter, SecurityAlertUpdateResponse>(parameter, cancellationToken);
    }
}
