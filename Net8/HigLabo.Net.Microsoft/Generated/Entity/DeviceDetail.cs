using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/devicedetail?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceDetail
    {
        public string? Browser { get; set; }
        public string? DeviceId { get; set; }
        public string? DisplayName { get; set; }
        public bool? IsCompliant { get; set; }
        public bool? IsManaged { get; set; }
        public string? OperatingSystem { get; set; }
        public string? TrustType { get; set; }
    }
}
