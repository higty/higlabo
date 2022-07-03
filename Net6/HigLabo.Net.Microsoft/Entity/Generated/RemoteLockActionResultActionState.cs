
namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-devices-remotelockactionresult?view=graph-rest-1.0
    /// </summary>
    public enum RemoteLockActionResultActionState
    {
        None,
        Pending,
        Canceled,
        Active,
        Done,
        Failed,
        NotSupported,
    }
}
