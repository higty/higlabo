using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-windowsinformationprotectionstoreapp?view=graph-rest-1.0
    /// </summary>
    public partial class WindowsInformationProtectionStoreApp
    {
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string PublisherName { get; set; }
        public string ProductName { get; set; }
        public bool Denied { get; set; }
    }
}
