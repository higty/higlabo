using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/externalconnectors-externalactivity?view=graph-rest-1.0
/// </summary>
public partial class ExternalConnectorsExternalActivity
{
    public enum ExternalConnectorsExternalActivityExternalConnectorsExternalActivityType
    {
        Viewed,
        Modified,
        Created,
        Commented,
        UnknownFutureValue,
    }

    public DateTimeOffset? StartDateTime { get; set; }
    public ExternalConnectorsExternalActivityExternalConnectorsExternalActivityType Type { get; set; }
    public ExternalConnectorsIdentity? PerformedBy { get; set; }
}
