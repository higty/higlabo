using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigIoscompliancepolicyCreateParameter : IRestApiParameter
    {
        public enum IntuneDeviceconfigIoscompliancepolicyCreateParameterRequiredPasswordType
        {
            DeviceDefault,
            Alphanumeric,
            Numeric,
        }
        public enum IntuneDeviceconfigIoscompliancepolicyCreateParameterDeviceThreatProtectionLevel
        {
            Unavailable,
            Secured,
            Low,
            Medium,
            High,
            NotSet,
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceCompliancePolicies,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicies: return $"/deviceManagement/deviceCompliancePolicies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public bool? PasscodeBlockSimple { get; set; }
        public Int32? PasscodeExpirationDays { get; set; }
        public Int32? PasscodeMinimumLength { get; set; }
        public Int32? PasscodeMinutesOfInactivityBeforeLock { get; set; }
        public Int32? PasscodePreviousPasscodeBlockCount { get; set; }
        public Int32? PasscodeMinimumCharacterSetCount { get; set; }
        public IntuneDeviceconfigIoscompliancepolicyCreateParameterRequiredPasswordType PasscodeRequiredType { get; set; }
        public bool? PasscodeRequired { get; set; }
        public string? OsMinimumVersion { get; set; }
        public string? OsMaximumVersion { get; set; }
        public bool? SecurityBlockJailbrokenDevices { get; set; }
        public bool? DeviceThreatProtectionEnabled { get; set; }
        public IntuneDeviceconfigIoscompliancepolicyCreateParameterDeviceThreatProtectionLevel DeviceThreatProtectionRequiredSecurityLevel { get; set; }
        public bool? ManagedEmailProfileRequired { get; set; }
    }
    public partial class IntuneDeviceconfigIoscompliancepolicyCreateResponse : RestApiResponse
    {
        public enum IosCompliancePolicyRequiredPasswordType
        {
            DeviceDefault,
            Alphanumeric,
            Numeric,
        }
        public enum IosCompliancePolicyDeviceThreatProtectionLevel
        {
            Unavailable,
            Secured,
            Low,
            Medium,
            High,
            NotSet,
        }

        public string? Id { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public bool? PasscodeBlockSimple { get; set; }
        public Int32? PasscodeExpirationDays { get; set; }
        public Int32? PasscodeMinimumLength { get; set; }
        public Int32? PasscodeMinutesOfInactivityBeforeLock { get; set; }
        public Int32? PasscodePreviousPasscodeBlockCount { get; set; }
        public Int32? PasscodeMinimumCharacterSetCount { get; set; }
        public RequiredPasswordType? PasscodeRequiredType { get; set; }
        public bool? PasscodeRequired { get; set; }
        public string? OsMinimumVersion { get; set; }
        public string? OsMaximumVersion { get; set; }
        public bool? SecurityBlockJailbrokenDevices { get; set; }
        public bool? DeviceThreatProtectionEnabled { get; set; }
        public DeviceThreatProtectionLevel? DeviceThreatProtectionRequiredSecurityLevel { get; set; }
        public bool? ManagedEmailProfileRequired { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-ioscompliancepolicy-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIoscompliancepolicyCreateResponse> IntuneDeviceconfigIoscompliancepolicyCreateAsync()
        {
            var p = new IntuneDeviceconfigIoscompliancepolicyCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigIoscompliancepolicyCreateParameter, IntuneDeviceconfigIoscompliancepolicyCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-ioscompliancepolicy-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIoscompliancepolicyCreateResponse> IntuneDeviceconfigIoscompliancepolicyCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigIoscompliancepolicyCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigIoscompliancepolicyCreateParameter, IntuneDeviceconfigIoscompliancepolicyCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-ioscompliancepolicy-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIoscompliancepolicyCreateResponse> IntuneDeviceconfigIoscompliancepolicyCreateAsync(IntuneDeviceconfigIoscompliancepolicyCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigIoscompliancepolicyCreateParameter, IntuneDeviceconfigIoscompliancepolicyCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-ioscompliancepolicy-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIoscompliancepolicyCreateResponse> IntuneDeviceconfigIoscompliancepolicyCreateAsync(IntuneDeviceconfigIoscompliancepolicyCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigIoscompliancepolicyCreateParameter, IntuneDeviceconfigIoscompliancepolicyCreateResponse>(parameter, cancellationToken);
        }
    }
}
