using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateParameter : IRestApiParameter
    {
        public enum IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateParameterWindowsDeliveryOptimizationMode
        {
            UserDefined,
            HttpOnly,
            HttpWithPeeringNat,
            HttpWithPeeringPrivateGroup,
            HttpWithInternetPeering,
            SimpleDownload,
            BypassMode,
        }
        public enum IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateParameterPrereleaseFeatures
        {
            UserDefined,
            SettingsOnly,
            SettingsAndExperimentations,
            NotAllowed,
        }
        public enum IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateParameterAutomaticUpdateMode
        {
            UserDefined,
            NotifyDownload,
            AutoInstallAtMaintenanceTime,
            AutoInstallAndRebootAtMaintenanceTime,
            AutoInstallAndRebootAtScheduledTime,
            AutoInstallAndRebootWithoutEndUserControl,
        }
        public enum IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateParameterWindowsUpdateType
        {
            UserDefined,
            All,
            BusinessReadyOnly,
            WindowsInsiderBuildFast,
            WindowsInsiderBuildSlow,
            WindowsInsiderBuildRelease,
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations: return $"/deviceManagement/deviceConfigurations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateParameterWindowsDeliveryOptimizationMode DeliveryOptimizationMode { get; set; }
        public IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateParameterPrereleaseFeatures PrereleaseFeatures { get; set; }
        public IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateParameterAutomaticUpdateMode AutomaticUpdateMode { get; set; }
        public bool? MicrosoftUpdateServiceAllowed { get; set; }
        public bool? DriversExcluded { get; set; }
        public WindowsUpdateInstallScheduleType? InstallationSchedule { get; set; }
        public Int32? QualityUpdatesDeferralPeriodInDays { get; set; }
        public Int32? FeatureUpdatesDeferralPeriodInDays { get; set; }
        public bool? QualityUpdatesPaused { get; set; }
        public bool? FeatureUpdatesPaused { get; set; }
        public DateTimeOffset? QualityUpdatesPauseExpiryDateTime { get; set; }
        public DateTimeOffset? FeatureUpdatesPauseExpiryDateTime { get; set; }
        public IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateParameterWindowsUpdateType BusinessReadyUpdatesOnly { get; set; }
    }
    public partial class IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateResponse : RestApiResponse
    {
        public enum WindowsUpdateForBusinessConfigurationWindowsDeliveryOptimizationMode
        {
            UserDefined,
            HttpOnly,
            HttpWithPeeringNat,
            HttpWithPeeringPrivateGroup,
            HttpWithInternetPeering,
            SimpleDownload,
            BypassMode,
        }
        public enum WindowsUpdateForBusinessConfigurationPrereleaseFeatures
        {
            UserDefined,
            SettingsOnly,
            SettingsAndExperimentations,
            NotAllowed,
        }
        public enum WindowsUpdateForBusinessConfigurationAutomaticUpdateMode
        {
            UserDefined,
            NotifyDownload,
            AutoInstallAtMaintenanceTime,
            AutoInstallAndRebootAtMaintenanceTime,
            AutoInstallAndRebootAtScheduledTime,
            AutoInstallAndRebootWithoutEndUserControl,
        }
        public enum WindowsUpdateForBusinessConfigurationWindowsUpdateType
        {
            UserDefined,
            All,
            BusinessReadyOnly,
            WindowsInsiderBuildFast,
            WindowsInsiderBuildSlow,
            WindowsInsiderBuildRelease,
        }

        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public WindowsDeliveryOptimizationMode? DeliveryOptimizationMode { get; set; }
        public PrereleaseFeatures? PrereleaseFeatures { get; set; }
        public AutomaticUpdateMode? AutomaticUpdateMode { get; set; }
        public bool? MicrosoftUpdateServiceAllowed { get; set; }
        public bool? DriversExcluded { get; set; }
        public WindowsUpdateInstallScheduleType? InstallationSchedule { get; set; }
        public Int32? QualityUpdatesDeferralPeriodInDays { get; set; }
        public Int32? FeatureUpdatesDeferralPeriodInDays { get; set; }
        public bool? QualityUpdatesPaused { get; set; }
        public bool? FeatureUpdatesPaused { get; set; }
        public DateTimeOffset? QualityUpdatesPauseExpiryDateTime { get; set; }
        public DateTimeOffset? FeatureUpdatesPauseExpiryDateTime { get; set; }
        public WindowsUpdateType? BusinessReadyUpdatesOnly { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsupdateforbusinessconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateResponse> IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateAsync()
        {
            var p = new IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateParameter, IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsupdateforbusinessconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateResponse> IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateParameter, IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsupdateforbusinessconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateResponse> IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateAsync(IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateParameter, IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsupdateforbusinessconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateResponse> IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateAsync(IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateParameter, IntuneDeviceconfigWindowsupdateforbusinessconfigurationCreateResponse>(parameter, cancellationToken);
        }
    }
}
