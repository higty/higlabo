using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/thumbnail?view=graph-rest-1.0
    /// </summary>
    public partial class Thumbnail
    {
        public Int32? Height { get; set; }
        public string SourceItemId { get; set; }
        public string Url { get; set; }
        public Int32? Width { get; set; }
        public Stream? Content { get; set; }
    }
}
