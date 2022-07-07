using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindowsphone81compliancepolicyCreateParameter : IRestApiParameter
    {
        public enum IntuneDeviceconfigWindowsphone81compliancepolicyCreateParameterRequiredPasswordType
        {
            DeviceDefault,
            Alphanumeric,
            Numeric,
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
        public bool? PasswordBlockSimple { get; set; }
        public Int32? PasswordExpirationDays { get; set; }
        public Int32? PasswordMinimumLength { get; set; }
        public Int32? PasswordMinutesOfInactivityBeforeLock { get; set; }
        public Int32? PasswordMinimumCharacterSetCount { get; set; }
        public IntuneDeviceconfigWindowsphone81compliancepolicyCreateParameterRequiredPasswordType PasswordRequiredType { get; set; }
        public Int32? PasswordPreviousPasswordBlockCount { get; set; }
        public bool? PasswordRequired { get; set; }
        public string? OsMinimumVersion { get; set; }
        public string? OsMaximumVersion { get; set; }
        public bool? StorageRequireEncryption { get; set; }
    }
    public partial class IntuneDeviceconfigWindowsphone81compliancepolicyCreateResponse : RestApiResponse
    {
        public enum WindowsPhone81CompliancePolicyRequiredPasswordType
        {
            DeviceDefault,
            Alphanumeric,
            Numeric,
        }

        public string? Id { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public bool? PasswordBlockSimple { get; set; }
        public Int32? PasswordExpirationDays { get; set; }
        public Int32? PasswordMinimumLength { get; set; }
        public Int32? PasswordMinutesOfInactivityBeforeLock { get; set; }
        public Int32? PasswordMinimumCharacterSetCount { get; set; }
        public RequiredPasswordType? PasswordRequiredType { get; set; }
        public Int32? PasswordPreviousPasswordBlockCount { get; set; }
        public bool? PasswordRequired { get; set; }
        public string? OsMinimumVersion { get; set; }
        public string? OsMaximumVersion { get; set; }
        public bool? StorageRequireEncryption { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81compliancepolicy-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81compliancepolicyCreateResponse> IntuneDeviceconfigWindowsphone81compliancepolicyCreateAsync()
        {
            var p = new IntuneDeviceconfigWindowsphone81compliancepolicyCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81compliancepolicyCreateParameter, IntuneDeviceconfigWindowsphone81compliancepolicyCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81compliancepolicy-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81compliancepolicyCreateResponse> IntuneDeviceconfigWindowsphone81compliancepolicyCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindowsphone81compliancepolicyCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81compliancepolicyCreateParameter, IntuneDeviceconfigWindowsphone81compliancepolicyCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81compliancepolicy-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81compliancepolicyCreateResponse> IntuneDeviceconfigWindowsphone81compliancepolicyCreateAsync(IntuneDeviceconfigWindowsphone81compliancepolicyCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81compliancepolicyCreateParameter, IntuneDeviceconfigWindowsphone81compliancepolicyCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81compliancepolicy-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81compliancepolicyCreateResponse> IntuneDeviceconfigWindowsphone81compliancepolicyCreateAsync(IntuneDeviceconfigWindowsphone81compliancepolicyCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81compliancepolicyCreateParameter, IntuneDeviceconfigWindowsphone81compliancepolicyCreateResponse>(parameter, cancellationToken);
        }
    }
}
