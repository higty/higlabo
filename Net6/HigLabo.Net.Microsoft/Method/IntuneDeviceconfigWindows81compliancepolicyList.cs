using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindows81compliancepolicyListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneDeviceconfigWindows81compliancepolicyListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-windows81compliancepolicy?view=graph-rest-1.0
        /// </summary>
        public partial class Windows81CompliancePolicy
        {
            public enum Windows81CompliancePolicyRequiredPasswordType
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
            public Int32? PasswordExpirationDays { get; set; }
            public Int32? PasswordMinimumLength { get; set; }
            public Int32? PasswordMinutesOfInactivityBeforeLock { get; set; }
            public Int32? PasswordMinimumCharacterSetCount { get; set; }
            public RequiredPasswordType? PasswordRequiredType { get; set; }
            public Int32? PasswordPreviousPasswordBlockCount { get; set; }
            public string? OsMinimumVersion { get; set; }
            public string? OsMaximumVersion { get; set; }
            public bool? StorageRequireEncryption { get; set; }
        }

        public Windows81CompliancePolicy[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows81compliancepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows81compliancepolicyListResponse> IntuneDeviceconfigWindows81compliancepolicyListAsync()
        {
            var p = new IntuneDeviceconfigWindows81compliancepolicyListParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows81compliancepolicyListParameter, IntuneDeviceconfigWindows81compliancepolicyListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows81compliancepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows81compliancepolicyListResponse> IntuneDeviceconfigWindows81compliancepolicyListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindows81compliancepolicyListParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows81compliancepolicyListParameter, IntuneDeviceconfigWindows81compliancepolicyListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows81compliancepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows81compliancepolicyListResponse> IntuneDeviceconfigWindows81compliancepolicyListAsync(IntuneDeviceconfigWindows81compliancepolicyListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows81compliancepolicyListParameter, IntuneDeviceconfigWindows81compliancepolicyListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows81compliancepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows81compliancepolicyListResponse> IntuneDeviceconfigWindows81compliancepolicyListAsync(IntuneDeviceconfigWindows81compliancepolicyListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows81compliancepolicyListParameter, IntuneDeviceconfigWindows81compliancepolicyListResponse>(parameter, cancellationToken);
        }
    }
}
