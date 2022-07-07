using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/bookingbusiness?view=graph-rest-1.0
    /// </summary>
    public partial class BookingBusiness
    {
        public PhysicalAddress? Address { get; set; }
        public BookingWorkHours[]? BusinessHours { get; set; }
        public string? BusinessType { get; set; }
        public string? DefaultCurrencyIso { get; set; }
        public string? DisplayName { get; set; }
        public string? Email { get; set; }
        public string? Id { get; set; }
        public bool? IsPublished { get; set; }
        public string? Phone { get; set; }
        public string? PublicUrl { get; set; }
        public BookingSchedulingPolicy? SchedulingPolicy { get; set; }
        public string? WebSiteUrl { get; set; }
    }
}
