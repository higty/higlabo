using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/simulationeventscontent?view=graph-rest-1.0
    /// </summary>
    public partial class SimulationEventsContent
    {
        public Double? CompromisedRate { get; set; }
        public SimulationEvent[]? Events { get; set; }
    }
}
