using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/roomlist?view=graph-rest-1.0
    /// </summary>
    public partial class RoomList
    {
        public PhysicalAddress? Address { get; set; }
        public string? DisplayName { get; set; }
        public string? EmailAddress { get; set; }
        public OutlookGeoCoordinates? GeoCoordinates { get; set; }
        public string? Id { get; set; }
        public string? Phone { get; set; }
        public Place[]? Rooms { get; set; }
    }
}
