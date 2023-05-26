using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/idlesessionsignout?view=graph-rest-1.0
    /// </summary>
    public partial class IdleSessionSignOut
    {
        public bool? IsEnabled { get; set; }
        public Int64? SignOutAfterInSeconds { get; set; }
        public Int64? WarnAfterInSeconds { get; set; }
    }
}
