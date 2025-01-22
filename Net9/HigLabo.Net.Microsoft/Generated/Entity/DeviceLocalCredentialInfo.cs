using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/devicelocalcredentialinfo?view=graph-rest-1.0
/// </summary>
public partial class DeviceLocalCredentialInfo
{
    public DeviceLocalCredential[]? Credentials { get; set; }
    public string? DeviceName { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastBackupDateTime { get; set; }
    public DateTimeOffset? RefreshDateTime { get; set; }
}
