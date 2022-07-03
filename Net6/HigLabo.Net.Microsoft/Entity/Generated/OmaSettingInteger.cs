using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-omasettinginteger?view=graph-rest-1.0
    /// </summary>
    public partial class OmaSettingInteger
    {
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string OmaUri { get; set; }
        public Int32? Value { get; set; }
    }
}
