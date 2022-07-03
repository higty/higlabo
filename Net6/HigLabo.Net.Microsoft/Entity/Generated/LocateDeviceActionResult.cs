using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-devices-locatedeviceactionresult?view=graph-rest-1.0
    /// </summary>
    public partial class LocateDeviceActionResult
    {
        public string ActionName { get; set; }
        public LocateDeviceActionResultActionState ActionState { get; set; }
        public DateTimeOffset StartDateTime { get; set; }
        public DateTimeOffset LastUpdatedDateTime { get; set; }
        public DeviceGeoLocation? DeviceLocation { get; set; }
    }
}
