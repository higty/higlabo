using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/attacksimulationrepeatoffender?view=graph-rest-1.0
    /// </summary>
    public partial class AttackSimulationRepeatOffender
    {
        public AttackSimulationUser? AttackSimulationUser { get; set; }
        public Int32? RepeatOffenceCount { get; set; }
    }
}
