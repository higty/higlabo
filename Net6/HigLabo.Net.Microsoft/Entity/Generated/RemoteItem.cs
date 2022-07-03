using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/remoteitem?view=graph-rest-1.0
    /// </summary>
    public partial class RemoteItem
    {
        public IdentitySet? CreatedBy { get; set; }
        public string CreatedDateTime { get; set; }
        public File? File { get; set; }
        public FileSystemInfo? FileSystemInfo { get; set; }
        public Folder? Folder { get; set; }
        public string Id { get; set; }
        public Image? Image { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public string LastModifiedDateTime { get; set; }
        public string Name { get; set; }
        public Package? Package { get; set; }
        public ItemReference? ParentReference { get; set; }
        public Shared? Shared { get; set; }
        public SharePointIds SharepointIds { get; set; }
        public Int64? Size { get; set; }
        public SpecialFolder? SpecialFolder { get; set; }
        public Video? Video { get; set; }
        public string WebDavUrl { get; set; }
        public string WebUrl { get; set; }
    }
}
