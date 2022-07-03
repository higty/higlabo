using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-devices-deleteuserfromsharedappledeviceactionresult?view=graph-rest-1.0
    /// </summary>
    public partial class DeleteUserFromSharedAppleDeviceActionResult
    {
        public string ActionName { get; set; }
        public DeleteUserFromSharedAppleDeviceActionResultActionState ActionState { get; set; }
        public DateTimeOffset StartDateTime { get; set; }
        public DateTimeOffset LastUpdatedDateTime { get; set; }
        public string UserPrincipalName { get; set; }
    }
}
