using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/identitygovernance-customtaskextensioncallbackdata?view=graph-rest-1.0
/// </summary>
public partial class CustomTaskExtensionCallbackData
{
    public enum CustomTaskExtensionCallbackDataIdentityGovernanceCustomTaskExtensionOperationStatus
    {
        Completed,
        Failed,
        UnknownFutureValue,
    }

    public CustomTaskExtensionCallbackDataIdentityGovernanceCustomTaskExtensionOperationStatus OperationStatus { get; set; }
}
