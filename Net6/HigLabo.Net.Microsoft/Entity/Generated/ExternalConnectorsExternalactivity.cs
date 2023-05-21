using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/externalconnectors-externalactivity?view=graph-rest-1.0
    /// </summary>
    public partial class ExternalConnectorsExternalactivity
    {
        public enum ExternalConnectorsExternalactivityExternalConnectorsExternalActivityType
        {
            Viewed,
            Modified,
            Created,
            Commented,
            UnknownFutureValue,
        }

        public DateTimeOffset? StartDateTime { get; set; }
        public ExternalConnectorsExternalactivityExternalConnectorsExternalActivityType Type { get; set; }
        public ExternalConnectorsIdentity? PerformedBy { get; set; }
    }
}
