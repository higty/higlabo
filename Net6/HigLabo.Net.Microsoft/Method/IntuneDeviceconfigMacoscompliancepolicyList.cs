using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigMacoscompliancepolicyListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
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
    public partial class IntuneDeviceconfigMacoscompliancepolicyListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-macoscompliancepolicy?view=graph-rest-1.0
        /// </summary>
        public partial class MacOSCompliancePolicy
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

        public MacOSCompliancePolicy[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macoscompliancepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacoscompliancepolicyListResponse> IntuneDeviceconfigMacoscompliancepolicyListAsync()
        {
            var p = new IntuneDeviceconfigMacoscompliancepolicyListParameter();
            return await this.SendAsync<IntuneDeviceconfigMacoscompliancepolicyListParameter, IntuneDeviceconfigMacoscompliancepolicyListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macoscompliancepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacoscompliancepolicyListResponse> IntuneDeviceconfigMacoscompliancepolicyListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigMacoscompliancepolicyListParameter();
            return await this.SendAsync<IntuneDeviceconfigMacoscompliancepolicyListParameter, IntuneDeviceconfigMacoscompliancepolicyListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macoscompliancepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacoscompliancepolicyListResponse> IntuneDeviceconfigMacoscompliancepolicyListAsync(IntuneDeviceconfigMacoscompliancepolicyListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigMacoscompliancepolicyListParameter, IntuneDeviceconfigMacoscompliancepolicyListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macoscompliancepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacoscompliancepolicyListResponse> IntuneDeviceconfigMacoscompliancepolicyListAsync(IntuneDeviceconfigMacoscompliancepolicyListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigMacoscompliancepolicyListParameter, IntuneDeviceconfigMacoscompliancepolicyListResponse>(parameter, cancellationToken);
        }
    }
}
