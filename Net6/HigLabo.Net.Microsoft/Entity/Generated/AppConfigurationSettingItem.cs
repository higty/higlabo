using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-appconfigurationsettingitem?view=graph-rest-1.0
    /// </summary>
    public partial class AppConfigurationSettingItem
    {
        public enum AppConfigurationSettingItemMdmAppConfigKeyType
        {
            StringType,
            IntegerType,
            RealType,
            BooleanType,
            TokenType,
        }

        public string? AppConfigKey { get; set; }
        public MdmAppConfigKeyType? AppConfigKeyType { get; set; }
        public string? AppConfigKeyValue { get; set; }
    }
}
