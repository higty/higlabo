using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManagedandroidlobappDeleteParameter : IRestApiParameter
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
    public partial class IntuneAppsManagedandroidlobappDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedandroidlobapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedandroidlobappDeleteResponse> IntuneAppsManagedandroidlobappDeleteAsync()
        {
            var p = new IntuneAppsManagedandroidlobappDeleteParameter();
            return await this.SendAsync<IntuneAppsManagedandroidlobappDeleteParameter, IntuneAppsManagedandroidlobappDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedandroidlobapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedandroidlobappDeleteResponse> IntuneAppsManagedandroidlobappDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManagedandroidlobappDeleteParameter();
            return await this.SendAsync<IntuneAppsManagedandroidlobappDeleteParameter, IntuneAppsManagedandroidlobappDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedandroidlobapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedandroidlobappDeleteResponse> IntuneAppsManagedandroidlobappDeleteAsync(IntuneAppsManagedandroidlobappDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManagedandroidlobappDeleteParameter, IntuneAppsManagedandroidlobappDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedandroidlobapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedandroidlobappDeleteResponse> IntuneAppsManagedandroidlobappDeleteAsync(IntuneAppsManagedandroidlobappDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManagedandroidlobappDeleteParameter, IntuneAppsManagedandroidlobappDeleteResponse>(parameter, cancellationToken);
        }
    }
}
