using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/customextensionstagesetting?view=graph-rest-1.0
/// </summary>
public partial class CustomExtensionStageSetting
{
    public enum CustomExtensionStageSettingAccessPackageCustomExtensionStage
    {
        AssignmentRequestCreated,
        AssignmentRequestApproved,
        AssignmentRequestGranted,
        AssignmentRequestRemoved,
        AssignmentFourteenDaysBeforeExpiration,
        AssignmentOneDayBeforeExpiration,
        UnknownFutureValue,
    }

    public string? Id { get; set; }
    public CustomExtensionStageSettingAccessPackageCustomExtensionStage Stage { get; set; }
    public CustomCalloutExtension? CustomExtension { get; set; }
}
