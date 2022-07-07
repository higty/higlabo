using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigIoscompliancepolicyListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneDeviceconfigIoscompliancepolicyListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-ioscompliancepolicy?view=graph-rest-1.0
        /// </summary>
        public partial class IosCompliancePolicy
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

        public IosCompliancePolicy[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-ioscompliancepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIoscompliancepolicyListResponse> IntuneDeviceconfigIoscompliancepolicyListAsync()
        {
            var p = new IntuneDeviceconfigIoscompliancepolicyListParameter();
            return await this.SendAsync<IntuneDeviceconfigIoscompliancepolicyListParameter, IntuneDeviceconfigIoscompliancepolicyListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-ioscompliancepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIoscompliancepolicyListResponse> IntuneDeviceconfigIoscompliancepolicyListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigIoscompliancepolicyListParameter();
            return await this.SendAsync<IntuneDeviceconfigIoscompliancepolicyListParameter, IntuneDeviceconfigIoscompliancepolicyListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-ioscompliancepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIoscompliancepolicyListResponse> IntuneDeviceconfigIoscompliancepolicyListAsync(IntuneDeviceconfigIoscompliancepolicyListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigIoscompliancepolicyListParameter, IntuneDeviceconfigIoscompliancepolicyListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-ioscompliancepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIoscompliancepolicyListResponse> IntuneDeviceconfigIoscompliancepolicyListAsync(IntuneDeviceconfigIoscompliancepolicyListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigIoscompliancepolicyListParameter, IntuneDeviceconfigIoscompliancepolicyListResponse>(parameter, cancellationToken);
        }
    }
}
