using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/sortproperty?view=graph-rest-1.0
    /// </summary>
    public partial class SortProperty
    {
        public bool? IsDescending { get; set; }
        public string? Name { get; set; }
    }
}
