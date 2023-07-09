using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/sharepointsettings?view=graph-rest-1.0
    /// </summary>
    public partial class SharepointSettings
    {
        public enum SharepointSettingsImageTaggingChoice
        {
            Disabled,
            Basic,
            Enhanced,
        }
        public enum SharepointSettingsSharingCapabilities
        {
            Disabled,
            ExternalUserSharingOnly,
            ExternalUserAndGuestSharing,
            ExistingExternalUserSharingOnly,
        }
        public enum SharepointSettingsSharingDomainRestrictionMode
        {
            None,
            AllowList,
            BlockList,
        }

        public Guid[]? AllowedDomainGuidsForSyncApp { get; set; }
        public String[]? AvailableManagedPathsForSiteCreation { get; set; }
        public Int32? DeletedUserPersonalSiteRetentionPeriodInDays { get; set; }
        public String[]? ExcludedFileExtensionsForSyncApp { get; set; }
        public IdleSessionSignOut? IdleSessionSignOut { get; set; }
        public SharepointSettings? ImageTaggingOption { get; set; }
        public bool? IsCommentingOnSitePagesEnabled { get; set; }
        public bool? IsFileActivityNotificationEnabled { get; set; }
        public bool? IsLegacyAuthProtocolsEnabled { get; set; }
        public bool? IsLoopEnabled { get; set; }
        public bool? IsMacSyncAppEnabled { get; set; }
        public bool? IsRequireAcceptingUserToMatchInvitedUserEnabled { get; set; }
        public bool? IsResharingByExternalUsersEnabled { get; set; }
        public bool? IsSharePointMobileNotificationEnabled { get; set; }
        public bool? IsSharePointNewsfeedEnabled { get; set; }
        public bool? IsSiteCreationEnabled { get; set; }
        public bool? IsSiteCreationUIEnabled { get; set; }
        public bool? IsSitePagesCreationEnabled { get; set; }
        public bool? IsSitesStorageLimitAutomatic { get; set; }
        public bool? IsSyncButtonHiddenOnPersonalSite { get; set; }
        public bool? IsUnmanagedSyncAppForTenantRestricted { get; set; }
        public Int64? PersonalSiteDefaultStorageLimitInMB { get; set; }
        public String[]? SharingAllowedDomainList { get; set; }
        public String[]? SharingBlockedDomainList { get; set; }
        public SharepointSettingsSharingCapabilities SharingCapability { get; set; }
        public SharepointSettingsSharingDomainRestrictionMode SharingDomainRestrictionMode { get; set; }
        public string? SiteCreationDefaultManagedPath { get; set; }
        public Int32? SiteCreationDefaultStorageLimitInMB { get; set; }
        public string? TenantDefaultTimezone { get; set; }
    }
}
