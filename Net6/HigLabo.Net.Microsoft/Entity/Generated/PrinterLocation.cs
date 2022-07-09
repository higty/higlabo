using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/printerlocation?view=graph-rest-1.0
    /// </summary>
    public partial class PrinterLocation
    {
        public Double? Latitude { get; set; }
        public Double? Longitude { get; set; }
        public Int32? AltitudeInMeters { get; set; }
        public string? StreetAddress { get; set; }
        public String[]? SubUnit { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? CountryOrRegion { get; set; }
        public string? Site { get; set; }
        public string? Building { get; set; }
        public string? Floor { get; set; }
        public string? FloorDescription { get; set; }
        public string? RoomName { get; set; }
        public string? RoomDescription { get; set; }
        public String[]? Organization { get; set; }
        public String[]? Subdivision { get; set; }
        public string? StateOrProvince { get; set; }
    }
}
