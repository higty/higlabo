using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/agreementacceptance?view=graph-rest-1.0
    /// </summary>
    public partial class AgreementAcceptance
    {
        public string AgreementFileId { get; set; }
        public string AgreementId { get; set; }
        public string DeviceDisplayName { get; set; }
        public string DeviceId { get; set; }
        public string DeviceOSType { get; set; }
        public string DeviceOSVersion { get; set; }
        public DateTimeOffset ExpirationDateTime { get; set; }
        public string Id { get; set; }
        public DateTimeOffset RecordedDateTime { get; set; }
        public AgreementAcceptanceString State { get; set; }
        public string UserDisplayName { get; set; }
        public string UserEmail { get; set; }
        public string UserId { get; set; }
        public string UserPrincipalName { get; set; }
    }
}
