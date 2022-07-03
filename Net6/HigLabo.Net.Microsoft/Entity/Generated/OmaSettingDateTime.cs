using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-omasettingdatetime?view=graph-rest-1.0
    /// </summary>
    public partial class OmaSettingDateTime
    {
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string OmaUri { get; set; }
        public DateTimeOffset Value { get; set; }
    }
}
