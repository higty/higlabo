using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/windowssettinginstance?view=graph-rest-1.0
/// </summary>
public partial class WindowsSettingInstance
{
    public DateTimeOffset? CreatedDateTime { get; set; }
    public DateTimeOffset? ExpirationDateTime { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public string? Payload { get; set; }
}
