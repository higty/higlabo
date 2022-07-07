using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigSharedpcconfigurationCreateParameter : IRestApiParameter
    {
        public enum IntuneDeviceconfigSharedpcconfigurationCreateParameterSharedPCAllowedAccountType
        {
            Guest,
            Domain,
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public SharedPCAccountManagerPolicy? AccountManagerPolicy { get; set; }
        public IntuneDeviceconfigSharedpcconfigurationCreateParameterSharedPCAllowedAccountType AllowedAccounts { get; set; }
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
    public partial class IntuneDeviceconfigSharedpcconfigurationCreateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-sharedpcconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSharedpcconfigurationCreateResponse> IntuneDeviceconfigSharedpcconfigurationCreateAsync()
        {
            var p = new IntuneDeviceconfigSharedpcconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigSharedpcconfigurationCreateParameter, IntuneDeviceconfigSharedpcconfigurationCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-sharedpcconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSharedpcconfigurationCreateResponse> IntuneDeviceconfigSharedpcconfigurationCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigSharedpcconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigSharedpcconfigurationCreateParameter, IntuneDeviceconfigSharedpcconfigurationCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-sharedpcconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSharedpcconfigurationCreateResponse> IntuneDeviceconfigSharedpcconfigurationCreateAsync(IntuneDeviceconfigSharedpcconfigurationCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigSharedpcconfigurationCreateParameter, IntuneDeviceconfigSharedpcconfigurationCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-sharedpcconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSharedpcconfigurationCreateResponse> IntuneDeviceconfigSharedpcconfigurationCreateAsync(IntuneDeviceconfigSharedpcconfigurationCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigSharedpcconfigurationCreateParameter, IntuneDeviceconfigSharedpcconfigurationCreateResponse>(parameter, cancellationToken);
        }
    }
}
