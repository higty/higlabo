using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/simulationreportoverview?view=graph-rest-1.0
    /// </summary>
    public partial class SimulationReportOverview
    {
        public RecommendedAction[]? RecommendedActions { get; set; }
        public Int32? ResolvedTargetsCount { get; set; }
        public SimulationEventsContent? SimulationEventsContent { get; set; }
        public TrainingEventsContent? TrainingEventsContent { get; set; }
    }
}
