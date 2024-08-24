using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/attributeset?view=graph-rest-1.0
    /// </summary>
    public partial class AttributeSet
    {
        public string? Description { get; set; }
        public string? Id { get; set; }
        public Int32? MaxAttributesPerSet { get; set; }
    }
}
