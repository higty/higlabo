using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-registryvalueevidence?view=graph-rest-1.0
/// </summary>
public partial class RegistryValueEvidence
{
    public string? RegistryHive { get; set; }
    public string? RegistryKey { get; set; }
    public string? RegistryValue { get; set; }
    public string? RegistryValueName { get; set; }
    public string? RegistryValueType { get; set; }
}
