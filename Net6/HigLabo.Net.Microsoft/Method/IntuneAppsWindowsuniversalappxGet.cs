using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsWindowsuniversalappxGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
    }
    public partial class IntuneAppsWindowsuniversalappxGetResponse : RestApiResponse
    {
        public enum WindowsUniversalAppXMobileAppPublishingState
        {
            NotPublished,
            Processing,
            Published,
        }
        public enum WindowsUniversalAppXWindowsArchitecture
        {
            None,
            X86,
            X64,
            Arm,
            Neutral,
        }
        public enum WindowsUniversalAppXWindowsDeviceType
        {
            None,
            Desktop,
            Mobile,
            Holographic,
            Team,
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
        public WindowsArchitecture? ApplicableArchitectures { get; set; }
        public WindowsDeviceType? ApplicableDeviceTypes { get; set; }
        public string? IdentityName { get; set; }
        public string? IdentityPublisherHash { get; set; }
        public string? IdentityResourceIdentifier { get; set; }
        public bool? IsBundle { get; set; }
        public WindowsMinimumOperatingSystem? MinimumSupportedOperatingSystem { get; set; }
        public string? IdentityVersion { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-windowsuniversalappx-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWindowsuniversalappxGetResponse> IntuneAppsWindowsuniversalappxGetAsync()
        {
            var p = new IntuneAppsWindowsuniversalappxGetParameter();
            return await this.SendAsync<IntuneAppsWindowsuniversalappxGetParameter, IntuneAppsWindowsuniversalappxGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-windowsuniversalappx-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWindowsuniversalappxGetResponse> IntuneAppsWindowsuniversalappxGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsWindowsuniversalappxGetParameter();
            return await this.SendAsync<IntuneAppsWindowsuniversalappxGetParameter, IntuneAppsWindowsuniversalappxGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-windowsuniversalappx-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWindowsuniversalappxGetResponse> IntuneAppsWindowsuniversalappxGetAsync(IntuneAppsWindowsuniversalappxGetParameter parameter)
        {
            return await this.SendAsync<IntuneAppsWindowsuniversalappxGetParameter, IntuneAppsWindowsuniversalappxGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-windowsuniversalappx-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWindowsuniversalappxGetResponse> IntuneAppsWindowsuniversalappxGetAsync(IntuneAppsWindowsuniversalappxGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsWindowsuniversalappxGetParameter, IntuneAppsWindowsuniversalappxGetResponse>(parameter, cancellationToken);
        }
    }
}
