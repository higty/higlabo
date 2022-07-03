using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/physicaladdress?view=graph-rest-1.0
    /// </summary>
    public partial class PhysicalAddress
    {
        public string City { get; set; }
        public string CountryOrRegion { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
    }
}
