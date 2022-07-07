using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsWin32lobappGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneAppsWin32lobappGetResponse : RestApiResponse
    {
        public enum Win32LobAppMobileAppPublishingState
        {
            NotPublished,
            Processing,
            Published,
        }
        public enum Win32LobAppWindowsArchitecture
        {
            None,
            X86,
            X64,
            Arm,
            Neutral,
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
        public string? InstallCommandLine { get; set; }
        public string? UninstallCommandLine { get; set; }
        public WindowsArchitecture? ApplicableArchitectures { get; set; }
        public Int32? MinimumFreeDiskSpaceInMB { get; set; }
        public Int32? MinimumMemoryInMB { get; set; }
        public Int32? MinimumNumberOfProcessors { get; set; }
        public Int32? MinimumCpuSpeedInMHz { get; set; }
        public Win32LobAppRule[]? Rules { get; set; }
        public Win32LobAppInstallExperience? InstallExperience { get; set; }
        public Win32LobAppReturnCode[]? ReturnCodes { get; set; }
        public Win32LobAppMsiInformation? MsiInformation { get; set; }
        public string? SetupFilePath { get; set; }
        public string? MinimumSupportedWindowsRelease { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-win32lobapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWin32lobappGetResponse> IntuneAppsWin32lobappGetAsync()
        {
            var p = new IntuneAppsWin32lobappGetParameter();
            return await this.SendAsync<IntuneAppsWin32lobappGetParameter, IntuneAppsWin32lobappGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-win32lobapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWin32lobappGetResponse> IntuneAppsWin32lobappGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsWin32lobappGetParameter();
            return await this.SendAsync<IntuneAppsWin32lobappGetParameter, IntuneAppsWin32lobappGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-win32lobapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWin32lobappGetResponse> IntuneAppsWin32lobappGetAsync(IntuneAppsWin32lobappGetParameter parameter)
        {
            return await this.SendAsync<IntuneAppsWin32lobappGetParameter, IntuneAppsWin32lobappGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-win32lobapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWin32lobappGetResponse> IntuneAppsWin32lobappGetAsync(IntuneAppsWin32lobappGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsWin32lobappGetParameter, IntuneAppsWin32lobappGetResponse>(parameter, cancellationToken);
        }
    }
}
