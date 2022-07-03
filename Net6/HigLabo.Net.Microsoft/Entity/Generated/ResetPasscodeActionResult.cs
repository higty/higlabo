using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-devices-resetpasscodeactionresult?view=graph-rest-1.0
    /// </summary>
    public partial class ResetPasscodeActionResult
    {
        public string ActionName { get; set; }
        public ResetPasscodeActionResultActionState ActionState { get; set; }
        public DateTimeOffset StartDateTime { get; set; }
        public DateTimeOffset LastUpdatedDateTime { get; set; }
        public string Passcode { get; set; }
    }
}
