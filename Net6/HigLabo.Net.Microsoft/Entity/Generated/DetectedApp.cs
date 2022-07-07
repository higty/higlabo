using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-devices-detectedapp?view=graph-rest-1.0
    /// </summary>
    public partial class DetectedApp
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Version { get; set; }
        public Int64? SizeInByte { get; set; }
        public Int32? DeviceCount { get; set; }
    }
}
