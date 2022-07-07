using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-win32lobappregistryrule?view=graph-rest-1.0
    /// </summary>
    public partial class Win32LobAppRegistryRule
    {
        public enum Win32LobAppRegistryRuleWin32LobAppRuleType
        {
            Detection,
            Requirement,
        }
        public enum Win32LobAppRegistryRuleWin32LobAppRegistryRuleOperationType
        {
            NotConfigured,
            Exists,
            DoesNotExist,
            String,
            Integer,
            Version,
        }
        public enum Win32LobAppRegistryRuleWin32LobAppRuleOperator
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
        public bool Check32BitOn64System { get; set; }
        public string KeyPath { get; set; }
        public string ValueName { get; set; }
        public Win32LobAppRegistryRuleOperationType OperationType { get; set; }
        public Win32LobAppRuleOperator Operator { get; set; }
        public string ComparisonValue { get; set; }
    }
}
