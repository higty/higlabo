using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/offershiftrequest?view=graph-rest-1.0
    /// </summary>
    public partial class OfferShiftRequest
    {
        public DateTimeOffset RecipientActionDateTime { get; set; }
        public string RecipientActionMessage { get; set; }
        public string RecipientUserId { get; set; }
        public string SenderShiftId { get; set; }
    }
}
