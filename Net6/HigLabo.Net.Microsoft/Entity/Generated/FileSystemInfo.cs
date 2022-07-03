using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/filesysteminfo?view=graph-rest-1.0
    /// </summary>
    public partial class FileSystemInfo
    {
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset LastAccessedDateTime { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
    }
}
