using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/searchalterationoptions?view=graph-rest-1.0
    /// </summary>
    public partial class SearchAlterationOptions
    {
        public bool? EnableModification { get; set; }
        public bool? EnableSuggestion { get; set; }
    }
}
