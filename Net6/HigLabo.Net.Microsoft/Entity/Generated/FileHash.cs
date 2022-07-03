using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/filehash?view=graph-rest-1.0
    /// </summary>
    public partial class FileHash
    {
        public FileHashFileHashType HashType { get; set; }
        public string HashValue { get; set; }
    }
}
