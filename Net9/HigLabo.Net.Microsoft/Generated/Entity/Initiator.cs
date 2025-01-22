using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/initiator?view=graph-rest-1.0
/// </summary>
public partial class Initiator
{
    public enum InitiatorInitiatorType
    {
        User,
        Application,
        System,
        UnknownFutureValue,
    }

    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public InitiatorInitiatorType InitiatorType { get; set; }
}
