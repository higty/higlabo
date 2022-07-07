using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindowsupdateforbusinessconfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations_DeviceConfigurationId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations_DeviceConfigurationId: return $"/deviceManagement/deviceConfigurations/{DeviceConfigurationId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string DeviceConfigurationId { get; set; }
    }
    public partial class IntuneDeviceconfigWindowsupdateforbusinessconfigurationGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsupdateforbusinessconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsupdateforbusinessconfigurationGetResponse> IntuneDeviceconfigWindowsupdateforbusinessconfigurationGetAsync()
        {
            var p = new IntuneDeviceconfigWindowsupdateforbusinessconfigurationGetParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsupdateforbusinessconfigurationGetParameter, IntuneDeviceconfigWindowsupdateforbusinessconfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsupdateforbusinessconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsupdateforbusinessconfigurationGetResponse> IntuneDeviceconfigWindowsupdateforbusinessconfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindowsupdateforbusinessconfigurationGetParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsupdateforbusinessconfigurationGetParameter, IntuneDeviceconfigWindowsupdateforbusinessconfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsupdateforbusinessconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsupdateforbusinessconfigurationGetResponse> IntuneDeviceconfigWindowsupdateforbusinessconfigurationGetAsync(IntuneDeviceconfigWindowsupdateforbusinessconfigurationGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsupdateforbusinessconfigurationGetParameter, IntuneDeviceconfigWindowsupdateforbusinessconfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsupdateforbusinessconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsupdateforbusinessconfigurationGetResponse> IntuneDeviceconfigWindowsupdateforbusinessconfigurationGetAsync(IntuneDeviceconfigWindowsupdateforbusinessconfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsupdateforbusinessconfigurationGetParameter, IntuneDeviceconfigWindowsupdateforbusinessconfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
