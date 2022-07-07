using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsMobileappcontentfileCommitParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_MobileApps_MobileAppId_ContentVersions_MobileAppContentId_Files_MobileAppContentFileId_Commit,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileApps_MobileAppId_ContentVersions_MobileAppContentId_Files_MobileAppContentFileId_Commit: return $"/deviceAppManagement/mobileApps/{MobileAppId}/contentVersions/{MobileAppContentId}/files/{MobileAppContentFileId}/commit";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public FileEncryptionInfo? FileEncryptionInfo { get; set; }
        public string MobileAppId { get; set; }
        public string MobileAppContentId { get; set; }
        public string MobileAppContentFileId { get; set; }
    }
    public partial class IntuneAppsMobileappcontentfileCommitResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontentfile-commit?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentfileCommitResponse> IntuneAppsMobileappcontentfileCommitAsync()
        {
            var p = new IntuneAppsMobileappcontentfileCommitParameter();
            return await this.SendAsync<IntuneAppsMobileappcontentfileCommitParameter, IntuneAppsMobileappcontentfileCommitResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontentfile-commit?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentfileCommitResponse> IntuneAppsMobileappcontentfileCommitAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsMobileappcontentfileCommitParameter();
            return await this.SendAsync<IntuneAppsMobileappcontentfileCommitParameter, IntuneAppsMobileappcontentfileCommitResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontentfile-commit?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentfileCommitResponse> IntuneAppsMobileappcontentfileCommitAsync(IntuneAppsMobileappcontentfileCommitParameter parameter)
        {
            return await this.SendAsync<IntuneAppsMobileappcontentfileCommitParameter, IntuneAppsMobileappcontentfileCommitResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontentfile-commit?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentfileCommitResponse> IntuneAppsMobileappcontentfileCommitAsync(IntuneAppsMobileappcontentfileCommitParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsMobileappcontentfileCommitParameter, IntuneAppsMobileappcontentfileCommitResponse>(parameter, cancellationToken);
        }
    }
}
