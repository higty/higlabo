using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/externalconnectors-externalactivityresult?view=graph-rest-1.0
    /// </summary>
    public partial class ExternalConnectorsExternalactivityResult
    {
        public enum ExternalConnectorsExternalactivityResultExternalConnectorsExternalActivityType
        {
            Viewed,
            Modified,
            Created,
            Commented,
            UnknownFutureValue,
        }

        public PublicError? Error { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public ExternalConnectorsExternalactivityResultExternalConnectorsExternalActivityType Type { get; set; }
        public ExternalConnectorsIdentity? PerformedBy { get; set; }
    }
}
