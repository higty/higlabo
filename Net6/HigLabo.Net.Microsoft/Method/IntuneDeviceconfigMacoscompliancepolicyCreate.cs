using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigMacoscompliancepolicyCreateParameter : IRestApiParameter
    {
        public enum IntuneDeviceconfigMacoscompliancepolicyCreateParameterRequiredPasswordType
        {
            DeviceDefault,
            Alphanumeric,
            Numeric,
        }
        public enum IntuneDeviceconfigMacoscompliancepolicyCreateParameterDeviceThreatProtectionLevel
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
        public bool? PasswordRequired { get; set; }
        public bool? PasswordBlockSimple { get; set; }
        public Int32? PasswordExpirationDays { get; set; }
        public Int32? PasswordMinimumLength { get; set; }
        public Int32? PasswordMinutesOfInactivityBeforeLock { get; set; }
        public Int32? PasswordPreviousPasswordBlockCount { get; set; }
        public Int32? PasswordMinimumCharacterSetCount { get; set; }
        public IntuneDeviceconfigMacoscompliancepolicyCreateParameterRequiredPasswordType PasswordRequiredType { get; set; }
        public string? OsMinimumVersion { get; set; }
        public string? OsMaximumVersion { get; set; }
        public bool? SystemIntegrityProtectionEnabled { get; set; }
        public bool? DeviceThreatProtectionEnabled { get; set; }
        public IntuneDeviceconfigMacoscompliancepolicyCreateParameterDeviceThreatProtectionLevel DeviceThreatProtectionRequiredSecurityLevel { get; set; }
        public bool? StorageRequireEncryption { get; set; }
        public bool? FirewallEnabled { get; set; }
        public bool? FirewallBlockAllIncoming { get; set; }
        public bool? FirewallEnableStealthMode { get; set; }
    }
    public partial class IntuneDeviceconfigMacoscompliancepolicyCreateResponse : RestApiResponse
    {
        public enum MacOSCompliancePolicyRequiredPasswordType
        {
            DeviceDefault,
            Alphanumeric,
            Numeric,
        }
        public enum MacOSCompliancePolicyDeviceThreatProtectionLevel
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
        public bool? PasswordRequired { get; set; }
        public bool? PasswordBlockSimple { get; set; }
        public Int32? PasswordExpirationDays { get; set; }
        public Int32? PasswordMinimumLength { get; set; }
        public Int32? PasswordMinutesOfInactivityBeforeLock { get; set; }
        public Int32? PasswordPreviousPasswordBlockCount { get; set; }
        public Int32? PasswordMinimumCharacterSetCount { get; set; }
        public RequiredPasswordType? PasswordRequiredType { get; set; }
        public string? OsMinimumVersion { get; set; }
        public string? OsMaximumVersion { get; set; }
        public bool? SystemIntegrityProtectionEnabled { get; set; }
        public bool? DeviceThreatProtectionEnabled { get; set; }
        public DeviceThreatProtectionLevel? DeviceThreatProtectionRequiredSecurityLevel { get; set; }
        public bool? StorageRequireEncryption { get; set; }
        public bool? FirewallEnabled { get; set; }
        public bool? FirewallBlockAllIncoming { get; set; }
        public bool? FirewallEnableStealthMode { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macoscompliancepolicy-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacoscompliancepolicyCreateResponse> IntuneDeviceconfigMacoscompliancepolicyCreateAsync()
        {
            var p = new IntuneDeviceconfigMacoscompliancepolicyCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigMacoscompliancepolicyCreateParameter, IntuneDeviceconfigMacoscompliancepolicyCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macoscompliancepolicy-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacoscompliancepolicyCreateResponse> IntuneDeviceconfigMacoscompliancepolicyCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigMacoscompliancepolicyCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigMacoscompliancepolicyCreateParameter, IntuneDeviceconfigMacoscompliancepolicyCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macoscompliancepolicy-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacoscompliancepolicyCreateResponse> IntuneDeviceconfigMacoscompliancepolicyCreateAsync(IntuneDeviceconfigMacoscompliancepolicyCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigMacoscompliancepolicyCreateParameter, IntuneDeviceconfigMacoscompliancepolicyCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macoscompliancepolicy-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacoscompliancepolicyCreateResponse> IntuneDeviceconfigMacoscompliancepolicyCreateAsync(IntuneDeviceconfigMacoscompliancepolicyCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigMacoscompliancepolicyCreateParameter, IntuneDeviceconfigMacoscompliancepolicyCreateResponse>(parameter, cancellationToken);
        }
    }
}
