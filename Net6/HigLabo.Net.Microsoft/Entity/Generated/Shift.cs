using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/shift?view=graph-rest-1.0
    /// </summary>
    public partial class Shift
    {
        public String? Id { get; set; }
        public String? UserId { get; set; }
        public String? SchedulingGroupId { get; set; }
        public ShiftItem? SharedShift { get; set; }
        public ShiftItem? DraftShift { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
    }
}
