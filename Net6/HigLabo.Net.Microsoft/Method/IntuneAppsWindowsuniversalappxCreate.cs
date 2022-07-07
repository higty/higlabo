using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsWindowsuniversalappxCreateParameter : IRestApiParameter
    {
        public enum IntuneAppsWindowsuniversalappxCreateParameterMobileAppPublishingState
        {
            NotPublished,
            Processing,
            Published,
        }
        public enum IntuneAppsWindowsuniversalappxCreateParameterWindowsArchitecture
        {
            None,
            X86,
            X64,
            Arm,
            Neutral,
        }
        public enum IntuneAppsWindowsuniversalappxCreateParameterWindowsDeviceType
        {
            None,
            Desktop,
            Mobile,
            Holographic,
            Team,
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
        public IntuneAppsWindowsuniversalappxCreateParameterMobileAppPublishingState PublishingState { get; set; }
        public string? CommittedContentVersion { get; set; }
        public string? FileName { get; set; }
        public Int64? Size { get; set; }
        public IntuneAppsWindowsuniversalappxCreateParameterWindowsArchitecture ApplicableArchitectures { get; set; }
        public IntuneAppsWindowsuniversalappxCreateParameterWindowsDeviceType ApplicableDeviceTypes { get; set; }
        public string? IdentityName { get; set; }
        public string? IdentityPublisherHash { get; set; }
        public string? IdentityResourceIdentifier { get; set; }
        public bool? IsBundle { get; set; }
        public WindowsMinimumOperatingSystem? MinimumSupportedOperatingSystem { get; set; }
        public string? IdentityVersion { get; set; }
    }
    public partial class IntuneAppsWindowsuniversalappxCreateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-windowsuniversalappx-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWindowsuniversalappxCreateResponse> IntuneAppsWindowsuniversalappxCreateAsync()
        {
            var p = new IntuneAppsWindowsuniversalappxCreateParameter();
            return await this.SendAsync<IntuneAppsWindowsuniversalappxCreateParameter, IntuneAppsWindowsuniversalappxCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-windowsuniversalappx-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWindowsuniversalappxCreateResponse> IntuneAppsWindowsuniversalappxCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsWindowsuniversalappxCreateParameter();
            return await this.SendAsync<IntuneAppsWindowsuniversalappxCreateParameter, IntuneAppsWindowsuniversalappxCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-windowsuniversalappx-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWindowsuniversalappxCreateResponse> IntuneAppsWindowsuniversalappxCreateAsync(IntuneAppsWindowsuniversalappxCreateParameter parameter)
        {
            return await this.SendAsync<IntuneAppsWindowsuniversalappxCreateParameter, IntuneAppsWindowsuniversalappxCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-windowsuniversalappx-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWindowsuniversalappxCreateResponse> IntuneAppsWindowsuniversalappxCreateAsync(IntuneAppsWindowsuniversalappxCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsWindowsuniversalappxCreateParameter, IntuneAppsWindowsuniversalappxCreateResponse>(parameter, cancellationToken);
        }
    }
}
