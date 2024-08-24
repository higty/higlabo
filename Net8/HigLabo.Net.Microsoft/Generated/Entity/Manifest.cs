using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/partners-billing-manifest?view=graph-rest-1.0
    /// </summary>
    public partial class Manifest
    {
        public Int32? BlobCount { get; set; }
        public Blob[]? Blobs { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DataFormat { get; set; }
        public string? ETag { get; set; }
        public string? Id { get; set; }
        public string? PartitionType { get; set; }
        public string? PartnerTenantId { get; set; }
        public string? RootDirectory { get; set; }
        public string? SasToken { get; set; }
        public string? SchemaVersion { get; set; }
    }
}
