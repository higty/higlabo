using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/privilegedaccessgroupeligibilityscheduleinstance?view=graph-rest-1.0
    /// </summary>
    public partial class PrivilegedAccessGroupEligibilityScheduleInstance
    {
        public enum PrivilegedAccessGroupEligibilityScheduleInstancePrivilegedAccessGroupRelationships
        {
            Owner,
            Member,
            Eq,
        }
        public enum PrivilegedAccessGroupEligibilityScheduleInstancePrivilegedAccessGroupMemberType
        {
            Direct,
            Group,
            UnknownFutureValue,
            Eq,
        }

        public PrivilegedAccessGroupEligibilityScheduleInstancePrivilegedAccessGroupRelationships AccessId { get; set; }
        public string? EligibilityScheduleId { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
        public string? GroupId { get; set; }
        public string? Id { get; set; }
        public PrivilegedAccessGroupEligibilityScheduleInstancePrivilegedAccessGroupMemberType MemberType { get; set; }
        public string? PrincipalId { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public Group? Group { get; set; }
        public DirectoryObject? Principal { get; set; }
    }
}
