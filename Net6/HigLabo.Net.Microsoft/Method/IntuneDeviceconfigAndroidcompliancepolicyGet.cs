using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigAndroidcompliancepolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId: return $"/deviceManagement/deviceCompliancePolicies/{DeviceCompliancePolicyId}";
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
        public string DeviceCompliancePolicyId { get; set; }
    }
    public partial class IntuneDeviceconfigAndroidcompliancepolicyGetResponse : RestApiResponse
    {
        public enum AndroidCompliancePolicyAndroidRequiredPasswordType
        {
            DeviceDefault,
            Alphabetic,
            Alphanumeric,
            AlphanumericWithSymbols,
            LowSecurityBiometric,
            Numeric,
            NumericComplex,
            Any,
        }
        public enum AndroidCompliancePolicyDeviceThreatProtectionLevel
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
        public Int32? PasswordMinimumLength { get; set; }
        public AndroidRequiredPasswordType? PasswordRequiredType { get; set; }
        public Int32? PasswordMinutesOfInactivityBeforeLock { get; set; }
        public Int32? PasswordExpirationDays { get; set; }
        public Int32? PasswordPreviousPasswordBlockCount { get; set; }
        public bool? SecurityPreventInstallAppsFromUnknownSources { get; set; }
        public bool? SecurityDisableUsbDebugging { get; set; }
        public bool? SecurityRequireVerifyApps { get; set; }
        public bool? DeviceThreatProtectionEnabled { get; set; }
        public DeviceThreatProtectionLevel? DeviceThreatProtectionRequiredSecurityLevel { get; set; }
        public bool? SecurityBlockJailbrokenDevices { get; set; }
        public string? OsMinimumVersion { get; set; }
        public string? OsMaximumVersion { get; set; }
        public string? MinAndroidSecurityPatchLevel { get; set; }
        public bool? StorageRequireEncryption { get; set; }
        public bool? SecurityRequireSafetyNetAttestationBasicIntegrity { get; set; }
        public bool? SecurityRequireSafetyNetAttestationCertifiedDevice { get; set; }
        public bool? SecurityRequireGooglePlayServices { get; set; }
        public bool? SecurityRequireUpToDateSecurityProviders { get; set; }
        public bool? SecurityRequireCompanyPortalAppIntegrity { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidcompliancepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidcompliancepolicyGetResponse> IntuneDeviceconfigAndroidcompliancepolicyGetAsync()
        {
            var p = new IntuneDeviceconfigAndroidcompliancepolicyGetParameter();
            return await this.SendAsync<IntuneDeviceconfigAndroidcompliancepolicyGetParameter, IntuneDeviceconfigAndroidcompliancepolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidcompliancepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidcompliancepolicyGetResponse> IntuneDeviceconfigAndroidcompliancepolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigAndroidcompliancepolicyGetParameter();
            return await this.SendAsync<IntuneDeviceconfigAndroidcompliancepolicyGetParameter, IntuneDeviceconfigAndroidcompliancepolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidcompliancepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidcompliancepolicyGetResponse> IntuneDeviceconfigAndroidcompliancepolicyGetAsync(IntuneDeviceconfigAndroidcompliancepolicyGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigAndroidcompliancepolicyGetParameter, IntuneDeviceconfigAndroidcompliancepolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidcompliancepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidcompliancepolicyGetResponse> IntuneDeviceconfigAndroidcompliancepolicyGetAsync(IntuneDeviceconfigAndroidcompliancepolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigAndroidcompliancepolicyGetParameter, IntuneDeviceconfigAndroidcompliancepolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
