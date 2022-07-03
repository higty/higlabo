using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/sortproperty?view=graph-rest-1.0
    /// </summary>
    public partial class SortProperty
    {
        public string Name { get; set; }
        public bool IsDescending { get; set; }
    }
}
