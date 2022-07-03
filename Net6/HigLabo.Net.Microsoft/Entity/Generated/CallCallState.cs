
namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/call?view=graph-rest-1.0
    /// </summary>
    public enum CallCallState
    {
        Incoming,
        Establishing,
        Ringing,
        Established,
        Hold,
        Transferring,
        TransferAccepted,
        Redirecting,
        Terminating,
        Terminated,
    }
}
