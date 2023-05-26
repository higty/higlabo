using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/itemanalytics?view=graph-rest-1.0
    /// </summary>
    public partial class ItemAnalytics
    {
        public ItemActivityStat? AllTime { get; set; }
        public ItemActivityStat? LastSevenDays { get; set; }
    }
}
