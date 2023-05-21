using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/attacksimulationuser?view=graph-rest-1.0
    /// </summary>
    public partial class AttackSimulationUser
    {
        public string? DisplayName { get; set; }
        public string? Email { get; set; }
        public string? UserId { get; set; }
    }
}
