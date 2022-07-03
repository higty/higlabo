using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/schedulinggroup?view=graph-rest-1.0
    /// </summary>
    public partial class SchedulingGroup
    {
        public String? Id { get; set; }
        public String? DisplayName { get; set; }
        public bool IsActive { get; set; }
        public string[] UserIds { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
    }
}
