using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-win32lobappproductcoderule?view=graph-rest-1.0
    /// </summary>
    public partial class Win32LobAppProductCodeRule
    {
        public enum Win32LobAppProductCodeRuleWin32LobAppRuleType
        {
            Detection,
            Requirement,
        }
        public enum Win32LobAppProductCodeRuleWin32LobAppRuleOperator
        {
            NotConfigured,
            Equal,
            NotEqual,
            GreaterThan,
            GreaterThanOrEqual,
            LessThan,
            LessThanOrEqual,
        }

        public Win32LobAppRuleType RuleType { get; set; }
        public string ProductCode { get; set; }
        public Win32LobAppRuleOperator ProductVersionOperator { get; set; }
        public string ProductVersion { get; set; }
    }
}
