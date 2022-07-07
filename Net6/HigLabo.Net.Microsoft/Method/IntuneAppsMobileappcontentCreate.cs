using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsMobileappcontentCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_MobileApps_MobileAppId_ContentVersions,
            DeviceAppManagement_MobileApps_MobileAppId_MicrosoftgraphmobileLobApp_ContentVersions,
            DeviceAppManagement_MobileApps_MobileAppId_MicrosoftgraphmanagedMobileLobApp_ContentVersions,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileApps_MobileAppId_ContentVersions: return $"/deviceAppManagement/mobileApps/{MobileAppId}/contentVersions";
                    case ApiPath.DeviceAppManagement_MobileApps_MobileAppId_MicrosoftgraphmobileLobApp_ContentVersions: return $"/deviceAppManagement/mobileApps/{MobileAppId}/microsoft.graph.mobileLobApp/contentVersions";
                    case ApiPath.DeviceAppManagement_MobileApps_MobileAppId_MicrosoftgraphmanagedMobileLobApp_ContentVersions: return $"/deviceAppManagement/mobileApps/{MobileAppId}/microsoft.graph.managedMobileLobApp/contentVersions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string MobileAppId { get; set; }
    }
    public partial class IntuneAppsMobileappcontentCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontent-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentCreateResponse> IntuneAppsMobileappcontentCreateAsync()
        {
            var p = new IntuneAppsMobileappcontentCreateParameter();
            return await this.SendAsync<IntuneAppsMobileappcontentCreateParameter, IntuneAppsMobileappcontentCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontent-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentCreateResponse> IntuneAppsMobileappcontentCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsMobileappcontentCreateParameter();
            return await this.SendAsync<IntuneAppsMobileappcontentCreateParameter, IntuneAppsMobileappcontentCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontent-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentCreateResponse> IntuneAppsMobileappcontentCreateAsync(IntuneAppsMobileappcontentCreateParameter parameter)
        {
            return await this.SendAsync<IntuneAppsMobileappcontentCreateParameter, IntuneAppsMobileappcontentCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontent-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentCreateResponse> IntuneAppsMobileappcontentCreateAsync(IntuneAppsMobileappcontentCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsMobileappcontentCreateParameter, IntuneAppsMobileappcontentCreateResponse>(parameter, cancellationToken);
        }
    }
}
