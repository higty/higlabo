using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindows10mobilecompliancepolicyListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneDeviceconfigWindows10mobilecompliancepolicyListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-windows10mobilecompliancepolicy?view=graph-rest-1.0
        /// </summary>
        public partial class Windows10MobileCompliancePolicy
        {
            public enum Windows10MobileCompliancePolicyRequiredPasswordType
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
            public Int32? PasswordMinimumLength { get; set; }
            public Int32? PasswordMinimumCharacterSetCount { get; set; }
            public RequiredPasswordType? PasswordRequiredType { get; set; }
            public Int32? PasswordPreviousPasswordBlockCount { get; set; }
            public Int32? PasswordExpirationDays { get; set; }
            public Int32? PasswordMinutesOfInactivityBeforeLock { get; set; }
            public bool? PasswordRequireToUnlockFromIdle { get; set; }
            public string? OsMinimumVersion { get; set; }
            public string? OsMaximumVersion { get; set; }
            public bool? EarlyLaunchAntiMalwareDriverEnabled { get; set; }
            public bool? BitLockerEnabled { get; set; }
            public bool? SecureBootEnabled { get; set; }
            public bool? CodeIntegrityEnabled { get; set; }
            public bool? StorageRequireEncryption { get; set; }
        }

        public Windows10MobileCompliancePolicy[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10mobilecompliancepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10mobilecompliancepolicyListResponse> IntuneDeviceconfigWindows10mobilecompliancepolicyListAsync()
        {
            var p = new IntuneDeviceconfigWindows10mobilecompliancepolicyListParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10mobilecompliancepolicyListParameter, IntuneDeviceconfigWindows10mobilecompliancepolicyListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10mobilecompliancepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10mobilecompliancepolicyListResponse> IntuneDeviceconfigWindows10mobilecompliancepolicyListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindows10mobilecompliancepolicyListParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10mobilecompliancepolicyListParameter, IntuneDeviceconfigWindows10mobilecompliancepolicyListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10mobilecompliancepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10mobilecompliancepolicyListResponse> IntuneDeviceconfigWindows10mobilecompliancepolicyListAsync(IntuneDeviceconfigWindows10mobilecompliancepolicyListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10mobilecompliancepolicyListParameter, IntuneDeviceconfigWindows10mobilecompliancepolicyListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10mobilecompliancepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10mobilecompliancepolicyListResponse> IntuneDeviceconfigWindows10mobilecompliancepolicyListAsync(IntuneDeviceconfigWindows10mobilecompliancepolicyListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10mobilecompliancepolicyListParameter, IntuneDeviceconfigWindows10mobilecompliancepolicyListResponse>(parameter, cancellationToken);
        }
    }
}
