using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-devices-devicegeolocation?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceGeoLocation
    {
        public DateTimeOffset LastCollectedDateTime { get; set; }
        public Double? Longitude { get; set; }
        public Double? Latitude { get; set; }
        public Double? Altitude { get; set; }
        public Double? HorizontalAccuracy { get; set; }
        public Double? VerticalAccuracy { get; set; }
        public Double? Heading { get; set; }
        public Double? Speed { get; set; }
    }
}
