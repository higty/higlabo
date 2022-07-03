using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/bookingcustomer?view=graph-rest-1.0
    /// </summary>
    public partial class BookingCustomer
    {
        public string DisplayName { get; set; }
        public string EmailAddress { get; set; }
        public string Id { get; set; }
        public PhysicalAddress[] Addresses { get; set; }
        public Phone[] Phones { get; set; }
    }
}
