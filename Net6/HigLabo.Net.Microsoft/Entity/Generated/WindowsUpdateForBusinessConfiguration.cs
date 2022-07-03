using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-windowsupdateforbusinessconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class WindowsUpdateForBusinessConfiguration
    {
        public string Id { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public Int32? Version { get; set; }
        public WindowsUpdateForBusinessConfigurationWindowsDeliveryOptimizationMode DeliveryOptimizationMode { get; set; }
        public WindowsUpdateForBusinessConfigurationPrereleaseFeatures PrereleaseFeatures { get; set; }
        public WindowsUpdateForBusinessConfigurationAutomaticUpdateMode AutomaticUpdateMode { get; set; }
        public bool MicrosoftUpdateServiceAllowed { get; set; }
        public bool DriversExcluded { get; set; }
        public WindowsUpdateInstallScheduleType? InstallationSchedule { get; set; }
        public Int32? QualityUpdatesDeferralPeriodInDays { get; set; }
        public Int32? FeatureUpdatesDeferralPeriodInDays { get; set; }
        public bool QualityUpdatesPaused { get; set; }
        public bool FeatureUpdatesPaused { get; set; }
        public DateTimeOffset QualityUpdatesPauseExpiryDateTime { get; set; }
        public DateTimeOffset FeatureUpdatesPauseExpiryDateTime { get; set; }
        public WindowsUpdateForBusinessConfigurationWindowsUpdateType BusinessReadyUpdatesOnly { get; set; }
    }
}
