using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-settingsource?view=graph-rest-1.0
    /// </summary>
    public partial class SettingSource
    {
        public enum SettingSourceSettingSourceType
        {
            DeviceConfiguration,
            DeviceIntent,
        }

        public string Id { get; set; }
        public string DisplayName { get; set; }
        public SettingSourceType SourceType { get; set; }
    }
}
