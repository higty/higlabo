using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDeviceappmanagementSyncmicrosoftstoreforbusinessappsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_SyncMicrosoftStoreForBusinessApps,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_SyncMicrosoftStoreForBusinessApps: return $"/deviceAppManagement/syncMicrosoftStoreForBusinessApps";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class IntuneOnboardingDeviceappmanagementSyncmicrosoftstoreforbusinessappsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceappmanagement-syncmicrosoftstoreforbusinessapps?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceappmanagementSyncmicrosoftstoreforbusinessappsResponse> IntuneOnboardingDeviceappmanagementSyncmicrosoftstoreforbusinessappsAsync()
        {
            var p = new IntuneOnboardingDeviceappmanagementSyncmicrosoftstoreforbusinessappsParameter();
            return await this.SendAsync<IntuneOnboardingDeviceappmanagementSyncmicrosoftstoreforbusinessappsParameter, IntuneOnboardingDeviceappmanagementSyncmicrosoftstoreforbusinessappsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceappmanagement-syncmicrosoftstoreforbusinessapps?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceappmanagementSyncmicrosoftstoreforbusinessappsResponse> IntuneOnboardingDeviceappmanagementSyncmicrosoftstoreforbusinessappsAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDeviceappmanagementSyncmicrosoftstoreforbusinessappsParameter();
            return await this.SendAsync<IntuneOnboardingDeviceappmanagementSyncmicrosoftstoreforbusinessappsParameter, IntuneOnboardingDeviceappmanagementSyncmicrosoftstoreforbusinessappsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceappmanagement-syncmicrosoftstoreforbusinessapps?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceappmanagementSyncmicrosoftstoreforbusinessappsResponse> IntuneOnboardingDeviceappmanagementSyncmicrosoftstoreforbusinessappsAsync(IntuneOnboardingDeviceappmanagementSyncmicrosoftstoreforbusinessappsParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDeviceappmanagementSyncmicrosoftstoreforbusinessappsParameter, IntuneOnboardingDeviceappmanagementSyncmicrosoftstoreforbusinessappsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceappmanagement-syncmicrosoftstoreforbusinessapps?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceappmanagementSyncmicrosoftstoreforbusinessappsResponse> IntuneOnboardingDeviceappmanagementSyncmicrosoftstoreforbusinessappsAsync(IntuneOnboardingDeviceappmanagementSyncmicrosoftstoreforbusinessappsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDeviceappmanagementSyncmicrosoftstoreforbusinessappsParameter, IntuneOnboardingDeviceappmanagementSyncmicrosoftstoreforbusinessappsResponse>(parameter, cancellationToken);
        }
    }
}
