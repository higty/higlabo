using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsMobileappcontentfileDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_MobileApps_MobileAppId_ContentVersions_MobileAppContentId_Files_MobileAppContentFileId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileApps_MobileAppId_ContentVersions_MobileAppContentId_Files_MobileAppContentFileId: return $"/deviceAppManagement/mobileApps/{MobileAppId}/contentVersions/{MobileAppContentId}/files/{MobileAppContentFileId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string MobileAppId { get; set; }
        public string MobileAppContentId { get; set; }
        public string MobileAppContentFileId { get; set; }
    }
    public partial class IntuneAppsMobileappcontentfileDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontentfile-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentfileDeleteResponse> IntuneAppsMobileappcontentfileDeleteAsync()
        {
            var p = new IntuneAppsMobileappcontentfileDeleteParameter();
            return await this.SendAsync<IntuneAppsMobileappcontentfileDeleteParameter, IntuneAppsMobileappcontentfileDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontentfile-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentfileDeleteResponse> IntuneAppsMobileappcontentfileDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsMobileappcontentfileDeleteParameter();
            return await this.SendAsync<IntuneAppsMobileappcontentfileDeleteParameter, IntuneAppsMobileappcontentfileDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontentfile-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentfileDeleteResponse> IntuneAppsMobileappcontentfileDeleteAsync(IntuneAppsMobileappcontentfileDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneAppsMobileappcontentfileDeleteParameter, IntuneAppsMobileappcontentfileDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontentfile-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentfileDeleteResponse> IntuneAppsMobileappcontentfileDeleteAsync(IntuneAppsMobileappcontentfileDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsMobileappcontentfileDeleteParameter, IntuneAppsMobileappcontentfileDeleteResponse>(parameter, cancellationToken);
        }
    }
}
