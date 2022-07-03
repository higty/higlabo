using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-auditing-auditproperty?view=graph-rest-1.0
    /// </summary>
    public partial class AuditProperty
    {
        public string DisplayName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}
