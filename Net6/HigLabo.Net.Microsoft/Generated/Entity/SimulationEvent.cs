using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/simulationevent?view=graph-rest-1.0
    /// </summary>
    public partial class SimulationEvent
    {
        public Int32? Count { get; set; }
        public string? EventName { get; set; }
    }
}
