using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/conditionalaccessconditionset?view=graph-rest-1.0
    /// </summary>
    public partial class ConditionalAccessConditionSet
    {
        public ConditionalAccessApplications? Applications { get; set; }
        public ConditionalAccessUsers? Users { get; set; }
        public ConditionalAccessClientApplications? ClientApplications { get; set; }
        public ConditionalAccessConditionSetConditionalAccessClientApp ClientAppTypes { get; set; }
        public ConditionalAccessDevices? Devices { get; set; }
        public ConditionalAccessLocations? Locations { get; set; }
        public ConditionalAccessPlatforms? Platforms { get; set; }
        public ConditionalAccessConditionSetRiskLevel SignInRiskLevels { get; set; }
        public ConditionalAccessConditionSetRiskLevel UserRiskLevels { get; set; }
    }
}
