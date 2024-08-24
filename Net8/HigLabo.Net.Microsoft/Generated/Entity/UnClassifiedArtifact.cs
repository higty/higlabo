using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-unclassifiedartifact?view=graph-rest-1.0
    /// </summary>
    public partial class UnClassifiedArtifact
    {
        public string? Id { get; set; }
        public string? Kind { get; set; }
        public string? Value { get; set; }
    }
}
