
namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/filehash?view=graph-rest-1.0
    /// </summary>
    public enum FileHashFileHashType
    {
        Unknown,
        Sha1,
        Sha256,
        Md5,
        AuthenticodeHash256,
        LsHash,
        Ctph,
        PeSha1,
        PeSha256,
    }
}
