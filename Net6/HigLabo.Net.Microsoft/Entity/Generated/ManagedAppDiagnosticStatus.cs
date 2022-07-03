using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-managedappdiagnosticstatus?view=graph-rest-1.0
    /// </summary>
    public partial class ManagedAppDiagnosticStatus
    {
        public string ValidationName { get; set; }
        public string State { get; set; }
        public string MitigationInstruction { get; set; }
    }
}
