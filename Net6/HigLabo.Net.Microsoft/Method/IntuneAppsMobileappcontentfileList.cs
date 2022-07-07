using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsMobileappcontentfileListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
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
    }
    public partial class IntuneAppsMobileappcontentfileListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-mobileappcontentfile?view=graph-rest-1.0
        /// </summary>
        public partial class MobileAppContentFile
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

        public MobileAppContentFile[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontentfile-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentfileListResponse> IntuneAppsMobileappcontentfileListAsync()
        {
            var p = new IntuneAppsMobileappcontentfileListParameter();
            return await this.SendAsync<IntuneAppsMobileappcontentfileListParameter, IntuneAppsMobileappcontentfileListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontentfile-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentfileListResponse> IntuneAppsMobileappcontentfileListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsMobileappcontentfileListParameter();
            return await this.SendAsync<IntuneAppsMobileappcontentfileListParameter, IntuneAppsMobileappcontentfileListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontentfile-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentfileListResponse> IntuneAppsMobileappcontentfileListAsync(IntuneAppsMobileappcontentfileListParameter parameter)
        {
            return await this.SendAsync<IntuneAppsMobileappcontentfileListParameter, IntuneAppsMobileappcontentfileListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcontentfile-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcontentfileListResponse> IntuneAppsMobileappcontentfileListAsync(IntuneAppsMobileappcontentfileListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsMobileappcontentfileListParameter, IntuneAppsMobileappcontentfileListResponse>(parameter, cancellationToken);
        }
    }
}
