using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-devicecompliancescheduledactionforrule?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceComplianceScheduledActionForRule
    {
        public string? Id { get; set; }
        public string? RuleName { get; set; }
    }
}
