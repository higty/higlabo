using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/optionalclaim?view=graph-rest-1.0
    /// </summary>
    public partial class OptionalClaim
    {
        public String[]? AdditionalProperties { get; set; }
        public bool? Essential { get; set; }
        public string? Name { get; set; }
        public string? Source { get; set; }
    }
}
