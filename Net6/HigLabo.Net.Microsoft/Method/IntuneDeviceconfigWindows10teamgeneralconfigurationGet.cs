using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindows10teamgeneralconfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneDeviceconfigWindows10teamgeneralconfigurationGetResponse : RestApiResponse
    {
        public enum Windows10TeamGeneralConfigurationMiracastChannel
        {
            UserDefined,
            One,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Eleven,
            ThirtySix,
            Forty,
            FortyFour,
            FortyEight,
            OneHundredFortyNine,
            OneHundredFiftyThree,
            OneHundredFiftySeven,
            OneHundredSixtyOne,
            OneHundredSixtyFive,
        }
        public enum Windows10TeamGeneralConfigurationWelcomeScreenMeetingInformation
        {
            UserDefined,
            ShowOrganizerAndTimeOnly,
            ShowOrganizerAndTimeAndSubject,
        }

        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public bool? AzureOperationalInsightsBlockTelemetry { get; set; }
        public string? AzureOperationalInsightsWorkspaceId { get; set; }
        public string? AzureOperationalInsightsWorkspaceKey { get; set; }
        public bool? ConnectAppBlockAutoLaunch { get; set; }
        public bool? MaintenanceWindowBlocked { get; set; }
        public Int32? MaintenanceWindowDurationInHours { get; set; }
        public TimeOnly? MaintenanceWindowStartTime { get; set; }
        public MiracastChannel? MiracastChannel { get; set; }
        public bool? MiracastBlocked { get; set; }
        public bool? MiracastRequirePin { get; set; }
        public bool? SettingsBlockMyMeetingsAndFiles { get; set; }
        public bool? SettingsBlockSessionResume { get; set; }
        public bool? SettingsBlockSigninSuggestions { get; set; }
        public Int32? SettingsDefaultVolume { get; set; }
        public Int32? SettingsScreenTimeoutInMinutes { get; set; }
        public Int32? SettingsSessionTimeoutInMinutes { get; set; }
        public Int32? SettingsSleepTimeoutInMinutes { get; set; }
        public bool? WelcomeScreenBlockAutomaticWakeUp { get; set; }
        public string? WelcomeScreenBackgroundImageUrl { get; set; }
        public WelcomeScreenMeetingInformation? WelcomeScreenMeetingInformation { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10teamgeneralconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10teamgeneralconfigurationGetResponse> IntuneDeviceconfigWindows10teamgeneralconfigurationGetAsync()
        {
            var p = new IntuneDeviceconfigWindows10teamgeneralconfigurationGetParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10teamgeneralconfigurationGetParameter, IntuneDeviceconfigWindows10teamgeneralconfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10teamgeneralconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10teamgeneralconfigurationGetResponse> IntuneDeviceconfigWindows10teamgeneralconfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindows10teamgeneralconfigurationGetParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10teamgeneralconfigurationGetParameter, IntuneDeviceconfigWindows10teamgeneralconfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10teamgeneralconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10teamgeneralconfigurationGetResponse> IntuneDeviceconfigWindows10teamgeneralconfigurationGetAsync(IntuneDeviceconfigWindows10teamgeneralconfigurationGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10teamgeneralconfigurationGetParameter, IntuneDeviceconfigWindows10teamgeneralconfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10teamgeneralconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10teamgeneralconfigurationGetResponse> IntuneDeviceconfigWindows10teamgeneralconfigurationGetAsync(IntuneDeviceconfigWindows10teamgeneralconfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10teamgeneralconfigurationGetParameter, IntuneDeviceconfigWindows10teamgeneralconfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
