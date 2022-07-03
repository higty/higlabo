using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/nameditem?view=graph-rest-1.0
    /// </summary>
    public partial class NamedItem
    {
        public String? Name { get; set; }
        public String? Comment { get; set; }
        public String? Scope { get; set; }
        public NamedItemString Type { get; set; }
        public Json? Value { get; set; }
        public Boolean? Visible { get; set; }
    }
}
