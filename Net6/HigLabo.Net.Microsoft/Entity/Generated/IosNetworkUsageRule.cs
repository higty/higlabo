using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-iosnetworkusagerule?view=graph-rest-1.0
    /// </summary>
    public partial class IosNetworkUsageRule
    {
        public AppListItem[]? ManagedApps { get; set; }
        public bool? CellularDataBlockWhenRoaming { get; set; }
        public bool? CellularDataBlocked { get; set; }
    }
}
