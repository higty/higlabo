using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/driveitemversion?view=graph-rest-1.0
    /// </summary>
    public partial class DriveItemVersion
    {
        public Stream? Content { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public TimeStamp? LastModifiedDateTime { get; set; }
        public PublicationFacet? Publication { get; set; }
        public Int64? Size { get; set; }
    }
}
