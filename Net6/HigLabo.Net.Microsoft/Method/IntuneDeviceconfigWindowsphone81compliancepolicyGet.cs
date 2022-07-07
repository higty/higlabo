using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindowsphone81compliancepolicyGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneDeviceconfigWindowsphone81compliancepolicyGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81compliancepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81compliancepolicyGetResponse> IntuneDeviceconfigWindowsphone81compliancepolicyGetAsync()
        {
            var p = new IntuneDeviceconfigWindowsphone81compliancepolicyGetParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81compliancepolicyGetParameter, IntuneDeviceconfigWindowsphone81compliancepolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81compliancepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81compliancepolicyGetResponse> IntuneDeviceconfigWindowsphone81compliancepolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindowsphone81compliancepolicyGetParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81compliancepolicyGetParameter, IntuneDeviceconfigWindowsphone81compliancepolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81compliancepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81compliancepolicyGetResponse> IntuneDeviceconfigWindowsphone81compliancepolicyGetAsync(IntuneDeviceconfigWindowsphone81compliancepolicyGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81compliancepolicyGetParameter, IntuneDeviceconfigWindowsphone81compliancepolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81compliancepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81compliancepolicyGetResponse> IntuneDeviceconfigWindowsphone81compliancepolicyGetAsync(IntuneDeviceconfigWindowsphone81compliancepolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81compliancepolicyGetParameter, IntuneDeviceconfigWindowsphone81compliancepolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
