using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/bookingcurrency?view=graph-rest-1.0
    /// </summary>
    public partial class BookingCurrency
    {
        public string? Id { get; set; }
        public string? Symbol { get; set; }
    }
}
