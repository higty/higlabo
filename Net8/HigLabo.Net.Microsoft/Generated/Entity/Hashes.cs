using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/hashes?view=graph-rest-1.0
/// </summary>
public partial class Hashes
{
    public string? Crc32Hash { get; set; }
    public string? QuickXorHash { get; set; }
    public string? Sha1Hash { get; set; }
    public string? Sha256Hash { get; set; }
}
