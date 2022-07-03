using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-omasettingstringxml?view=graph-rest-1.0
    /// </summary>
    public partial class OmaSettingStringXml
    {
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string OmaUri { get; set; }
        public string FileName { get; set; }
        public string Value { get; set; }
    }
}
