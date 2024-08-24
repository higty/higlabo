using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/backuprestoreroot?view=graph-rest-1.0
    /// </summary>
    public partial class BackupReStoreRoot
    {
        public string? Id { get; set; }
        public ServiceStatus? ServiceStatus { get; set; }
        public DriveProtectionRule[]? DriveInclusionRules { get; set; }
        public DriveProtectionUnit[]? DriveProtectionUnits { get; set; }
        public ExChangeProtectionPolicy[]? ExchangeProtectionPolicies { get; set; }
        public ExChangeReStoreSession[]? ExchangeRestoreSessions { get; set; }
        public MailboxProtectionRule[]? MailboxInclusionRules { get; set; }
        public MailboxProtectionUnit[]? MailboxProtectionUnits { get; set; }
        public OneDriveForBusinessProtectionPolicy[]? OneDriveForBusinessProtectionPolicies { get; set; }
        public OneDriveForBusinessReStoreSession[]? OneDriveForBusinessRestoreSessions { get; set; }
        public ProtectionPolicyBase[]? ProtectionPolicies { get; set; }
        public ProtectionUnitBase[]? ProtectionUnits { get; set; }
        public ReStorePoint[]? RestorePoints { get; set; }
        public ReStoreSessionBase[]? RestoreSessions { get; set; }
        public ServiceApp[]? ServiceApps { get; set; }
        public SharePointProtectionPolicy[]? SharePointProtectionPolicies { get; set; }
        public SharePointReStoreSession[]? SharePointRestoreSessions { get; set; }
        public SiteProtectionRule[]? SiteInclusionRules { get; set; }
        public SiteProtectionUnit[]? SiteProtectionUnits { get; set; }
    }
}
