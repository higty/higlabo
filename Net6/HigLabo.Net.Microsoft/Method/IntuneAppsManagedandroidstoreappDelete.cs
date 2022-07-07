using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManagedandroidstoreappDeleteParameter : IRestApiParameter
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
    public partial class IntuneAppsManagedandroidstoreappDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedandroidstoreapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedandroidstoreappDeleteResponse> IntuneAppsManagedandroidstoreappDeleteAsync()
        {
            var p = new IntuneAppsManagedandroidstoreappDeleteParameter();
            return await this.SendAsync<IntuneAppsManagedandroidstoreappDeleteParameter, IntuneAppsManagedandroidstoreappDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedandroidstoreapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedandroidstoreappDeleteResponse> IntuneAppsManagedandroidstoreappDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManagedandroidstoreappDeleteParameter();
            return await this.SendAsync<IntuneAppsManagedandroidstoreappDeleteParameter, IntuneAppsManagedandroidstoreappDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedandroidstoreapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedandroidstoreappDeleteResponse> IntuneAppsManagedandroidstoreappDeleteAsync(IntuneAppsManagedandroidstoreappDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManagedandroidstoreappDeleteParameter, IntuneAppsManagedandroidstoreappDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedandroidstoreapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedandroidstoreappDeleteResponse> IntuneAppsManagedandroidstoreappDeleteAsync(IntuneAppsManagedandroidstoreappDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManagedandroidstoreappDeleteParameter, IntuneAppsManagedandroidstoreappDeleteResponse>(parameter, cancellationToken);
        }
    }
}
