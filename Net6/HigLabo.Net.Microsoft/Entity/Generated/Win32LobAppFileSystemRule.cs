using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-win32lobappfilesystemrule?view=graph-rest-1.0
    /// </summary>
    public partial class Win32LobAppFileSystemRule
    {
        public Win32LobAppFileSystemRuleWin32LobAppRuleType RuleType { get; set; }
        public string Path { get; set; }
        public string FileOrFolderName { get; set; }
        public bool Check32BitOn64System { get; set; }
        public Win32LobAppFileSystemRuleWin32LobAppFileSystemOperationType OperationType { get; set; }
        public Win32LobAppFileSystemRuleWin32LobAppRuleOperator Operator { get; set; }
        public string ComparisonValue { get; set; }
    }
}
