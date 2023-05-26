using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/entitlementmanagementschedule?view=graph-rest-1.0
    /// </summary>
    public partial class EntitlementManagementSchedule
    {
        public ExpirationPattern? Expiration { get; set; }
        public PatternedRecurrence? Recurrence { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
    }
}
