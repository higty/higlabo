using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsWindowsmobilemsiCreateParameter : IRestApiParameter
    {
        public enum IntuneAppsWindowsmobilemsiCreateParameterMobileAppPublishingState
        {
            NotPublished,
            Processing,
            Published,
        }
        public enum ApiPath
        {
            DeviceAppManagement_MobileApps,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileApps: return $"/deviceAppManagement/mobileApps";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public string? Publisher { get; set; }
        public MimeContent? LargeIcon { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public bool? IsFeatured { get; set; }
        public string? PrivacyInformationUrl { get; set; }
        public string? InformationUrl { get; set; }
        public string? Owner { get; set; }
        public string? Developer { get; set; }
        public string? Notes { get; set; }
        public IntuneAppsWindowsmobilemsiCreateParameterMobileAppPublishingState PublishingState { get; set; }
        public string? CommittedContentVersion { get; set; }
        public string? FileName { get; set; }
        public Int64? Size { get; set; }
        public string? CommandLine { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductVersion { get; set; }
        public bool? IgnoreVersionDetection { get; set; }
    }
    public partial class IntuneAppsWindowsmobilemsiCreateResponse : RestApiResponse
    {
        public enum WindowsMobileMSIMobileAppPublishingState
        {
            NotPublished,
            Processing,
            Published,
        }

        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public string? Publisher { get; set; }
        public MimeContent? LargeIcon { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public bool? IsFeatured { get; set; }
        public string? PrivacyInformationUrl { get; set; }
        public string? InformationUrl { get; set; }
        public string? Owner { get; set; }
        public string? Developer { get; set; }
        public string? Notes { get; set; }
        public MobileAppPublishingState? PublishingState { get; set; }
        public string? CommittedContentVersion { get; set; }
        public string? FileName { get; set; }
        public Int64? Size { get; set; }
        public string? CommandLine { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductVersion { get; set; }
        public bool? IgnoreVersionDetection { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-windowsmobilemsi-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWindowsmobilemsiCreateResponse> IntuneAppsWindowsmobilemsiCreateAsync()
        {
            var p = new IntuneAppsWindowsmobilemsiCreateParameter();
            return await this.SendAsync<IntuneAppsWindowsmobilemsiCreateParameter, IntuneAppsWindowsmobilemsiCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-windowsmobilemsi-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWindowsmobilemsiCreateResponse> IntuneAppsWindowsmobilemsiCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsWindowsmobilemsiCreateParameter();
            return await this.SendAsync<IntuneAppsWindowsmobilemsiCreateParameter, IntuneAppsWindowsmobilemsiCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-windowsmobilemsi-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWindowsmobilemsiCreateResponse> IntuneAppsWindowsmobilemsiCreateAsync(IntuneAppsWindowsmobilemsiCreateParameter parameter)
        {
            return await this.SendAsync<IntuneAppsWindowsmobilemsiCreateParameter, IntuneAppsWindowsmobilemsiCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-windowsmobilemsi-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWindowsmobilemsiCreateResponse> IntuneAppsWindowsmobilemsiCreateAsync(IntuneAppsWindowsmobilemsiCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsWindowsmobilemsiCreateParameter, IntuneAppsWindowsmobilemsiCreateResponse>(parameter, cancellationToken);
        }
    }
}
