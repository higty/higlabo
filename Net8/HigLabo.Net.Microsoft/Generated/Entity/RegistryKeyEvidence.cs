using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-registrykeyevidence?view=graph-rest-1.0
    /// </summary>
    public partial class RegistryKeyEvidence
    {
        public string? RegistryHive { get; set; }
        public string? RegistryKey { get; set; }
    }
}
