using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-mobileappcontentfile?view=graph-rest-1.0
    /// </summary>
    public partial class MobileAppContentFile
    {
        public string AzureStorageUri { get; set; }
        public bool IsCommitted { get; set; }
        public string Id { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public string Name { get; set; }
        public Int64? Size { get; set; }
        public Int64? SizeEncrypted { get; set; }
        public DateTimeOffset AzureStorageUriExpirationDateTime { get; set; }
        public string Manifest { get; set; }
        public MobileAppContentFileMobileAppContentFileUploadState UploadState { get; set; }
    }
}
