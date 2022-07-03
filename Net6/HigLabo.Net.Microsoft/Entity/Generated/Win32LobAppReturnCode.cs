using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-win32lobappreturncode?view=graph-rest-1.0
    /// </summary>
    public partial class Win32LobAppReturnCode
    {
        public Int32? ReturnCode { get; set; }
        public Win32LobAppReturnCodeWin32LobAppReturnCodeType Type { get; set; }
    }
}
