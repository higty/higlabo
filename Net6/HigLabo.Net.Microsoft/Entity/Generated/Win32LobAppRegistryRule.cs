using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-win32lobappregistryrule?view=graph-rest-1.0
    /// </summary>
    public partial class Win32LobAppRegistryRule
    {
        public Win32LobAppRegistryRuleWin32LobAppRuleType RuleType { get; set; }
        public bool Check32BitOn64System { get; set; }
        public string KeyPath { get; set; }
        public string ValueName { get; set; }
        public Win32LobAppRegistryRuleWin32LobAppRegistryRuleOperationType OperationType { get; set; }
        public Win32LobAppRegistryRuleWin32LobAppRuleOperator Operator { get; set; }
        public string ComparisonValue { get; set; }
    }
}
