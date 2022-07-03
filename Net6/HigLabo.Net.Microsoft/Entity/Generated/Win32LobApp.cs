using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-win32lobapp?view=graph-rest-1.0
    /// </summary>
    public partial class Win32LobApp
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public MimeContent? LargeIcon { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public bool IsFeatured { get; set; }
        public string PrivacyInformationUrl { get; set; }
        public string InformationUrl { get; set; }
        public string Owner { get; set; }
        public string Developer { get; set; }
        public string Notes { get; set; }
        public Win32LobAppMobileAppPublishingState PublishingState { get; set; }
        public string CommittedContentVersion { get; set; }
        public string FileName { get; set; }
        public Int64? Size { get; set; }
        public string InstallCommandLine { get; set; }
        public string UninstallCommandLine { get; set; }
        public Win32LobAppWindowsArchitecture ApplicableArchitectures { get; set; }
        public Int32? MinimumFreeDiskSpaceInMB { get; set; }
        public Int32? MinimumMemoryInMB { get; set; }
        public Int32? MinimumNumberOfProcessors { get; set; }
        public Int32? MinimumCpuSpeedInMHz { get; set; }
        public Win32LobAppRule[] Rules { get; set; }
        public Win32LobAppInstallExperience? InstallExperience { get; set; }
        public Win32LobAppReturnCode[] ReturnCodes { get; set; }
        public Win32LobAppMsiInformation? MsiInformation { get; set; }
        public string SetupFilePath { get; set; }
        public string MinimumSupportedWindowsRelease { get; set; }
    }
}
