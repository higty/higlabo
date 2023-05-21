using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/insights-resourcereference?view=graph-rest-1.0
    /// </summary>
    public partial class ResourceReference
    {
        public string? Id { get; set; }
        public string? Type { get; set; }
        public string? WebUrl { get; set; }
    }
}
