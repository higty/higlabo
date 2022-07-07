using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateParameter : IRestApiParameter
    {
        public enum IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateParameterWindowsHelloForBusinessPinUsage
        {
            Allowed,
            Required,
            Disallowed,
        }
        public enum IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateParameterEnablement
        {
            NotConfigured,
            Enabled,
            Disabled,
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public Int32? Priority { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public Int32? Version { get; set; }
        public Int32? PinMinimumLength { get; set; }
        public Int32? PinMaximumLength { get; set; }
        public IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateParameterWindowsHelloForBusinessPinUsage PinUppercaseCharactersUsage { get; set; }
        public IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateParameterWindowsHelloForBusinessPinUsage PinLowercaseCharactersUsage { get; set; }
        public IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateParameterWindowsHelloForBusinessPinUsage PinSpecialCharactersUsage { get; set; }
        public IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateParameterEnablement State { get; set; }
        public bool? SecurityDeviceRequired { get; set; }
        public bool? UnlockWithBiometricsEnabled { get; set; }
        public bool? RemotePassportEnabled { get; set; }
        public Int32? PinPreviousBlockCount { get; set; }
        public Int32? PinExpirationInDays { get; set; }
        public IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateParameterEnablement EnhancedBiometricsState { get; set; }
    }
    public partial class IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentwindowshelloforbusinessconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateResponse> IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateAsync()
        {
            var p = new IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateParameter, IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentwindowshelloforbusinessconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateResponse> IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateParameter, IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentwindowshelloforbusinessconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateResponse> IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateAsync(IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateParameter, IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentwindowshelloforbusinessconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateResponse> IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateAsync(IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateParameter, IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationCreateResponse>(parameter, cancellationToken);
        }
    }
}
