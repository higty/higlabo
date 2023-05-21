using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/externalconnectors-connectionoperation?view=graph-rest-1.0
    /// </summary>
    public partial class ExternalConnectorsConnectionOperation
    {
        public enum ExternalConnectorsConnectionOperationExternalConnectorsConnectionOperationStatus
        {
            Unspecified,
            Inprogress,
            Completed,
            Failed,
            UnknownFutureValue,
        }

        public PublicError? Error { get; set; }
        public string? Id { get; set; }
        public ExternalConnectorsConnectionOperationExternalConnectorsConnectionOperationStatus Status { get; set; }
    }
}
