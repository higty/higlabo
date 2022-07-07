using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/conditionalaccesslocations?view=graph-rest-1.0
    /// </summary>
    public partial class ConditionalAccessLocations
    {
        public String[]? IncludeLocations { get; set; }
        public String[]? ExcludeLocations { get; set; }
    }
}
