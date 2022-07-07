using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigSharedpcconfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations_DeviceConfigurationId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations_DeviceConfigurationId: return $"/deviceManagement/deviceConfigurations/{DeviceConfigurationId}";
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
        public string DeviceConfigurationId { get; set; }
    }
    public partial class IntuneDeviceconfigSharedpcconfigurationGetResponse : RestApiResponse
    {
        public enum SharedPCConfigurationSharedPCAllowedAccountType
        {
            Guest,
            Domain,
        }

        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public SharedPCAccountManagerPolicy? AccountManagerPolicy { get; set; }
        public SharedPCAllowedAccountType? AllowedAccounts { get; set; }
        public bool? AllowLocalStorage { get; set; }
        public bool? DisableAccountManager { get; set; }
        public bool? DisableEduPolicies { get; set; }
        public bool? DisablePowerPolicies { get; set; }
        public bool? DisableSignInOnResume { get; set; }
        public bool? Enabled { get; set; }
        public Int32? IdleTimeBeforeSleepInSeconds { get; set; }
        public string? KioskAppDisplayName { get; set; }
        public string? KioskAppUserModelId { get; set; }
        public TimeOnly? MaintenanceStartTime { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-sharedpcconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSharedpcconfigurationGetResponse> IntuneDeviceconfigSharedpcconfigurationGetAsync()
        {
            var p = new IntuneDeviceconfigSharedpcconfigurationGetParameter();
            return await this.SendAsync<IntuneDeviceconfigSharedpcconfigurationGetParameter, IntuneDeviceconfigSharedpcconfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-sharedpcconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSharedpcconfigurationGetResponse> IntuneDeviceconfigSharedpcconfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigSharedpcconfigurationGetParameter();
            return await this.SendAsync<IntuneDeviceconfigSharedpcconfigurationGetParameter, IntuneDeviceconfigSharedpcconfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-sharedpcconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSharedpcconfigurationGetResponse> IntuneDeviceconfigSharedpcconfigurationGetAsync(IntuneDeviceconfigSharedpcconfigurationGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigSharedpcconfigurationGetParameter, IntuneDeviceconfigSharedpcconfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-sharedpcconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSharedpcconfigurationGetResponse> IntuneDeviceconfigSharedpcconfigurationGetAsync(IntuneDeviceconfigSharedpcconfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigSharedpcconfigurationGetParameter, IntuneDeviceconfigSharedpcconfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
