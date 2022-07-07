using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigSharedpcconfigurationListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations: return $"/deviceManagement/deviceConfigurations";
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
    public partial class IntuneDeviceconfigSharedpcconfigurationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-sharedpcconfiguration?view=graph-rest-1.0
        /// </summary>
        public partial class SharedPCConfiguration
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

        public SharedPCConfiguration[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-sharedpcconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSharedpcconfigurationListResponse> IntuneDeviceconfigSharedpcconfigurationListAsync()
        {
            var p = new IntuneDeviceconfigSharedpcconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigSharedpcconfigurationListParameter, IntuneDeviceconfigSharedpcconfigurationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-sharedpcconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSharedpcconfigurationListResponse> IntuneDeviceconfigSharedpcconfigurationListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigSharedpcconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigSharedpcconfigurationListParameter, IntuneDeviceconfigSharedpcconfigurationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-sharedpcconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSharedpcconfigurationListResponse> IntuneDeviceconfigSharedpcconfigurationListAsync(IntuneDeviceconfigSharedpcconfigurationListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigSharedpcconfigurationListParameter, IntuneDeviceconfigSharedpcconfigurationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-sharedpcconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSharedpcconfigurationListResponse> IntuneDeviceconfigSharedpcconfigurationListAsync(IntuneDeviceconfigSharedpcconfigurationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigSharedpcconfigurationListParameter, IntuneDeviceconfigSharedpcconfigurationListResponse>(parameter, cancellationToken);
        }
    }
}
