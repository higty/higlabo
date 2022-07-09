using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/ticketinfo?view=graph-rest-1.0
    /// </summary>
    public partial class TicketInfo
    {
        public string? TicketNumber { get; set; }
        public string? TicketSystem { get; set; }
    }
}
