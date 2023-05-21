using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-retentioneventstatus?view=graph-rest-1.0
    /// </summary>
    public partial class RetentionEventStatus
    {
        public enum RetentionEventStatusSecurityEventStatusType
        {
            Pending,
            Error,
            Success,
            NotAvaliable,
        }

        public PublicError? Error { get; set; }
        public RetentionEventStatusSecurityEventStatusType Status { get; set; }
    }
}
