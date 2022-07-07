using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsMobileappcontentfileCreateParameter : IRestApiParameter
    {
        public enum IntuneAppsMobileappcontentfileCreateParameterMobileAppContentFileUploadState
        {
            Success,
            TransientError,
            Error,
            Unknown,
            AzureStorageUriRequestSuccess,
            AzureStorageUriRequestPending,
            AzureStorageUriRequestFailed,
            AzureStorageUriRequestTimedOut,
            AzureStorageUriRenewalSuccess,
            AzureStorageUriRenewalPending,
            AzureStorageUriRenewalFailed,
            AzureStorageUriRenewalTimedOut,
            CommitFileSuccess,
            CommitFilePending,
            CommitFileFailed,
            CommitFileTimedOut,
        }
        public enum ApiPath
        {
            DeviceAppManagement_MobileApps_MobileAppId_ContentVersions_MobileAppContentId_Files,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileApps_MobileAppId_ContentVersions_MobileAppContentId_Files: return $"/deviceAppManagement/mobileApps/{MobileAppId}/contentVersions/{MobileAppContentId}/files";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? AzureStorageUri { get; set; }
        public bool? IsCommitted { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Name { get; set; }
        public Int64? Size { get; set; }
        public Int64? SizeEncrypted { get; set; }
        public DateTimeOffset? AzureStorageUriExpirationDateTime { get; set; }
        public string? Manifest { get; set; }
        public IntuneAppsMobileappcontentfileCreateParameterMobileAppContentFileUploadState UploadState { get; set; }
        public string MobileAppId { get; set; }
        public string MobileAppContentId { get; set; }
    }
    public partial class IntuneAppsMobileappcontentfileCreateResponse : RestApiResponse
    {
        public enum MobileAppContentFileMobileAppContentFileUploadState
        {
            Success,
            TransientError,
            Error,
            Unknown,
            AzureStorageUriRequestSuccess,
            AzureStorageUriRequestPending,
            AzureStorageUriRequestFailed,
            AzureStorageUriRequestTimedOut,
            AzureStorageUriRenewalSuccess,
            AzureStorageUriRenewalPending,
            AzureStorageUriRenewalFailed,
            AzureStorageUriRenewalTimedOut,
            CommitFileSuccess,
            CommitFilePending,
            CommitFileFailed,
            CommitFileTimedOut,
        }

        public string? AzureStorageUri { get; set; }
        public bool? IsCommitted { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Name { get; set; }
        public Int64? Size { get; set; }
        public Int64? SizeEncrypted { get; set; }
        public DateTimeOffset? AzureStorageUriExpirationDateTime { get; set; }
        public string? Manifest { get; set; }
        public MobileAppContentFileUploadState? UploadState { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontentfile-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentfileCreateResponse> IntuneAppsMobileappcontentfileCreateAsync()
        {
            var p = new IntuneAppsMobileappcontentfileCreateParameter();
            return await this.SendAsync<IntuneAppsMobileappcontentfileCreateParameter, IntuneAppsMobileappcontentfileCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontentfile-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentfileCreateResponse> IntuneAppsMobileappcontentfileCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsMobileappcontentfileCreateParameter();
            return await this.SendAsync<IntuneAppsMobileappcontentfileCreateParameter, IntuneAppsMobileappcontentfileCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontentfile-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentfileCreateResponse> IntuneAppsMobileappcontentfileCreateAsync(IntuneAppsMobileappcontentfileCreateParameter parameter)
        {
            return await this.SendAsync<IntuneAppsMobileappcontentfileCreateParameter, IntuneAppsMobileappcontentfileCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontentfile-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentfileCreateResponse> IntuneAppsMobileappcontentfileCreateAsync(IntuneAppsMobileappcontentfileCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsMobileappcontentfileCreateParameter, IntuneAppsMobileappcontentfileCreateResponse>(parameter, cancellationToken);
        }
    }
}
