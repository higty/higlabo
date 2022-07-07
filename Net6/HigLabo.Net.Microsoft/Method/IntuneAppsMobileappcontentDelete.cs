using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsMobileappcontentDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_MobileApps_MobileAppId_ContentVersions_MobileAppContentId,
            DeviceAppManagement_MobileApps_MobileAppId_MicrosoftgraphmobileLobApp_ContentVersions_MobileAppContentId,
            DeviceAppManagement_MobileApps_MobileAppId_MicrosoftgraphmanagedMobileLobApp_ContentVersions_MobileAppContentId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileApps_MobileAppId_ContentVersions_MobileAppContentId: return $"/deviceAppManagement/mobileApps/{MobileAppId}/contentVersions/{MobileAppContentId}";
                    case ApiPath.DeviceAppManagement_MobileApps_MobileAppId_MicrosoftgraphmobileLobApp_ContentVersions_MobileAppContentId: return $"/deviceAppManagement/mobileApps/{MobileAppId}/microsoft.graph.mobileLobApp/contentVersions/{MobileAppContentId}";
                    case ApiPath.DeviceAppManagement_MobileApps_MobileAppId_MicrosoftgraphmanagedMobileLobApp_ContentVersions_MobileAppContentId: return $"/deviceAppManagement/mobileApps/{MobileAppId}/microsoft.graph.managedMobileLobApp/contentVersions/{MobileAppContentId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string MobileAppId { get; set; }
        public string MobileAppContentId { get; set; }
    }
    public partial class IntuneAppsMobileappcontentDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontent-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentDeleteResponse> IntuneAppsMobileappcontentDeleteAsync()
        {
            var p = new IntuneAppsMobileappcontentDeleteParameter();
            return await this.SendAsync<IntuneAppsMobileappcontentDeleteParameter, IntuneAppsMobileappcontentDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontent-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentDeleteResponse> IntuneAppsMobileappcontentDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsMobileappcontentDeleteParameter();
            return await this.SendAsync<IntuneAppsMobileappcontentDeleteParameter, IntuneAppsMobileappcontentDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontent-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentDeleteResponse> IntuneAppsMobileappcontentDeleteAsync(IntuneAppsMobileappcontentDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneAppsMobileappcontentDeleteParameter, IntuneAppsMobileappcontentDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontent-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentDeleteResponse> IntuneAppsMobileappcontentDeleteAsync(IntuneAppsMobileappcontentDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsMobileappcontentDeleteParameter, IntuneAppsMobileappcontentDeleteResponse>(parameter, cancellationToken);
        }
    }
}
