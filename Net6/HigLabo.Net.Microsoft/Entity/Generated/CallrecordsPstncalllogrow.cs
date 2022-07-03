using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/callrecords-pstncalllogrow?view=graph-rest-1.0
    /// </summary>
    public partial class CallrecordsPstncalllogrow
    {
        public PstnCallDurationSource CallDurationSource { get; set; }
        public string CalleeNumber { get; set; }
        public string CallerNumber { get; set; }
        public string CallId { get; set; }
        public string CallType { get; set; }
        public Double? Charge { get; set; }
        public string ConferenceId { get; set; }
        public Double? ConnectionCharge { get; set; }
        public string Currency { get; set; }
        public string DestinationContext { get; set; }
        public string DestinationName { get; set; }
        public Int32? Duration { get; set; }
        public DateTimeOffset EndDateTime { get; set; }
        public string Id { get; set; }
        public string InventoryType { get; set; }
        public string LicenseCapability { get; set; }
        public string Operator { get; set; }
        public DateTimeOffset StartDateTime { get; set; }
        public string TenantCountryCode { get; set; }
        public string UsageCountryCode { get; set; }
        public string UserDisplayName { get; set; }
        public string UserId { get; set; }
        public string UserPrincipalName { get; set; }
    }
}
