using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsMobileappcontentfileGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string MobileAppId { get; set; }
        public string MobileAppContentId { get; set; }
        public string MobileAppContentFileId { get; set; }
    }
    public partial class IntuneAppsMobileappcontentfileGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontentfile-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentfileGetResponse> IntuneAppsMobileappcontentfileGetAsync()
        {
            var p = new IntuneAppsMobileappcontentfileGetParameter();
            return await this.SendAsync<IntuneAppsMobileappcontentfileGetParameter, IntuneAppsMobileappcontentfileGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontentfile-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentfileGetResponse> IntuneAppsMobileappcontentfileGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsMobileappcontentfileGetParameter();
            return await this.SendAsync<IntuneAppsMobileappcontentfileGetParameter, IntuneAppsMobileappcontentfileGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontentfile-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentfileGetResponse> IntuneAppsMobileappcontentfileGetAsync(IntuneAppsMobileappcontentfileGetParameter parameter)
        {
            return await this.SendAsync<IntuneAppsMobileappcontentfileGetParameter, IntuneAppsMobileappcontentfileGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontentfile-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentfileGetResponse> IntuneAppsMobileappcontentfileGetAsync(IntuneAppsMobileappcontentfileGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsMobileappcontentfileGetParameter, IntuneAppsMobileappcontentfileGetResponse>(parameter, cancellationToken);
        }
    }
}
