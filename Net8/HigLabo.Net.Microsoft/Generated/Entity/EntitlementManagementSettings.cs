using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/entitlementmanagementsettings?view=graph-rest-1.0
/// </summary>
public partial class EntitlementManagementSettings
{
    public enum EntitlementManagementSettingsAccessPackageExternalUserLifecycleAction
    {
        None,
        BlockSignIn,
        BlockSignInAndDelete,
        UnknownFutureValue,
    }

    public string? DurationUntilExternalUserDeletedAfterBlocked { get; set; }
    public EntitlementManagementSettingsAccessPackageExternalUserLifecycleAction ExternalUserLifecycleAction { get; set; }
    public string? Id { get; set; }
}
