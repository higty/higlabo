using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sharepointsettings-update?view=graph-rest-1.0
    /// </summary>
    public partial class SharepointSettingsUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Admin_Sharepoint_Settings: return $"/admin/sharepoint/settings";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum SharepointSettingsUpdateParameterImageTaggingChoice
        {
            Disabled,
            Basic,
            Enhanced,
        }
        public enum SharepointSettingsUpdateParameterSharingCapabilities
        {
            Disabled,
            ExternalUserSharingOnly,
            ExternalUserAndGuestSharing,
            ExistingExternalUserSharingOnly,
        }
        public enum SharepointSettingsUpdateParameterSharingDomainRestrictionMode
        {
            None,
            AllowList,
            BlockList,
        }
        public enum ApiPath
        {
            Admin_Sharepoint_Settings,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public Guid[]? AllowedDomainGuidsForSyncApp { get; set; }
        public Int32? DeletedUserPersonalSiteRetentionPeriodInDays { get; set; }
        public String[]? ExcludedFileExtensionsForSyncApp { get; set; }
        public IdleSessionSignOut? IdleSessionSignOut { get; set; }
        public SharepointSettingsUpdateParameterImageTaggingChoice ImageTaggingOption { get; set; }
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
        public SharepointSettingsUpdateParameterSharingCapabilities SharingCapability { get; set; }
        public SharepointSettingsUpdateParameterSharingDomainRestrictionMode SharingDomainRestrictionMode { get; set; }
        public string? SiteCreationDefaultManagedPath { get; set; }
        public Int32? SiteCreationDefaultStorageLimitInMB { get; set; }
        public string? TenantDefaultTimezone { get; set; }
    }
    public partial class SharepointSettingsUpdateResponse : RestApiResponse
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
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sharepointsettings-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/sharepointsettings-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SharepointSettingsUpdateResponse> SharepointSettingsUpdateAsync()
        {
            var p = new SharepointSettingsUpdateParameter();
            return await this.SendAsync<SharepointSettingsUpdateParameter, SharepointSettingsUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/sharepointsettings-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SharepointSettingsUpdateResponse> SharepointSettingsUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new SharepointSettingsUpdateParameter();
            return await this.SendAsync<SharepointSettingsUpdateParameter, SharepointSettingsUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/sharepointsettings-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SharepointSettingsUpdateResponse> SharepointSettingsUpdateAsync(SharepointSettingsUpdateParameter parameter)
        {
            return await this.SendAsync<SharepointSettingsUpdateParameter, SharepointSettingsUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/sharepointsettings-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SharepointSettingsUpdateResponse> SharepointSettingsUpdateAsync(SharepointSettingsUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SharepointSettingsUpdateParameter, SharepointSettingsUpdateResponse>(parameter, cancellationToken);
        }
    }
}
