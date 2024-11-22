using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/file?view=graph-rest-1.0
/// </summary>
public partial class File
{
    public Hashes? Hashes { get; set; }
    public string? MimeType { get; set; }
}
