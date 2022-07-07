using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManagediosstoreappDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_MobileApps_MobileAppId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileApps_MobileAppId: return $"/deviceAppManagement/mobileApps/{MobileAppId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string MobileAppId { get; set; }
    }
    public partial class IntuneAppsManagediosstoreappDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managediosstoreapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagediosstoreappDeleteResponse> IntuneAppsManagediosstoreappDeleteAsync()
        {
            var p = new IntuneAppsManagediosstoreappDeleteParameter();
            return await this.SendAsync<IntuneAppsManagediosstoreappDeleteParameter, IntuneAppsManagediosstoreappDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managediosstoreapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagediosstoreappDeleteResponse> IntuneAppsManagediosstoreappDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManagediosstoreappDeleteParameter();
            return await this.SendAsync<IntuneAppsManagediosstoreappDeleteParameter, IntuneAppsManagediosstoreappDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managediosstoreapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagediosstoreappDeleteResponse> IntuneAppsManagediosstoreappDeleteAsync(IntuneAppsManagediosstoreappDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManagediosstoreappDeleteParameter, IntuneAppsManagediosstoreappDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managediosstoreapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagediosstoreappDeleteResponse> IntuneAppsManagediosstoreappDeleteAsync(IntuneAppsManagediosstoreappDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManagediosstoreappDeleteParameter, IntuneAppsManagediosstoreappDeleteResponse>(parameter, cancellationToken);
        }
    }
}
