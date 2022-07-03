using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-win32lobapprule?view=graph-rest-1.0
    /// </summary>
    public partial class Win32LobAppRule
    {
        public Win32LobAppRuleWin32LobAppRuleType RuleType { get; set; }
    }
}
