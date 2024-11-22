using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-synchronizationsecretkeystringvaluepair?view=graph-rest-1.0
/// </summary>
public partial class SynchronizationSecretKeyStringValuePair
{
    public enum SynchronizationSecretKeyStringValuePairSynchronizationSecret
    {
        None,
        UserName,
        Password,
        SecretToken,
        AppKey,
        BaseAddress,
        ClientIdentifier,
        ClientSecret,
        SingleSignOnType,
        Sandbox,
        Url,
        Domain,
        ConsumerKey,
        ConsumerSecret,
        TokenKey,
        TokenExpiration,
        Oauth2AccessToken,
        Oauth2AccessTokenCreationTime,
        Oauth2RefreshToken,
        SyncAll,
        InstanceName,
        Oauth2ClientId,
        Oauth2ClientSecret,
        CompanyId,
        UpdateKeyOnSoftDelete,
        SynchronizationSchedule,
        SystemOfRecord,
        SandboxName,
        EnforceDomain,
        SyncNotificationSettings,
        SkipOutOfScopeDeletions,
        Oauth2AuthorizationCode,
        Oauth2RedirectUri,
        ApplicationTemplateIdentifier,
        Oauth2TokenExchangeUri,
        Oauth2AuthorizationUri,
        AuthenticationType,
        Server,
        PerformInboundEntitlementGrants,
        HardDeletesEnabled,
        SyncAgentCompatibilityKey,
        SyncAgentADContainer,
        ValidateDomain,
        TestReferences,
        ConnectionString,
    }

    public SynchronizationSecretKeyStringValuePairSynchronizationSecret Key { get; set; }
    public string? Value { get; set; }
}
