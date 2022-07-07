using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-win32lobapppowershellscriptrule?view=graph-rest-1.0
    /// </summary>
    public partial class Win32LobAppPowerShellScriptRule
    {
        public enum Win32LobAppPowerShellScriptRuleWin32LobAppRuleType
        {
            Detection,
            Requirement,
        }
        public enum Win32LobAppPowerShellScriptRuleRunAsAccountType
        {
            System,
            User,
        }
        public enum Win32LobAppPowerShellScriptRuleWin32LobAppPowerShellScriptRuleOperationType
        {
            NotConfigured,
            String,
            DateTime,
            Integer,
            Float,
            Version,
            Boolean,
        }
        public enum Win32LobAppPowerShellScriptRuleWin32LobAppRuleOperator
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
        public string DisplayName { get; set; }
        public bool EnforceSignatureCheck { get; set; }
        public bool RunAs32Bit { get; set; }
        public RunAsAccountType RunAsAccount { get; set; }
        public string ScriptContent { get; set; }
        public Win32LobAppPowerShellScriptRuleOperationType OperationType { get; set; }
        public Win32LobAppRuleOperator Operator { get; set; }
        public string ComparisonValue { get; set; }
    }
}
