
namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-windowsinformationprotection?view=graph-rest-1.0
    /// </summary>
    public enum WindowsInformationProtectionWindowsInformationProtectionEnforcementLevel
    {
        NoProtection,
        EncryptAndAuditOnly,
        EncryptAuditAndPrompt,
        EncryptAuditAndBlock,
    }
}
