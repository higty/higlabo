using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/resource?view=graph-rest-1.0
    /// </summary>
    public partial class OneNoteResource
    {
        public Stream? Content { get; set; }
        public string ContentUrl { get; set; }
    }
}
