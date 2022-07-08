using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/nameditem?view=graph-rest-1.0
    /// </summary>
    public partial class NamedItem
    {
        public enum NamedItemstring
        {
            String,
            Integer,
            Double,
            Boolean,
            Range,
        }

        public string? Name { get; set; }
        public string? Comment { get; set; }
        public string? Scope { get; set; }
        public NamedItemstring Type { get; set; }
        public Json? Value { get; set; }
        public bool? Visible { get; set; }
        public Worksheet? Worksheet { get; set; }
    }
}
