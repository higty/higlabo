using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindowsupdateforbusinessconfigurationListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class IntuneDeviceconfigWindowsupdateforbusinessconfigurationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-windowsupdateforbusinessconfiguration?view=graph-rest-1.0
        /// </summary>
        public partial class WindowsUpdateForBusinessConfiguration
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

        public WindowsUpdateForBusinessConfiguration[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsupdateforbusinessconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsupdateforbusinessconfigurationListResponse> IntuneDeviceconfigWindowsupdateforbusinessconfigurationListAsync()
        {
            var p = new IntuneDeviceconfigWindowsupdateforbusinessconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsupdateforbusinessconfigurationListParameter, IntuneDeviceconfigWindowsupdateforbusinessconfigurationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsupdateforbusinessconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsupdateforbusinessconfigurationListResponse> IntuneDeviceconfigWindowsupdateforbusinessconfigurationListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindowsupdateforbusinessconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsupdateforbusinessconfigurationListParameter, IntuneDeviceconfigWindowsupdateforbusinessconfigurationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsupdateforbusinessconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsupdateforbusinessconfigurationListResponse> IntuneDeviceconfigWindowsupdateforbusinessconfigurationListAsync(IntuneDeviceconfigWindowsupdateforbusinessconfigurationListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsupdateforbusinessconfigurationListParameter, IntuneDeviceconfigWindowsupdateforbusinessconfigurationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsupdateforbusinessconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsupdateforbusinessconfigurationListResponse> IntuneDeviceconfigWindowsupdateforbusinessconfigurationListAsync(IntuneDeviceconfigWindowsupdateforbusinessconfigurationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsupdateforbusinessconfigurationListParameter, IntuneDeviceconfigWindowsupdateforbusinessconfigurationListResponse>(parameter, cancellationToken);
        }
    }
}
