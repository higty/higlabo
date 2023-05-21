using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/conditionalaccessdevices?view=graph-rest-1.0
    /// </summary>
    public partial class ConditionalAccessDevices
    {
        public ConditionalAccessFilter? DeviceFilter { get; set; }
    }
}
