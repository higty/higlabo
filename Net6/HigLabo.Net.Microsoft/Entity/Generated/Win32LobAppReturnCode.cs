using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-win32lobappreturncode?view=graph-rest-1.0
    /// </summary>
    public partial class Win32LobAppReturnCode
    {
        public enum Win32LobAppReturnCodeWin32LobAppReturnCodeType
        {
            Failed,
            Success,
            SoftReboot,
            HardReboot,
            Retry,
        }

        public Int32? ReturnCode { get; set; }
        public Win32LobAppReturnCodeType? Type { get; set; }
    }
}
