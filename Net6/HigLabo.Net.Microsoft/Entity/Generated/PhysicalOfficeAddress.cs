using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/physicalofficeaddress?view=graph-rest-1.0
    /// </summary>
    public partial class PhysicalOfficeAddress
    {
        public string City { get; set; }
        public string CountryOrRegion { get; set; }
        public string OfficeLocation { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
    }
}
