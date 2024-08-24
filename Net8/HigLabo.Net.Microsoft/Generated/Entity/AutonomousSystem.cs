using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-autonomoussystem?view=graph-rest-1.0
    /// </summary>
    public partial class AutonomousSystem
    {
        public string? Name { get; set; }
        public Int32? Number { get; set; }
        public string? Organization { get; set; }
        public string? Value { get; set; }
    }
}
