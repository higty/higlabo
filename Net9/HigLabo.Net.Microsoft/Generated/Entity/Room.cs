using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/room?view=graph-rest-1.0
/// </summary>
public partial class Room
{
    public enum RoomBookingType
    {
        Standard,
        Reserved,
    }

    public PhysicalAddress? Address { get; set; }
    public string? AudioDeviceName { get; set; }
    public RoomBookingType BookingType { get; set; }
    public string? Building { get; set; }
    public Int32? Capacity { get; set; }
    public string? DisplayDeviceName { get; set; }
    public string? DisplayName { get; set; }
    public string? EmailAddress { get; set; }
    public string? FloorLabel { get; set; }
    public Int32? FloorNumber { get; set; }
    public OutlookGeoCoordinates? GeoCoordinates { get; set; }
    public string? Id { get; set; }
    public bool? IsWheelChairAccessible { get; set; }
    public string? Label { get; set; }
    public string? Nickname { get; set; }
    public string? Phone { get; set; }
    public String[]? Tags { get; set; }
    public string? VideoDeviceName { get; set; }
}
