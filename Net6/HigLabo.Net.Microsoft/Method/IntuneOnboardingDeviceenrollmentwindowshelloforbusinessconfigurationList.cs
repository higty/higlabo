using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceEnrollmentConfigurations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceEnrollmentConfigurations: return $"/deviceManagement/deviceEnrollmentConfigurations";
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
    public partial class IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-deviceenrollmentwindowshelloforbusinessconfiguration?view=graph-rest-1.0
        /// </summary>
        public partial class DeviceEnrollmentWindowsHelloForBusinessConfiguration
        {
            public enum DeviceEnrollmentWindowsHelloForBusinessConfigurationWindowsHelloForBusinessPinUsage
            {
                Allowed,
                Required,
                Disallowed,
            }
            public enum DeviceEnrollmentWindowsHelloForBusinessConfigurationEnablement
            {
                NotConfigured,
                Enabled,
                Disabled,
            }

            public string? Id { get; set; }
            public string? DisplayName { get; set; }
            public string? Description { get; set; }
            public Int32? Priority { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public Int32? Version { get; set; }
            public Int32? PinMinimumLength { get; set; }
            public Int32? PinMaximumLength { get; set; }
            public WindowsHelloForBusinessPinUsage? PinUppercaseCharactersUsage { get; set; }
            public WindowsHelloForBusinessPinUsage? PinLowercaseCharactersUsage { get; set; }
            public WindowsHelloForBusinessPinUsage? PinSpecialCharactersUsage { get; set; }
            public Enablement? State { get; set; }
            public bool? SecurityDeviceRequired { get; set; }
            public bool? UnlockWithBiometricsEnabled { get; set; }
            public bool? RemotePassportEnabled { get; set; }
            public Int32? PinPreviousBlockCount { get; set; }
            public Int32? PinExpirationInDays { get; set; }
            public Enablement? EnhancedBiometricsState { get; set; }
        }

        public DeviceEnrollmentWindowsHelloForBusinessConfiguration[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentwindowshelloforbusinessconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationListResponse> IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationListAsync()
        {
            var p = new IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationListParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationListParameter, IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentwindowshelloforbusinessconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationListResponse> IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationListParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationListParameter, IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentwindowshelloforbusinessconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationListResponse> IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationListAsync(IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationListParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationListParameter, IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentwindowshelloforbusinessconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationListResponse> IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationListAsync(IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationListParameter, IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationListResponse>(parameter, cancellationToken);
        }
    }
}
