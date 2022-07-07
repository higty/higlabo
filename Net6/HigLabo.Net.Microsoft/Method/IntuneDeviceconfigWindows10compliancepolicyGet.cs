using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindows10compliancepolicyGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneDeviceconfigWindows10compliancepolicyGetResponse : RestApiResponse
    {
        public enum Windows10CompliancePolicyRequiredPasswordType
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
        public bool? PasswordRequired { get; set; }
        public bool? PasswordBlockSimple { get; set; }
        public bool? PasswordRequiredToUnlockFromIdle { get; set; }
        public Int32? PasswordMinutesOfInactivityBeforeLock { get; set; }
        public Int32? PasswordExpirationDays { get; set; }
        public Int32? PasswordMinimumLength { get; set; }
        public Int32? PasswordMinimumCharacterSetCount { get; set; }
        public RequiredPasswordType? PasswordRequiredType { get; set; }
        public Int32? PasswordPreviousPasswordBlockCount { get; set; }
        public bool? RequireHealthyDeviceReport { get; set; }
        public string? OsMinimumVersion { get; set; }
        public string? OsMaximumVersion { get; set; }
        public string? MobileOsMinimumVersion { get; set; }
        public string? MobileOsMaximumVersion { get; set; }
        public bool? EarlyLaunchAntiMalwareDriverEnabled { get; set; }
        public bool? BitLockerEnabled { get; set; }
        public bool? SecureBootEnabled { get; set; }
        public bool? CodeIntegrityEnabled { get; set; }
        public bool? StorageRequireEncryption { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10compliancepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10compliancepolicyGetResponse> IntuneDeviceconfigWindows10compliancepolicyGetAsync()
        {
            var p = new IntuneDeviceconfigWindows10compliancepolicyGetParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10compliancepolicyGetParameter, IntuneDeviceconfigWindows10compliancepolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10compliancepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10compliancepolicyGetResponse> IntuneDeviceconfigWindows10compliancepolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindows10compliancepolicyGetParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10compliancepolicyGetParameter, IntuneDeviceconfigWindows10compliancepolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10compliancepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10compliancepolicyGetResponse> IntuneDeviceconfigWindows10compliancepolicyGetAsync(IntuneDeviceconfigWindows10compliancepolicyGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10compliancepolicyGetParameter, IntuneDeviceconfigWindows10compliancepolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10compliancepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10compliancepolicyGetResponse> IntuneDeviceconfigWindows10compliancepolicyGetAsync(IntuneDeviceconfigWindows10compliancepolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10compliancepolicyGetParameter, IntuneDeviceconfigWindows10compliancepolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
