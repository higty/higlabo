using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-fileencryptioninfo?view=graph-rest-1.0
    /// </summary>
    public partial class FileEncryptionInfo
    {
        public string? EncryptionKey { get; set; }
        public string? InitializationVector { get; set; }
        public string? Mac { get; set; }
        public string? MacKey { get; set; }
        public string? ProfileIdentifier { get; set; }
        public string? FileDigest { get; set; }
        public string? FileDigestAlgorithm { get; set; }
    }
}
