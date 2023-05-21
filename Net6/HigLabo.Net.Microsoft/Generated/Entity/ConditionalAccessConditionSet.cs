using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/conditionalaccessconditionset?view=graph-rest-1.0
    /// </summary>
    public partial class ConditionalAccessConditionSet
    {
        public enum ConditionalAccessConditionSetConditionalAccessClientApp
        {
            All,
            Browser,
            MobileAppsAndDesktopClients,
            ExchangeActiveSync,
            EasSupported,
            Other,
        }
        public enum ConditionalAccessConditionSetRiskLevel
        {
            Low,
            Medium,
            High,
            None,
            UnknownFutureValue,
        }

        public ConditionalAccessApplications? Applications { get; set; }
        public ConditionalAccessClientApplications? ClientApplications { get; set; }
        public ConditionalAccessConditionSetConditionalAccessClientApp ClientAppTypes { get; set; }
        public ConditionalAccessDevices? Devices { get; set; }
        public ConditionalAccessLocations? Locations { get; set; }
        public ConditionalAccessPlatforms? Platforms { get; set; }
        public ConditionalAccessConditionSetRiskLevel ServicePrincipalRiskLevels { get; set; }
        public ConditionalAccessConditionSetRiskLevel SignInRiskLevels { get; set; }
        public ConditionalAccessConditionSetRiskLevel UserRiskLevels { get; set; }
        public ConditionalAccessUsers? Users { get; set; }
    }
}
