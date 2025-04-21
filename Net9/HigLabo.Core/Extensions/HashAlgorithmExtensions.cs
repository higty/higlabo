using System.Security.Cryptography;
using System.Text;

namespace HigLabo.Core;
public static class HashAlgorithmExtensions
{
    public static string ComputeFileHash(this HashAlgorithm algorithm, byte[] data)
    {
        return ComputeFileHash(algorithm, new MemoryStream(data));
    }
    public static string ComputeFileHash(this HashAlgorithm algorithm, Stream stream)
    {
        var bs = algorithm.ComputeHash(stream);
        return BitConverter.ToString(bs).ToLower().Replace("-", "");
    }
}
