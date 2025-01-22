using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/windowssetting?view=graph-rest-1.0
/// </summary>
public partial class WindowsSetting
{
    public enum WindowsSettingWindowsSettingType
    {
        Roaming,
        Backup,
        UnknownFutureValue,
    }

    public string? Id { get; set; }
    public string? PayloadType { get; set; }
    public WindowsSettingWindowsSettingType SettingType { get; set; }
    public string? WindowsDeviceId { get; set; }
    public WindowsSettingInstance[]? Instances { get; set; }
}
