using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sharepointsettings-get?view=graph-rest-1.0
    /// </summary>
    public partial class SharepointSettingsGetParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
            AllowedDomainGuidsForSyncApp,
            AvailableManagedPathsForSiteCreation,
            DeletedUserPersonalSiteRetentionPeriodInDays,
            ExcludedFileExtensionsForSyncApp,
            IdleSessionSignOut,
            ImageTaggingOption,
            IsCommentingOnSitePagesEnabled,
            IsFileActivityNotificationEnabled,
            IsLegacyAuthProtocolsEnabled,
            IsLoopEnabled,
            IsMacSyncAppEnabled,
            IsRequireAcceptingUserToMatchInvitedUserEnabled,
            IsResharingByExternalUsersEnabled,
            IsSharePointMobileNotificationEnabled,
            IsSharePointNewsfeedEnabled,
            IsSiteCreationEnabled,
            IsSiteCreationUIEnabled,
            IsSitePagesCreationEnabled,
            IsSitesStorageLimitAutomatic,
            IsSyncButtonHiddenOnPersonalSite,
            IsUnmanagedSyncAppForTenantRestricted,
            PersonalSiteDefaultStorageLimitInMB,
            SharingAllowedDomainList,
            SharingBlockedDomainList,
            SharingCapability,
            SharingDomainRestrictionMode,
            SiteCreationDefaultManagedPath,
            SiteCreationDefaultStorageLimitInMB,
            TenantDefaultTimezone,
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class SharepointSettingsGetResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/sharepointsettings-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/sharepointsettings-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SharepointSettingsGetResponse> SharepointSettingsGetAsync()
        {
            var p = new SharepointSettingsGetParameter();
            return await this.SendAsync<SharepointSettingsGetParameter, SharepointSettingsGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/sharepointsettings-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SharepointSettingsGetResponse> SharepointSettingsGetAsync(CancellationToken cancellationToken)
        {
            var p = new SharepointSettingsGetParameter();
            return await this.SendAsync<SharepointSettingsGetParameter, SharepointSettingsGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/sharepointsettings-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SharepointSettingsGetResponse> SharepointSettingsGetAsync(SharepointSettingsGetParameter parameter)
        {
            return await this.SendAsync<SharepointSettingsGetParameter, SharepointSettingsGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/sharepointsettings-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SharepointSettingsGetResponse> SharepointSettingsGetAsync(SharepointSettingsGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SharepointSettingsGetParameter, SharepointSettingsGetResponse>(parameter, cancellationToken);
        }
    }
}
