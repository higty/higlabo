using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/cloudpcusersetting?view=graph-rest-1.0
    /// </summary>
    public partial class CloudPcUserSetting
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public bool? LocalAdminEnabled { get; set; }
        public bool? ResetEnabled { get; set; }
        public CloudPcReStorePointSetting? RestorePointSetting { get; set; }
        public CloudPcUserSettingAssignment[]? Assignments { get; set; }
    }
}
