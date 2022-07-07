using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindows10teamgeneralconfigurationListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneDeviceconfigWindows10teamgeneralconfigurationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-windows10teamgeneralconfiguration?view=graph-rest-1.0
        /// </summary>
        public partial class Windows10TeamGeneralConfiguration
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

        public Windows10TeamGeneralConfiguration[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10teamgeneralconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10teamgeneralconfigurationListResponse> IntuneDeviceconfigWindows10teamgeneralconfigurationListAsync()
        {
            var p = new IntuneDeviceconfigWindows10teamgeneralconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10teamgeneralconfigurationListParameter, IntuneDeviceconfigWindows10teamgeneralconfigurationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10teamgeneralconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10teamgeneralconfigurationListResponse> IntuneDeviceconfigWindows10teamgeneralconfigurationListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindows10teamgeneralconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10teamgeneralconfigurationListParameter, IntuneDeviceconfigWindows10teamgeneralconfigurationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10teamgeneralconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10teamgeneralconfigurationListResponse> IntuneDeviceconfigWindows10teamgeneralconfigurationListAsync(IntuneDeviceconfigWindows10teamgeneralconfigurationListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10teamgeneralconfigurationListParameter, IntuneDeviceconfigWindows10teamgeneralconfigurationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10teamgeneralconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10teamgeneralconfigurationListResponse> IntuneDeviceconfigWindows10teamgeneralconfigurationListAsync(IntuneDeviceconfigWindows10teamgeneralconfigurationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10teamgeneralconfigurationListParameter, IntuneDeviceconfigWindows10teamgeneralconfigurationListResponse>(parameter, cancellationToken);
        }
    }
}
