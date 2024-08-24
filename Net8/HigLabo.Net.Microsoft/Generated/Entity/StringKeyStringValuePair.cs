using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-stringkeystringvaluepair?view=graph-rest-1.0
    /// </summary>
    public partial class StringKeyStringValuePair
    {
        public string? Key { get; set; }
        public string? Value { get; set; }
    }
}
