using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/fileattachment?view=graph-rest-1.0
    /// </summary>
    public partial class FileAttachment
    {
        public string ContentBytes { get; set; }
        public string ContentId { get; set; }
        public string ContentLocation { get; set; }
        public string ContentType { get; set; }
        public string Id { get; set; }
        public bool IsInline { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public string Name { get; set; }
        public Int32? Size { get; set; }
    }
}
