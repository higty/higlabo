using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsMobileappcontentfileRenewuploadParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_MobileApps_MobileAppId_ContentVersions_MobileAppContentId_Files_MobileAppContentFileId_RenewUpload,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileApps_MobileAppId_ContentVersions_MobileAppContentId_Files_MobileAppContentFileId_RenewUpload: return $"/deviceAppManagement/mobileApps/{MobileAppId}/contentVersions/{MobileAppContentId}/files/{MobileAppContentFileId}/renewUpload";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string MobileAppId { get; set; }
        public string MobileAppContentId { get; set; }
        public string MobileAppContentFileId { get; set; }
    }
    public partial class IntuneAppsMobileappcontentfileRenewuploadResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontentfile-renewupload?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentfileRenewuploadResponse> IntuneAppsMobileappcontentfileRenewuploadAsync()
        {
            var p = new IntuneAppsMobileappcontentfileRenewuploadParameter();
            return await this.SendAsync<IntuneAppsMobileappcontentfileRenewuploadParameter, IntuneAppsMobileappcontentfileRenewuploadResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontentfile-renewupload?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentfileRenewuploadResponse> IntuneAppsMobileappcontentfileRenewuploadAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsMobileappcontentfileRenewuploadParameter();
            return await this.SendAsync<IntuneAppsMobileappcontentfileRenewuploadParameter, IntuneAppsMobileappcontentfileRenewuploadResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontentfile-renewupload?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentfileRenewuploadResponse> IntuneAppsMobileappcontentfileRenewuploadAsync(IntuneAppsMobileappcontentfileRenewuploadParameter parameter)
        {
            return await this.SendAsync<IntuneAppsMobileappcontentfileRenewuploadParameter, IntuneAppsMobileappcontentfileRenewuploadResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontentfile-renewupload?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentfileRenewuploadResponse> IntuneAppsMobileappcontentfileRenewuploadAsync(IntuneAppsMobileappcontentfileRenewuploadParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsMobileappcontentfileRenewuploadParameter, IntuneAppsMobileappcontentfileRenewuploadResponse>(parameter, cancellationToken);
        }
    }
}
