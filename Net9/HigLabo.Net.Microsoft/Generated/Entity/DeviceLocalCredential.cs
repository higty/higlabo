using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/devicelocalcredential?view=graph-rest-1.0
/// </summary>
public partial class DeviceLocalCredential
{
    public string? AccountName { get; set; }
    public string? AccountSid { get; set; }
    public DateTimeOffset? BackupDateTime { get; set; }
    public string? PasswordBase64 { get; set; }
}
