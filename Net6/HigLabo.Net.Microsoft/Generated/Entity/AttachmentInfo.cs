using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/attachmentinfo?view=graph-rest-1.0
    /// </summary>
    public partial class AttachmentInfo
    {
        public enum AttachmentInfoAttachmentType
        {
            File,
            Item,
            Reference,
        }

        public AttachmentInfoAttachmentType AttachmentType { get; set; }
        public string? ContentType { get; set; }
        public string? Name { get; set; }
        public Int64? Size { get; set; }
    }
}
