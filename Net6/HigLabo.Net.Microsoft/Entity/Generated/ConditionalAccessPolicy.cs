using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/conditionalaccesspolicy?view=graph-rest-1.0
    /// </summary>
    public partial class ConditionalAccessPolicy
    {
        public ConditionalAccessConditionSet? Conditions { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public string DisplayName { get; set; }
        public ConditionalAccessGrantControls? GrantControls { get; set; }
        public string Id { get; set; }
        public DateTimeOffset ModifiedDateTime { get; set; }
        public ConditionalAccessSessionControls? SessionControls { get; set; }
        public ConditionalAccessPolicyConditionalAccessPolicyState State { get; set; }
    }
}
