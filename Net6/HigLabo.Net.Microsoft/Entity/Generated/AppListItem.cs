using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-applistitem?view=graph-rest-1.0
    /// </summary>
    public partial class AppListItem
    {
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string AppStoreUrl { get; set; }
        public string AppId { get; set; }
    }
}
