
namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-mdmwindowsinformationprotectionpolicy?view=graph-rest-1.0
    /// </summary>
    public enum MdmWindowsInformationProtectionPolicyWindowsInformationProtectionEnforcementLevel
    {
        NoProtection,
        EncryptAndAuditOnly,
        EncryptAuditAndPrompt,
        EncryptAuditAndBlock,
    }
}
