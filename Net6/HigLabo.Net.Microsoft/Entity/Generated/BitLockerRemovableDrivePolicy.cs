using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-bitlockerremovabledrivepolicy?view=graph-rest-1.0
    /// </summary>
    public partial class BitLockerRemovableDrivePolicy
    {
        public BitLockerRemovableDrivePolicyBitLockerEncryptionMethod EncryptionMethod { get; set; }
        public bool RequireEncryptionForWriteAccess { get; set; }
        public bool BlockCrossOrganizationWriteAccess { get; set; }
    }
}
