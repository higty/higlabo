using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-filedetails?view=graph-rest-1.0
/// </summary>
public partial class FileDetails
{
    public string? FileName { get; set; }
    public string? FilePath { get; set; }
    public string? FilePublisher { get; set; }
    public Int64? FileSize { get; set; }
    public string? Issuer { get; set; }
    public string? Sha1 { get; set; }
    public string? Sha256 { get; set; }
    public string? Signer { get; set; }
}
