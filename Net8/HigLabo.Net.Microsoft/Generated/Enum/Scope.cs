using HigLabo.Core;

namespace HigLabo.Net.Microsoft;

public enum Scope
{
    AccessReviewReadAll,
    AccessReviewReadWriteAll,
    AccessReviewReadWriteMembership,
    AdministrativeUnitReadAll,
    AdministrativeUnitReadWriteAll,
    AnalyticsRead,
    AppCatalogReadAll,
    AppCatalogReadWriteAll,
    AppCatalogSubmit,
    ApplicationReadAll,
    ApplicationReadWriteAll,
    AppRoleAssignmentReadWriteAll,
    DelegatedPermissionGrantReadWriteAll,
    ApplicationReadWriteOwnedBy,
    AuditLogReadAll,
    BitlockerKeyReadBasicAll,
    BitlockerKeyReadAll,
    BookingsReadAll,
    BookingsAppointmentReadWriteAll,
    BookingsReadWriteAll,
    BookingsManageAll,
    BrowserSiteListsReadAll,
    BrowserSiteListsReadWriteAll,
    CalendarsRead,
    CalendarsReadShared,
    CalendarsReadWrite,
    CalendarsReadWriteShared,
    CalendarsReadBasic,
    CalendarsReadBasicAll,
    CallsInitiateAll,
    CallsInitiateGroupCallAll,
    CallsJoinGroupCallAll,
    CallsJoinGroupCallasGuestAll,
    CallsAccessMediaAll,
    CallRecordsReadAll,
    CallRecordPstnCallsReadAll,
    ChannelReadBasicAll,
    ChannelCreate,
    ChannelDeleteAll,
    TeamworkMigrateAll,
    ChannelMemberReadAll,
    ChannelMemberReadWriteAll,
    ChannelMessageEdit,
    ChannelMessageReadAll,
    ChannelMessageSend,
    ChannelMessageUpdatePolicyViolationAll,
    ChannelSettingsReadAll,
    ChannelSettingsReadWriteAll,
    ChatRead,
    ChatReadBasic,
    ChatReadWrite,
    ChatManageDeletionAll,
    ChatReadWhereInstalled,
    ChatReadAll,
    ChatReadBasicWhereInstalled,
    ChatReadBasicAll,
    ChatUpdatePolicyViolationAll,
    ChatReadWriteWhereInstalled,
    ChatReadWriteAll,
    ChatMemberRead,
    ChatMemberReadWrite,
    ChatMemberReadWhereInstalled,
    ChatMemberReadAll,
    ChatMemberReadWriteWhereInstalled,
    ChatMemberReadWriteAll,
    ChatSettingsReadChat,
    ChatSettingsReadWriteChat,
    ChatMessageReadChat,
    ChatMemberReadChat,
    ChatManageChat,
    TeamsTabReadChat,
    TeamsTabCreateChat,
    TeamsTabDeleteChat,
    TeamsTabReadWriteChat,
    TeamsAppInstallationReadChat,
    OnlineMeetingReadBasicChat,
    CallsAccessMediaChat,
    CallsJoinGroupCallsChat,
    TeamsActivitySendChat,
    ChatMessageSend,
    CloudPCReadAll,
    CloudPCReadWriteAll,
    ConsentRequestReadAll,
    ConsentRequestReadWriteAll,
    CrossTenantUserProfileSharingRead,
    CrossTenantUserProfileSharingReadAll,
    CrossTenantUserProfileSharingReadWrite,
    CrossTenantUserProfileSharingReadWriteAll,
    ContactsRead,
    ContactsReadShared,
    ContactsReadWrite,
    ContactsReadWriteShared,
    CustomSecAttributeAssignmentReadAll,
    CustomSecAttributeAssignmentReadWriteAll,
    CustomSecAttributeDefinitionReadAll,
    CustomSecAttributeDefinitionReadWriteAll,
    DeviceLocalCredentialReadBasicAll,
    DeviceLocalCredentialReadAll,
    DelegatedAdminRelationshipReadAll,
    DelegatedAdminRelationshipReadWriteAll,
    DeviceRead,
    DeviceReadAll,
    DeviceCommand,
    DeviceReadWriteAll,
    DirectoryReadAll,
    DirectoryReadWriteAll,
    DirectoryAccessAsUserAll,
    DirectoryRecommendationsReadAll,
    DirectoryRecommendationsReadWriteAll,
    DomainReadAll,
    DomainReadWriteAll,
    EDiscoveryReadAll,
    EDiscoveryReadWriteAll,
    EduAdministrationRead,
    EduAdministrationReadWrite,
    EduAssignmentsReadBasic,
    EduAssignmentsReadWriteBasic,
    EduAssignmentsRead,
    EduAssignmentsReadWrite,
    EduRosterReadBasic,
    EduRosterRead,
    EduRosterReadWrite,
    EduAdministrationReadAll,
    EduAdministrationReadWriteAll,
    EduAssignmentsReadBasicAll,
    EduAssignmentsReadWriteBasicAll,
    EduAssignmentsReadAll,
    EduAssignmentsReadWriteAll,
    EduRosterReadBasicAll,
    EduRosterReadAll,
    EduRosterReadWriteAll,
    LearningContentReadAll,
    LearningContentReadWriteAll,
    LearningProviderRead,
    LearningProviderReadWrite,
    LearningAssignedCourseRead,
    LearningSelfInitiatedCourseRead,
    LearningAssignedCourseReadAll,
    LearningSelfInitiatedCourseReadAll,
    LearningAssignedCourseReadWriteAll,
    LearningSelfInitiatedCourseReadWriteAll,
    EntitlementManagementReadWriteAll,
    EntitlementManagementReadAll,
    FilesRead,
    FilesReadAll,
    FilesReadWrite,
    FilesReadWriteAll,
    FilesReadWriteAppFolder,
    FilesReadSelected,
    FilesReadWriteSelected,
    FinancialsReadWriteAll,
    GroupReadAll,
    GroupReadWriteAll,
    GroupMemberReadAll,
    GroupMemberReadWriteAll,
    UnifiedGroupMemberReadAsGuest,
    GroupCreate,
    IdentityProviderReadAll,
    IdentityProviderReadWriteAll,
    IdentityRiskEventReadAll,
    IdentityRiskyUserReadAll,
    IdentityRiskyUserReadWriteAll,
    IdentityRiskyServicePrincipalReadAll,
    IdentityRiskyServicePrincipalReadWriteAll,
    IdentityUserFlowReadAll,
    IdentityUserFlowReadWriteAll,
    SecurityIncidentReadAll,
    SecurityIncidentReadWriteAll,
    IndustryDataReadBasicAll,
    IndustryDataDataConnectorReadAll,
    IndustryDataDataConnectorReadWriteAll,
    IndustryDataDataConnectorUpload,
    IndustryDataInboundFlowReadAll,
    IndustryDataInboundFlowReadWriteAll,
    IndustryDataReferenceDefinitionReadAll,
    IndustryDataRunReadAll,
    IndustryDataSourceSystemReadAll,
    IndustryDataSourceSystemReadWriteAll,
    IndustryDataTimePeriodReadAll,
    IndustryDataTimePeriodReadWriteAll,
    InformationProtectionPolicyRead,
    InformationProtectionPolicyReadAll,
    DeviceManagementAppsReadAll,
    DeviceManagementAppsReadWriteAll,
    DeviceManagementConfigurationReadAll,
    DeviceManagementConfigurationReadWriteAll,
    DeviceManagementManagedDevicesPrivilegedOperationsAll,
    DeviceManagementManagedDevicesReadAll,
    DeviceManagementManagedDevicesReadWriteAll,
    DeviceManagementRBACReadAll,
    DeviceManagementRBACReadWriteAll,
    DeviceManagementServiceConfigReadAll,
    DeviceManagementServiceConfigReadWriteAll,
    LifecycleWorkflowsReadAll,
    LifecycleWorkflowsReadWriteAll,
    MailRead,
    MailReadBasic,
    MailReadWrite,
    MailReadShared,
    MailReadWriteShared,
    MailSend,
    MailSendShared,
    MailboxSettingsRead,
    MailboxSettingsReadWrite,
    IMAPAccessAsUserAll,
    POPAccessAsUserAll,
    SMTPSend,
    MailReadBasicAll,
    ManagedTenantsReadAll,
    ManagedTenantsReadWriteAll,
    MemberReadHidden,
    NotesRead,
    NotesCreate,
    NotesReadWrite,
    NotesReadAll,
    NotesReadWriteAll,
    NotesReadWriteCreatedByApp,
    NotificationsReadWriteCreatedByApp,
    OnlineMeetingsRead,
    OnlineMeetingsReadWrite,
    OnlineMeetingArtifactReadAll,
    OnlineMeetingTranscriptReadAll,
    OnlineMeetingsReadAll,
    OnlineMeetingsReadWriteAll,
    Email,
    OfflineAccess,
    Openid,
    Profile,
    OrganizationReadAll,
    OrganizationReadWriteAll,
    OrgContactReadAll,
    PeopleRead,
    PeopleReadAll,
    PrivilegedAccessReadWriteAzureAD,
    PrivilegedAccessReadWriteAzureADGroup,
    PrivilegedAccessReadWriteAzureResources,
    PrivilegedAssignmentScheduleReadAzureADGroup,
    PrivilegedEligibilityScheduleReadAzureADGroup,
    PrivilegedAssignmentScheduleReadWriteAzureADGroup,
    PrivilegedEligibilityScheduleReadWriteAzureADGroup,
    PrivilegedAccessReadAzureAD,
    PrivilegedAccessReadAzureADGroup,
    PrivilegedAccessReadAzureResources,
    PlaceReadAll,
    PlaceReadWriteAll,
    PolicyReadAll,
    PolicyReadPermissionGrant,
    PolicyReadWriteAccessReview,
    PolicyReadWriteApplicationConfiguration,
    PolicyReadWriteAuthenticationFlows,
    PolicyReadWriteAuthenticationMethod,
    PolicyReadWriteAuthorization,
    PolicyReadWriteConditionalAccess,
    PolicyReadWriteConsentRequest,
    PolicyReadWriteCrossTenantAccess,
    PolicyReadWriteFeatureRollout,
    PolicyReadWritePermissionGrant,
    PolicyReadWriteTrustFramework,
    PolicyReadWriteMobilityManagement,
    PolicyReadApplicationConfiguration,
    PresenceRead,
    PresenceReadAll,
    PresenceReadWrite,
    PresenceReadWriteAll,
    ProgramControlReadAll,
    ProgramControlReadWriteAll,
    RecordsManagementReadAll,
    RecordsManagementReadWriteAll,
    ReportsReadAll,
    RoleAssignmentScheduleReadDirectory,
    RoleEligibilityScheduleReadDirectory,
    RoleManagementReadAll,
    RoleManagementReadDirectory,
    RoleManagementPolicyReadDirectory,
    RoleManagementReadExchange,
    RoleAssignmentScheduleReadWriteDirectory,
    RoleEligibilityScheduleReadWriteDirectory,
    RoleManagementReadWriteDirectory,
    RoleManagementPolicyReadWriteDirectory,
    RoleManagementReadWriteExchange,
    ScheduleReadWriteAll,
    ScheduleReadAll,
    WorkforceIntegrationReadWriteAll,
    WorkforceIntegrationReadAll,
    ExternalConnectionReadAll,
    ExternalConnectionReadWriteAll,
    ExternalConnectionReadWriteOwnedBy,
    ExternalItemReadAll,
    ExternalItemReadWriteAll,
    ExternalItemReadWriteOwnedBy,
    AcronymReadAll,
    BookmarkReadAll,
    QnAReadAll,
    SearchConfigurationReadAll,
    SearchConfigurationReadWriteAll,
    AttackSimulationReadAll,
    AttackSimulationReadWriteAll,
    SecurityActionsReadAll,
    SecurityActionsReadWriteAll,
    SecurityAlertReadAll,
    SecurityAlertReadWriteAll,
    SecurityEventsReadAll,
    SecurityEventsReadWriteAll,
    ThreatIndicatorsReadWriteOwnedBy,
    ThreatIndicatorsReadAll,
    ServiceHealthReadAll,
    ServiceMessageReadAll,
    ServiceMessageViewpointWrite,
    ShortNotesRead,
    ShortNotesReadWrite,
    ShortNotesReadAll,
    ShortNotesReadWriteAll,
    SitesReadAll,
    SitesReadWriteAll,
    SitesManageAll,
    SitesFullControlAll,
    SitesSelected,
    TasksRead,
    TasksReadShared,
    TasksReadWrite,
    TasksReadWriteShared,
    TasksReadAll,
    TasksReadWriteAll,
    TermStoreReadAll,
    TermStoreReadWriteAll,
    TeamReadBasicAll,
    TeamCreate,
    TeamTemplatesRead,
    TeamTemplatesReadAll,
    TeamSettingsReadAll,
    TeamSettingsReadWriteAll,
    TeamsActivityRead,
    TeamsActivitySend,
    TeamsActivityReadAll,
    TeamsAppReadAll,
    TeamsAppReadWriteAll,
    TeamsAppInstallationReadForUser,
    TeamsAppInstallationReadWriteForUser,
    TeamsAppInstallationReadWriteSelfForUser,
    TeamsAppInstallationReadForTeam,
    TeamsAppInstallationReadWriteForTeam,
    TeamsAppInstallationReadWriteSelfForTeam,
    TeamsAppInstallationReadWriteAndConsentForChat,
    TeamsAppInstallationReadWriteAndConsentForTeam,
    TeamsAppInstallationReadWriteAndConsentSelfForChat,
    TeamsAppInstallationReadWriteAndConsentSelfForTeam,
    TeamsAppInstallationReadForUserAll,
    TeamsAppInstallationReadWriteForUserAll,
    TeamsAppInstallationReadWriteSelfForUserAll,
    TeamsAppInstallationReadForTeamAll,
    TeamsAppInstallationReadWriteForTeamAll,
    TeamsAppInstallationReadWriteSelfForTeamAll,
    TeamsAppInstallationReadWriteAndConsentForChatAll,
    TeamsAppInstallationReadWriteAndConsentForTeamAll,
    TeamsAppInstallationReadWriteAndConsentSelfForChatAll,
    TeamsAppInstallationReadWriteAndConsentSelfForTeamAll,
    TeamworkAppSettingsReadAll,
    TeamworkAppSettingsReadWriteAll,
    TeamworkDeviceReadAll,
    TeamworkDeviceReadWriteAll,
    TeamMemberReadAll,
    TeamMemberReadWriteAll,
    TeamSettingsReadGroup,
    TeamSettingsReadWriteGroup,
    ChannelSettingsReadGroup,
    ChannelSettingsReadWriteGroup,
    ChannelCreateGroup,
    ChannelDeleteGroup,
    ChannelMessageReadGroup,
    TeamsAppInstallationReadGroup,
    TeamsTabReadGroup,
    TeamsTabCreateGroup,
    TeamsTabReadWriteGroup,
    TeamsTabDeleteGroup,
    TeamMemberReadGroup,
    MemberReadGroup,
    OwnerReadGroup,
    FileReadGroup,
    TeamsActivitySendGroup,
    TeamsTabReadAll,
    TeamsTabReadWriteAll,
    TeamsTabCreate,
    TeamsTabReadWriteSelfForChat,
    TeamsTabReadWriteSelfForTeam,
    TeamsTabReadWriteSelfForUser,
    TeamsTabReadWriteSelfForChatAll,
    TeamsTabReadWriteSelfForTeamAll,
    TeamsTabReadWriteSelfForUserAll,
    TeamworkTagReadWrite,
    TeamworkTagRead,
    TeamworkTagReadWriteAll,
    TeamworkTagReadAll,
    CrossTenantInformationReadBasicAll,
    AgreementReadAll,
    AgreementReadWriteAll,
    AgreementAcceptanceRead,
    AgreementAcceptanceReadAll,
    ThreatAssessmentReadWriteAll,
    ThreatAssessmentReadAll,
    ThreatHuntingReadAll,
    ThreatIntelligenceReadAll,
    PrinterCreate,
    PrinterFullControlAll,
    PrinterReadAll,
    PrinterReadWriteAll,
    PrinterShareReadBasicAll,
    PrinterShareReadAll,
    PrinterShareReadWriteAll,
    PrintJobCreate,
    PrintJobRead,
    PrintJobReadAll,
    PrintJobReadBasic,
    PrintJobReadBasicAll,
    PrintJobReadWrite,
    PrintJobReadWriteAll,
    PrintJobReadWriteBasic,
    PrintJobReadWriteBasicAll,
    PrintConnectorReadAll,
    PrintConnectorReadWriteAll,
    PrintSettingsReadAll,
    PrintSettingsReadWriteAll,
    PrintJobManageAll,
    PrintTaskDefinitionReadWriteAll,
    UserRead,
    UserReadWrite,
    UserReadBasicAll,
    UserReadAll,
    UserReadWriteAll,
    UserInviteAll,
    UserEnableDisableAccountAll,
    UserExportAll,
    UserManageIdentitiesAll,
    UserLifeCycleInfoReadAll,
    UserLifeCycleInfoReadWriteAll,
    UserActivityReadWriteCreatedByApp,
    UserAuthenticationMethodRead,
    UserAuthenticationMethodReadAll,
    UserAuthenticationMethodReadWrite,
    UserAuthenticationMethodReadWriteAll,
    WindowsUpdatesReadWriteAll,
}
public static class ScopeExtensions
{
    public static string GetScopeName(this Scope value)
    {
        switch(value)
        {
            case Scope.AccessReviewReadAll: return "AccessReview.Read.All";
            case Scope.AccessReviewReadWriteAll: return "AccessReview.ReadWrite.All";
            case Scope.AccessReviewReadWriteMembership: return "AccessReview.ReadWrite.Membership";
            case Scope.AdministrativeUnitReadAll: return "AdministrativeUnit.Read.All";
            case Scope.AdministrativeUnitReadWriteAll: return "AdministrativeUnit.ReadWrite.All";
            case Scope.AnalyticsRead: return "Analytics.Read";
            case Scope.AppCatalogReadAll: return "AppCatalog.Read.All";
            case Scope.AppCatalogReadWriteAll: return "AppCatalog.ReadWrite.All";
            case Scope.AppCatalogSubmit: return "AppCatalog.Submit";
            case Scope.ApplicationReadAll: return "Application.Read.All";
            case Scope.ApplicationReadWriteAll: return "Application.ReadWrite.All";
            case Scope.AppRoleAssignmentReadWriteAll: return "AppRoleAssignment.ReadWrite.All";
            case Scope.DelegatedPermissionGrantReadWriteAll: return "DelegatedPermissionGrant.ReadWrite.All";
            case Scope.ApplicationReadWriteOwnedBy: return "Application.ReadWrite.OwnedBy";
            case Scope.AuditLogReadAll: return "AuditLog.Read.All";
            case Scope.BitlockerKeyReadBasicAll: return "BitlockerKey.ReadBasic.All";
            case Scope.BitlockerKeyReadAll: return "BitlockerKey.Read.All";
            case Scope.BookingsReadAll: return "Bookings.Read.All";
            case Scope.BookingsAppointmentReadWriteAll: return "BookingsAppointment.ReadWrite.All";
            case Scope.BookingsReadWriteAll: return "Bookings.ReadWrite.All";
            case Scope.BookingsManageAll: return "Bookings.Manage.All";
            case Scope.BrowserSiteListsReadAll: return "BrowserSiteLists.Read.All";
            case Scope.BrowserSiteListsReadWriteAll: return "BrowserSiteLists.ReadWrite.All";
            case Scope.CalendarsRead: return "Calendars.Read";
            case Scope.CalendarsReadShared: return "Calendars.Read.Shared";
            case Scope.CalendarsReadWrite: return "Calendars.ReadWrite";
            case Scope.CalendarsReadWriteShared: return "Calendars.ReadWrite.Shared";
            case Scope.CalendarsReadBasic: return "Calendars.ReadBasic";
            case Scope.CalendarsReadBasicAll: return "Calendars.ReadBasic.All";
            case Scope.CallsInitiateAll: return "Calls.Initiate.All";
            case Scope.CallsInitiateGroupCallAll: return "Calls.InitiateGroupCall.All";
            case Scope.CallsJoinGroupCallAll: return "Calls.JoinGroupCall.All";
            case Scope.CallsJoinGroupCallasGuestAll: return "Calls.JoinGroupCallasGuest.All";
            case Scope.CallsAccessMediaAll: return "Calls.AccessMedia.All";
            case Scope.CallRecordsReadAll: return "CallRecords.Read.All";
            case Scope.CallRecordPstnCallsReadAll: return "CallRecord-PstnCalls.Read.All";
            case Scope.ChannelReadBasicAll: return "Channel.ReadBasic.All";
            case Scope.ChannelCreate: return "Channel.Create";
            case Scope.ChannelDeleteAll: return "Channel.Delete.All";
            case Scope.TeamworkMigrateAll: return "Teamwork.Migrate.All";
            case Scope.ChannelMemberReadAll: return "ChannelMember.Read.All";
            case Scope.ChannelMemberReadWriteAll: return "ChannelMember.ReadWrite.All";
            case Scope.ChannelMessageEdit: return "ChannelMessage.Edit";
            case Scope.ChannelMessageReadAll: return "ChannelMessage.Read.All";
            case Scope.ChannelMessageSend: return "ChannelMessage.Send";
            case Scope.ChannelMessageUpdatePolicyViolationAll: return "ChannelMessage.UpdatePolicyViolation.All";
            case Scope.ChannelSettingsReadAll: return "ChannelSettings.Read.All";
            case Scope.ChannelSettingsReadWriteAll: return "ChannelSettings.ReadWrite.All";
            case Scope.ChatRead: return "Chat.Read";
            case Scope.ChatReadBasic: return "Chat.ReadBasic";
            case Scope.ChatReadWrite: return "Chat.ReadWrite";
            case Scope.ChatManageDeletionAll: return "Chat.ManageDeletion.All";
            case Scope.ChatReadWhereInstalled: return "Chat.Read.WhereInstalled";
            case Scope.ChatReadAll: return "Chat.Read.All";
            case Scope.ChatReadBasicWhereInstalled: return "Chat.ReadBasic.WhereInstalled";
            case Scope.ChatReadBasicAll: return "Chat.ReadBasic.All";
            case Scope.ChatUpdatePolicyViolationAll: return "Chat.UpdatePolicyViolation.All";
            case Scope.ChatReadWriteWhereInstalled: return "Chat.ReadWrite.WhereInstalled";
            case Scope.ChatReadWriteAll: return "Chat.ReadWrite.All";
            case Scope.ChatMemberRead: return "ChatMember.Read";
            case Scope.ChatMemberReadWrite: return "ChatMember.ReadWrite";
            case Scope.ChatMemberReadWhereInstalled: return "ChatMember.Read.WhereInstalled";
            case Scope.ChatMemberReadAll: return "ChatMember.Read.All";
            case Scope.ChatMemberReadWriteWhereInstalled: return "ChatMember.ReadWrite.WhereInstalled";
            case Scope.ChatMemberReadWriteAll: return "ChatMember.ReadWrite.All";
            case Scope.ChatSettingsReadChat: return "ChatSettings.Read.Chat";
            case Scope.ChatSettingsReadWriteChat: return "ChatSettings.ReadWrite.Chat";
            case Scope.ChatMessageReadChat: return "ChatMessage.Read.Chat";
            case Scope.ChatMemberReadChat: return "ChatMember.Read.Chat";
            case Scope.ChatManageChat: return "Chat.Manage.Chat";
            case Scope.TeamsTabReadChat: return "TeamsTab.Read.Chat";
            case Scope.TeamsTabCreateChat: return "TeamsTab.Create.Chat";
            case Scope.TeamsTabDeleteChat: return "TeamsTab.Delete.Chat";
            case Scope.TeamsTabReadWriteChat: return "TeamsTab.ReadWrite.Chat";
            case Scope.TeamsAppInstallationReadChat: return "TeamsAppInstallation.Read.Chat";
            case Scope.OnlineMeetingReadBasicChat: return "OnlineMeeting.ReadBasic.Chat";
            case Scope.CallsAccessMediaChat: return "Calls.AccessMedia.Chat";
            case Scope.CallsJoinGroupCallsChat: return "Calls.JoinGroupCalls.Chat";
            case Scope.TeamsActivitySendChat: return "TeamsActivity.Send.Chat";
            case Scope.ChatMessageSend: return "ChatMessage.Send";
            case Scope.CloudPCReadAll: return "CloudPC.Read.All";
            case Scope.CloudPCReadWriteAll: return "CloudPC.ReadWrite.All";
            case Scope.ConsentRequestReadAll: return "ConsentRequest.Read.All";
            case Scope.ConsentRequestReadWriteAll: return "ConsentRequest.ReadWrite.All";
            case Scope.CrossTenantUserProfileSharingRead: return "CrossTenantUserProfileSharing.Read";
            case Scope.CrossTenantUserProfileSharingReadAll: return "CrossTenantUserProfileSharing.Read.All";
            case Scope.CrossTenantUserProfileSharingReadWrite: return "CrossTenantUserProfileSharing.ReadWrite";
            case Scope.CrossTenantUserProfileSharingReadWriteAll: return "CrossTenantUserProfileSharing.ReadWrite.All";
            case Scope.ContactsRead: return "Contacts.Read";
            case Scope.ContactsReadShared: return "Contacts.Read.Shared";
            case Scope.ContactsReadWrite: return "Contacts.ReadWrite";
            case Scope.ContactsReadWriteShared: return "Contacts.ReadWrite.Shared";
            case Scope.CustomSecAttributeAssignmentReadAll: return "CustomSecAttributeAssignment.Read.All";
            case Scope.CustomSecAttributeAssignmentReadWriteAll: return "CustomSecAttributeAssignment.ReadWrite.All";
            case Scope.CustomSecAttributeDefinitionReadAll: return "CustomSecAttributeDefinition.Read.All";
            case Scope.CustomSecAttributeDefinitionReadWriteAll: return "CustomSecAttributeDefinition.ReadWrite.All";
            case Scope.DeviceLocalCredentialReadBasicAll: return "DeviceLocalCredential.ReadBasic.All";
            case Scope.DeviceLocalCredentialReadAll: return "DeviceLocalCredential.Read.All";
            case Scope.DelegatedAdminRelationshipReadAll: return "DelegatedAdminRelationship.Read.All";
            case Scope.DelegatedAdminRelationshipReadWriteAll: return "DelegatedAdminRelationship.ReadWrite.All";
            case Scope.DeviceRead: return "Device.Read";
            case Scope.DeviceReadAll: return "Device.Read.All";
            case Scope.DeviceCommand: return "Device.Command";
            case Scope.DeviceReadWriteAll: return "Device.ReadWrite.All";
            case Scope.DirectoryReadAll: return "Directory.Read.All";
            case Scope.DirectoryReadWriteAll: return "Directory.ReadWrite.All";
            case Scope.DirectoryAccessAsUserAll: return "Directory.AccessAsUser.All";
            case Scope.DirectoryRecommendationsReadAll: return "DirectoryRecommendations.Read.All";
            case Scope.DirectoryRecommendationsReadWriteAll: return "DirectoryRecommendations.ReadWrite.All";
            case Scope.DomainReadAll: return "Domain.Read.All";
            case Scope.DomainReadWriteAll: return "Domain.ReadWrite.All";
            case Scope.EDiscoveryReadAll: return "eDiscovery.Read.All";
            case Scope.EDiscoveryReadWriteAll: return "eDiscovery.ReadWrite.All";
            case Scope.EduAdministrationRead: return "EduAdministration.Read";
            case Scope.EduAdministrationReadWrite: return "EduAdministration.ReadWrite";
            case Scope.EduAssignmentsReadBasic: return "EduAssignments.ReadBasic";
            case Scope.EduAssignmentsReadWriteBasic: return "EduAssignments.ReadWriteBasic";
            case Scope.EduAssignmentsRead: return "EduAssignments.Read";
            case Scope.EduAssignmentsReadWrite: return "EduAssignments.ReadWrite";
            case Scope.EduRosterReadBasic: return "EduRoster.ReadBasic";
            case Scope.EduRosterRead: return "EduRoster.Read";
            case Scope.EduRosterReadWrite: return "EduRoster.ReadWrite";
            case Scope.EduAdministrationReadAll: return "EduAdministration.Read.All";
            case Scope.EduAdministrationReadWriteAll: return "EduAdministration.ReadWrite.All";
            case Scope.EduAssignmentsReadBasicAll: return "EduAssignments.ReadBasic.All";
            case Scope.EduAssignmentsReadWriteBasicAll: return "EduAssignments.ReadWriteBasic.All";
            case Scope.EduAssignmentsReadAll: return "EduAssignments.Read.All";
            case Scope.EduAssignmentsReadWriteAll: return "EduAssignments.ReadWrite.All";
            case Scope.EduRosterReadBasicAll: return "EduRoster.ReadBasic.All";
            case Scope.EduRosterReadAll: return "EduRoster.Read.All";
            case Scope.EduRosterReadWriteAll: return "EduRoster.ReadWrite.All";
            case Scope.LearningContentReadAll: return "LearningContent.Read.All";
            case Scope.LearningContentReadWriteAll: return "LearningContent.ReadWrite.All";
            case Scope.LearningProviderRead: return "LearningProvider.Read";
            case Scope.LearningProviderReadWrite: return "LearningProvider.ReadWrite";
            case Scope.LearningAssignedCourseRead: return "LearningAssignedCourse.Read";
            case Scope.LearningSelfInitiatedCourseRead: return "LearningSelfInitiatedCourse.Read";
            case Scope.LearningAssignedCourseReadAll: return "LearningAssignedCourse.Read.All";
            case Scope.LearningSelfInitiatedCourseReadAll: return "LearningSelfInitiatedCourse.Read.All";
            case Scope.LearningAssignedCourseReadWriteAll: return "LearningAssignedCourse.ReadWrite.All";
            case Scope.LearningSelfInitiatedCourseReadWriteAll: return "LearningSelfInitiatedCourse.ReadWrite.All";
            case Scope.EntitlementManagementReadWriteAll: return "EntitlementManagement.ReadWrite.All";
            case Scope.EntitlementManagementReadAll: return "EntitlementManagement.Read.All";
            case Scope.FilesRead: return "Files.Read";
            case Scope.FilesReadAll: return "Files.Read.All";
            case Scope.FilesReadWrite: return "Files.ReadWrite";
            case Scope.FilesReadWriteAll: return "Files.ReadWrite.All";
            case Scope.FilesReadWriteAppFolder: return "Files.ReadWrite.AppFolder";
            case Scope.FilesReadSelected: return "Files.Read.Selected";
            case Scope.FilesReadWriteSelected: return "Files.ReadWrite.Selected";
            case Scope.FinancialsReadWriteAll: return "Financials.ReadWrite.All";
            case Scope.GroupReadAll: return "Group.Read.All";
            case Scope.GroupReadWriteAll: return "Group.ReadWrite.All";
            case Scope.GroupMemberReadAll: return "GroupMember.Read.All";
            case Scope.GroupMemberReadWriteAll: return "GroupMember.ReadWrite.All";
            case Scope.UnifiedGroupMemberReadAsGuest: return "UnifiedGroupMember.Read.AsGuest";
            case Scope.GroupCreate: return "Group.Create";
            case Scope.IdentityProviderReadAll: return "IdentityProvider.Read.All";
            case Scope.IdentityProviderReadWriteAll: return "IdentityProvider.ReadWrite.All";
            case Scope.IdentityRiskEventReadAll: return "IdentityRiskEvent.Read.All";
            case Scope.IdentityRiskyUserReadAll: return "IdentityRiskyUser.Read.All";
            case Scope.IdentityRiskyUserReadWriteAll: return "IdentityRiskyUser.ReadWrite.All";
            case Scope.IdentityRiskyServicePrincipalReadAll: return "IdentityRiskyServicePrincipal.Read.All";
            case Scope.IdentityRiskyServicePrincipalReadWriteAll: return "IdentityRiskyServicePrincipal.ReadWrite.All";
            case Scope.IdentityUserFlowReadAll: return "IdentityUserFlow.Read.All";
            case Scope.IdentityUserFlowReadWriteAll: return "IdentityUserFlow.ReadWrite.All";
            case Scope.SecurityIncidentReadAll: return "SecurityIncident.Read.All";
            case Scope.SecurityIncidentReadWriteAll: return "SecurityIncident.ReadWrite.All";
            case Scope.IndustryDataReadBasicAll: return "IndustryData.ReadBasic.All";
            case Scope.IndustryDataDataConnectorReadAll: return "IndustryData-DataConnector.Read.All";
            case Scope.IndustryDataDataConnectorReadWriteAll: return "IndustryData-DataConnector.ReadWrite.All";
            case Scope.IndustryDataDataConnectorUpload: return "IndustryData-DataConnector.Upload";
            case Scope.IndustryDataInboundFlowReadAll: return "IndustryData-InboundFlow.Read.All";
            case Scope.IndustryDataInboundFlowReadWriteAll: return "IndustryData-InboundFlow.ReadWrite.All";
            case Scope.IndustryDataReferenceDefinitionReadAll: return "IndustryData-ReferenceDefinition.Read.All";
            case Scope.IndustryDataRunReadAll: return "IndustryData-Run.Read.All";
            case Scope.IndustryDataSourceSystemReadAll: return "IndustryData-SourceSystem.Read.All";
            case Scope.IndustryDataSourceSystemReadWriteAll: return "IndustryData-SourceSystem.ReadWrite.All";
            case Scope.IndustryDataTimePeriodReadAll: return "IndustryData-TimePeriod.Read.All";
            case Scope.IndustryDataTimePeriodReadWriteAll: return "IndustryData-TimePeriod.ReadWrite.All";
            case Scope.InformationProtectionPolicyRead: return "InformationProtectionPolicy.Read";
            case Scope.InformationProtectionPolicyReadAll: return "InformationProtectionPolicy.Read.All";
            case Scope.DeviceManagementAppsReadAll: return "DeviceManagementApps.Read.All";
            case Scope.DeviceManagementAppsReadWriteAll: return "DeviceManagementApps.ReadWrite.All";
            case Scope.DeviceManagementConfigurationReadAll: return "DeviceManagementConfiguration.Read.All";
            case Scope.DeviceManagementConfigurationReadWriteAll: return "DeviceManagementConfiguration.ReadWrite.All";
            case Scope.DeviceManagementManagedDevicesPrivilegedOperationsAll: return "DeviceManagementManagedDevices.PrivilegedOperations.All";
            case Scope.DeviceManagementManagedDevicesReadAll: return "DeviceManagementManagedDevices.Read.All";
            case Scope.DeviceManagementManagedDevicesReadWriteAll: return "DeviceManagementManagedDevices.ReadWrite.All";
            case Scope.DeviceManagementRBACReadAll: return "DeviceManagementRBAC.Read.All";
            case Scope.DeviceManagementRBACReadWriteAll: return "DeviceManagementRBAC.ReadWrite.All";
            case Scope.DeviceManagementServiceConfigReadAll: return "DeviceManagementServiceConfig.Read.All";
            case Scope.DeviceManagementServiceConfigReadWriteAll: return "DeviceManagementServiceConfig.ReadWrite.All";
            case Scope.LifecycleWorkflowsReadAll: return "LifecycleWorkflows.Read.All";
            case Scope.LifecycleWorkflowsReadWriteAll: return "LifecycleWorkflows.ReadWrite.All";
            case Scope.MailRead: return "Mail.Read";
            case Scope.MailReadBasic: return "Mail.ReadBasic";
            case Scope.MailReadWrite: return "Mail.ReadWrite";
            case Scope.MailReadShared: return "Mail.Read.Shared";
            case Scope.MailReadWriteShared: return "Mail.ReadWrite.Shared";
            case Scope.MailSend: return "Mail.Send";
            case Scope.MailSendShared: return "Mail.Send.Shared";
            case Scope.MailboxSettingsRead: return "MailboxSettings.Read";
            case Scope.MailboxSettingsReadWrite: return "MailboxSettings.ReadWrite";
            case Scope.IMAPAccessAsUserAll: return "IMAP.AccessAsUser.All";
            case Scope.POPAccessAsUserAll: return "POP.AccessAsUser.All";
            case Scope.SMTPSend: return "SMTP.Send";
            case Scope.MailReadBasicAll: return "Mail.ReadBasic.All";
            case Scope.ManagedTenantsReadAll: return "ManagedTenants.Read.All";
            case Scope.ManagedTenantsReadWriteAll: return "ManagedTenants.ReadWrite.All";
            case Scope.MemberReadHidden: return "Member.Read.Hidden";
            case Scope.NotesRead: return "Notes.Read";
            case Scope.NotesCreate: return "Notes.Create";
            case Scope.NotesReadWrite: return "Notes.ReadWrite";
            case Scope.NotesReadAll: return "Notes.Read.All";
            case Scope.NotesReadWriteAll: return "Notes.ReadWrite.All";
            case Scope.NotesReadWriteCreatedByApp: return "Notes.ReadWrite.CreatedByApp";
            case Scope.NotificationsReadWriteCreatedByApp: return "Notifications.ReadWrite.CreatedByApp";
            case Scope.OnlineMeetingsRead: return "OnlineMeetings.Read";
            case Scope.OnlineMeetingsReadWrite: return "OnlineMeetings.ReadWrite";
            case Scope.OnlineMeetingArtifactReadAll: return "OnlineMeetingArtifact.Read.All";
            case Scope.OnlineMeetingTranscriptReadAll: return "OnlineMeetingTranscript.Read.All";
            case Scope.OnlineMeetingsReadAll: return "OnlineMeetings.Read.All";
            case Scope.OnlineMeetingsReadWriteAll: return "OnlineMeetings.ReadWrite.All";
            case Scope.Email: return "email";
            case Scope.OfflineAccess: return "offline_access";
            case Scope.Openid: return "openid";
            case Scope.Profile: return "profile";
            case Scope.OrganizationReadAll: return "Organization.Read.All";
            case Scope.OrganizationReadWriteAll: return "Organization.ReadWrite.All";
            case Scope.OrgContactReadAll: return "OrgContact.Read.All";
            case Scope.PeopleRead: return "People.Read";
            case Scope.PeopleReadAll: return "People.Read.All";
            case Scope.PrivilegedAccessReadWriteAzureAD: return "PrivilegedAccess.ReadWrite.AzureAD";
            case Scope.PrivilegedAccessReadWriteAzureADGroup: return "PrivilegedAccess.ReadWrite.AzureADGroup";
            case Scope.PrivilegedAccessReadWriteAzureResources: return "PrivilegedAccess.ReadWrite.AzureResources";
            case Scope.PrivilegedAssignmentScheduleReadAzureADGroup: return "PrivilegedAssignmentSchedule.Read.AzureADGroup";
            case Scope.PrivilegedEligibilityScheduleReadAzureADGroup: return "PrivilegedEligibilitySchedule.Read.AzureADGroup";
            case Scope.PrivilegedAssignmentScheduleReadWriteAzureADGroup: return "PrivilegedAssignmentSchedule.ReadWrite.AzureADGroup";
            case Scope.PrivilegedEligibilityScheduleReadWriteAzureADGroup: return "PrivilegedEligibilitySchedule.ReadWrite.AzureADGroup";
            case Scope.PrivilegedAccessReadAzureAD: return "PrivilegedAccess.Read.AzureAD";
            case Scope.PrivilegedAccessReadAzureADGroup: return "PrivilegedAccess.Read.AzureADGroup";
            case Scope.PrivilegedAccessReadAzureResources: return "PrivilegedAccess.Read.AzureResources";
            case Scope.PlaceReadAll: return "Place.Read.All";
            case Scope.PlaceReadWriteAll: return "Place.ReadWrite.All";
            case Scope.PolicyReadAll: return "Policy.Read.All";
            case Scope.PolicyReadPermissionGrant: return "Policy.Read.PermissionGrant";
            case Scope.PolicyReadWriteAccessReview: return "Policy.ReadWrite.AccessReview";
            case Scope.PolicyReadWriteApplicationConfiguration: return "Policy.ReadWrite.ApplicationConfiguration";
            case Scope.PolicyReadWriteAuthenticationFlows: return "Policy.ReadWrite.AuthenticationFlows";
            case Scope.PolicyReadWriteAuthenticationMethod: return "Policy.ReadWrite.AuthenticationMethod";
            case Scope.PolicyReadWriteAuthorization: return "Policy.ReadWrite.Authorization";
            case Scope.PolicyReadWriteConditionalAccess: return "Policy.ReadWrite.ConditionalAccess";
            case Scope.PolicyReadWriteConsentRequest: return "Policy.ReadWrite.ConsentRequest";
            case Scope.PolicyReadWriteCrossTenantAccess: return "Policy.ReadWrite.CrossTenantAccess";
            case Scope.PolicyReadWriteFeatureRollout: return "Policy.ReadWrite.FeatureRollout";
            case Scope.PolicyReadWritePermissionGrant: return "Policy.ReadWrite.PermissionGrant";
            case Scope.PolicyReadWriteTrustFramework: return "Policy.ReadWrite.TrustFramework";
            case Scope.PolicyReadWriteMobilityManagement: return "Policy.ReadWrite.MobilityManagement";
            case Scope.PolicyReadApplicationConfiguration: return "Policy.Read.ApplicationConfiguration";
            case Scope.PresenceRead: return "Presence.Read";
            case Scope.PresenceReadAll: return "Presence.Read.All";
            case Scope.PresenceReadWrite: return "Presence.ReadWrite";
            case Scope.PresenceReadWriteAll: return "Presence.ReadWrite.All";
            case Scope.ProgramControlReadAll: return "ProgramControl.Read.All";
            case Scope.ProgramControlReadWriteAll: return "ProgramControl.ReadWrite.All";
            case Scope.RecordsManagementReadAll: return "RecordsManagement.Read.All";
            case Scope.RecordsManagementReadWriteAll: return "RecordsManagement.ReadWrite.All";
            case Scope.ReportsReadAll: return "Reports.Read.All";
            case Scope.RoleAssignmentScheduleReadDirectory: return "RoleAssignmentSchedule.Read.Directory";
            case Scope.RoleEligibilityScheduleReadDirectory: return "RoleEligibilitySchedule.Read.Directory";
            case Scope.RoleManagementReadAll: return "RoleManagement.Read.All";
            case Scope.RoleManagementReadDirectory: return "RoleManagement.Read.Directory";
            case Scope.RoleManagementPolicyReadDirectory: return "RoleManagementPolicy.Read.Directory";
            case Scope.RoleManagementReadExchange: return "RoleManagement.Read.Exchange";
            case Scope.RoleAssignmentScheduleReadWriteDirectory: return "RoleAssignmentSchedule.ReadWrite.Directory";
            case Scope.RoleEligibilityScheduleReadWriteDirectory: return "RoleEligibilitySchedule.ReadWrite.Directory";
            case Scope.RoleManagementReadWriteDirectory: return "RoleManagement.ReadWrite.Directory";
            case Scope.RoleManagementPolicyReadWriteDirectory: return "RoleManagementPolicy.ReadWrite.Directory";
            case Scope.RoleManagementReadWriteExchange: return "RoleManagement.ReadWrite.Exchange";
            case Scope.ScheduleReadWriteAll: return "Schedule.ReadWrite.All";
            case Scope.ScheduleReadAll: return "Schedule.Read.All";
            case Scope.WorkforceIntegrationReadWriteAll: return "WorkforceIntegration.ReadWrite.All";
            case Scope.WorkforceIntegrationReadAll: return "WorkforceIntegration.Read.All";
            case Scope.ExternalConnectionReadAll: return "ExternalConnection.Read.All";
            case Scope.ExternalConnectionReadWriteAll: return "ExternalConnection.ReadWrite.All";
            case Scope.ExternalConnectionReadWriteOwnedBy: return "ExternalConnection.ReadWrite.OwnedBy";
            case Scope.ExternalItemReadAll: return "ExternalItem.Read.All";
            case Scope.ExternalItemReadWriteAll: return "ExternalItem.ReadWrite.All";
            case Scope.ExternalItemReadWriteOwnedBy: return "ExternalItem.ReadWrite.OwnedBy";
            case Scope.AcronymReadAll: return "Acronym.Read.All";
            case Scope.BookmarkReadAll: return "Bookmark.Read.All";
            case Scope.QnAReadAll: return "QnA.Read.All";
            case Scope.SearchConfigurationReadAll: return "SearchConfiguration.Read.All";
            case Scope.SearchConfigurationReadWriteAll: return "SearchConfiguration.ReadWrite.All";
            case Scope.AttackSimulationReadAll: return "AttackSimulation.Read.All";
            case Scope.AttackSimulationReadWriteAll: return "AttackSimulation.ReadWrite.All";
            case Scope.SecurityActionsReadAll: return "SecurityActions.Read.All";
            case Scope.SecurityActionsReadWriteAll: return "SecurityActions.ReadWrite.All";
            case Scope.SecurityAlertReadAll: return "SecurityAlert.Read.All";
            case Scope.SecurityAlertReadWriteAll: return "SecurityAlert.ReadWrite.All";
            case Scope.SecurityEventsReadAll: return "SecurityEvents.Read.All";
            case Scope.SecurityEventsReadWriteAll: return "SecurityEvents.ReadWrite.All";
            case Scope.ThreatIndicatorsReadWriteOwnedBy: return "ThreatIndicators.ReadWrite.OwnedBy";
            case Scope.ThreatIndicatorsReadAll: return "ThreatIndicators.Read.All";
            case Scope.ServiceHealthReadAll: return "ServiceHealth.Read.All";
            case Scope.ServiceMessageReadAll: return "ServiceMessage.Read.All";
            case Scope.ServiceMessageViewpointWrite: return "ServiceMessageViewpoint.Write";
            case Scope.ShortNotesRead: return "ShortNotes.Read";
            case Scope.ShortNotesReadWrite: return "ShortNotes.ReadWrite";
            case Scope.ShortNotesReadAll: return "ShortNotes.Read.All";
            case Scope.ShortNotesReadWriteAll: return "ShortNotes.ReadWrite.All";
            case Scope.SitesReadAll: return "Sites.Read.All";
            case Scope.SitesReadWriteAll: return "Sites.ReadWrite.All";
            case Scope.SitesManageAll: return "Sites.Manage.All";
            case Scope.SitesFullControlAll: return "Sites.FullControl.All";
            case Scope.SitesSelected: return "Sites.Selected";
            case Scope.TasksRead: return "Tasks.Read";
            case Scope.TasksReadShared: return "Tasks.Read.Shared";
            case Scope.TasksReadWrite: return "Tasks.ReadWrite";
            case Scope.TasksReadWriteShared: return "Tasks.ReadWrite.Shared";
            case Scope.TasksReadAll: return "Tasks.Read.All";
            case Scope.TasksReadWriteAll: return "Tasks.ReadWrite.All";
            case Scope.TermStoreReadAll: return "TermStore.Read.All";
            case Scope.TermStoreReadWriteAll: return "TermStore.ReadWrite.All";
            case Scope.TeamReadBasicAll: return "Team.ReadBasic.All";
            case Scope.TeamCreate: return "Team.Create";
            case Scope.TeamTemplatesRead: return "TeamTemplates.Read";
            case Scope.TeamTemplatesReadAll: return "TeamTemplates.Read.All";
            case Scope.TeamSettingsReadAll: return "TeamSettings.Read.All";
            case Scope.TeamSettingsReadWriteAll: return "TeamSettings.ReadWrite.All";
            case Scope.TeamsActivityRead: return "TeamsActivity.Read";
            case Scope.TeamsActivitySend: return "TeamsActivity.Send";
            case Scope.TeamsActivityReadAll: return "TeamsActivity.Read.All";
            case Scope.TeamsAppReadAll: return "TeamsApp.Read.All";
            case Scope.TeamsAppReadWriteAll: return "TeamsApp.ReadWrite.All";
            case Scope.TeamsAppInstallationReadForUser: return "TeamsAppInstallation.ReadForUser";
            case Scope.TeamsAppInstallationReadWriteForUser: return "TeamsAppInstallation.ReadWriteForUser";
            case Scope.TeamsAppInstallationReadWriteSelfForUser: return "TeamsAppInstallation.ReadWriteSelfForUser";
            case Scope.TeamsAppInstallationReadForTeam: return "TeamsAppInstallation.ReadForTeam";
            case Scope.TeamsAppInstallationReadWriteForTeam: return "TeamsAppInstallation.ReadWriteForTeam";
            case Scope.TeamsAppInstallationReadWriteSelfForTeam: return "TeamsAppInstallation.ReadWriteSelfForTeam";
            case Scope.TeamsAppInstallationReadWriteAndConsentForChat: return "TeamsAppInstallation.ReadWriteAndConsentForChat";
            case Scope.TeamsAppInstallationReadWriteAndConsentForTeam: return "TeamsAppInstallation.ReadWriteAndConsentForTeam";
            case Scope.TeamsAppInstallationReadWriteAndConsentSelfForChat: return "TeamsAppInstallation.ReadWriteAndConsentSelfForChat";
            case Scope.TeamsAppInstallationReadWriteAndConsentSelfForTeam: return "TeamsAppInstallation.ReadWriteAndConsentSelfForTeam";
            case Scope.TeamsAppInstallationReadForUserAll: return "TeamsAppInstallation.ReadForUser.All";
            case Scope.TeamsAppInstallationReadWriteForUserAll: return "TeamsAppInstallation.ReadWriteForUser.All";
            case Scope.TeamsAppInstallationReadWriteSelfForUserAll: return "TeamsAppInstallation.ReadWriteSelfForUser.All";
            case Scope.TeamsAppInstallationReadForTeamAll: return "TeamsAppInstallation.ReadForTeam.All";
            case Scope.TeamsAppInstallationReadWriteForTeamAll: return "TeamsAppInstallation.ReadWriteForTeam.All";
            case Scope.TeamsAppInstallationReadWriteSelfForTeamAll: return "TeamsAppInstallation.ReadWriteSelfForTeam.All";
            case Scope.TeamsAppInstallationReadWriteAndConsentForChatAll: return "TeamsAppInstallation.ReadWriteAndConsentForChat.All";
            case Scope.TeamsAppInstallationReadWriteAndConsentForTeamAll: return "TeamsAppInstallation.ReadWriteAndConsentForTeam.All";
            case Scope.TeamsAppInstallationReadWriteAndConsentSelfForChatAll: return "TeamsAppInstallation.ReadWriteAndConsentSelfForChat.All";
            case Scope.TeamsAppInstallationReadWriteAndConsentSelfForTeamAll: return "TeamsAppInstallation.ReadWriteAndConsentSelfForTeam.All";
            case Scope.TeamworkAppSettingsReadAll: return "TeamworkAppSettings.Read.All";
            case Scope.TeamworkAppSettingsReadWriteAll: return "TeamworkAppSettings.ReadWrite.All";
            case Scope.TeamworkDeviceReadAll: return "TeamworkDevice.Read.All";
            case Scope.TeamworkDeviceReadWriteAll: return "TeamworkDevice.ReadWrite.All";
            case Scope.TeamMemberReadAll: return "TeamMember.Read.All";
            case Scope.TeamMemberReadWriteAll: return "TeamMember.ReadWrite.All";
            case Scope.TeamSettingsReadGroup: return "TeamSettings.Read.Group";
            case Scope.TeamSettingsReadWriteGroup: return "TeamSettings.ReadWrite.Group";
            case Scope.ChannelSettingsReadGroup: return "ChannelSettings.Read.Group";
            case Scope.ChannelSettingsReadWriteGroup: return "ChannelSettings.ReadWrite.Group";
            case Scope.ChannelCreateGroup: return "Channel.Create.Group";
            case Scope.ChannelDeleteGroup: return "Channel.Delete.Group";
            case Scope.ChannelMessageReadGroup: return "ChannelMessage.Read.Group";
            case Scope.TeamsAppInstallationReadGroup: return "TeamsAppInstallation.Read.Group";
            case Scope.TeamsTabReadGroup: return "TeamsTab.Read.Group";
            case Scope.TeamsTabCreateGroup: return "TeamsTab.Create.Group";
            case Scope.TeamsTabReadWriteGroup: return "TeamsTab.ReadWrite.Group";
            case Scope.TeamsTabDeleteGroup: return "TeamsTab.Delete.Group";
            case Scope.TeamMemberReadGroup: return "TeamMember.Read.Group";
            case Scope.MemberReadGroup: return "Member.Read.Group";
            case Scope.OwnerReadGroup: return "Owner.Read.Group";
            case Scope.FileReadGroup: return "File.Read.Group";
            case Scope.TeamsActivitySendGroup: return "TeamsActivity.Send.Group";
            case Scope.TeamsTabReadAll: return "TeamsTab.Read.All";
            case Scope.TeamsTabReadWriteAll: return "TeamsTab.ReadWrite.All";
            case Scope.TeamsTabCreate: return "TeamsTab.Create";
            case Scope.TeamsTabReadWriteSelfForChat: return "TeamsTab.ReadWriteSelfForChat";
            case Scope.TeamsTabReadWriteSelfForTeam: return "TeamsTab.ReadWriteSelfForTeam";
            case Scope.TeamsTabReadWriteSelfForUser: return "TeamsTab.ReadWriteSelfForUser";
            case Scope.TeamsTabReadWriteSelfForChatAll: return "TeamsTab.ReadWriteSelfForChat.All";
            case Scope.TeamsTabReadWriteSelfForTeamAll: return "TeamsTab.ReadWriteSelfForTeam.All";
            case Scope.TeamsTabReadWriteSelfForUserAll: return "TeamsTab.ReadWriteSelfForUser.All";
            case Scope.TeamworkTagReadWrite: return "TeamworkTag.ReadWrite";
            case Scope.TeamworkTagRead: return "TeamworkTag.Read";
            case Scope.TeamworkTagReadWriteAll: return "TeamworkTag.ReadWrite.All";
            case Scope.TeamworkTagReadAll: return "TeamworkTag.Read.All";
            case Scope.CrossTenantInformationReadBasicAll: return "CrossTenantInformation.ReadBasic.All";
            case Scope.AgreementReadAll: return "Agreement.Read.All";
            case Scope.AgreementReadWriteAll: return "Agreement.ReadWrite.All";
            case Scope.AgreementAcceptanceRead: return "AgreementAcceptance.Read";
            case Scope.AgreementAcceptanceReadAll: return "AgreementAcceptance.Read.All";
            case Scope.ThreatAssessmentReadWriteAll: return "ThreatAssessment.ReadWrite.All";
            case Scope.ThreatAssessmentReadAll: return "ThreatAssessment.Read.All";
            case Scope.ThreatHuntingReadAll: return "ThreatHunting.Read.All";
            case Scope.ThreatIntelligenceReadAll: return "ThreatIntelligence.Read.All";
            case Scope.PrinterCreate: return "Printer.Create";
            case Scope.PrinterFullControlAll: return "Printer.FullControl.All";
            case Scope.PrinterReadAll: return "Printer.Read.All";
            case Scope.PrinterReadWriteAll: return "Printer.ReadWrite.All";
            case Scope.PrinterShareReadBasicAll: return "PrinterShare.ReadBasic.All";
            case Scope.PrinterShareReadAll: return "PrinterShare.Read.All";
            case Scope.PrinterShareReadWriteAll: return "PrinterShare.ReadWrite.All";
            case Scope.PrintJobCreate: return "PrintJob.Create";
            case Scope.PrintJobRead: return "PrintJob.Read";
            case Scope.PrintJobReadAll: return "PrintJob.Read.All";
            case Scope.PrintJobReadBasic: return "PrintJob.ReadBasic";
            case Scope.PrintJobReadBasicAll: return "PrintJob.ReadBasic.All";
            case Scope.PrintJobReadWrite: return "PrintJob.ReadWrite";
            case Scope.PrintJobReadWriteAll: return "PrintJob.ReadWrite.All";
            case Scope.PrintJobReadWriteBasic: return "PrintJob.ReadWriteBasic";
            case Scope.PrintJobReadWriteBasicAll: return "PrintJob.ReadWriteBasic.All";
            case Scope.PrintConnectorReadAll: return "PrintConnector.Read.All";
            case Scope.PrintConnectorReadWriteAll: return "PrintConnector.ReadWrite.All";
            case Scope.PrintSettingsReadAll: return "PrintSettings.Read.All";
            case Scope.PrintSettingsReadWriteAll: return "PrintSettings.ReadWrite.All";
            case Scope.PrintJobManageAll: return "PrintJob.Manage.All";
            case Scope.PrintTaskDefinitionReadWriteAll: return "PrintTaskDefinition.ReadWrite.All";
            case Scope.UserRead: return "User.Read";
            case Scope.UserReadWrite: return "User.ReadWrite";
            case Scope.UserReadBasicAll: return "User.ReadBasic.All";
            case Scope.UserReadAll: return "User.Read.All";
            case Scope.UserReadWriteAll: return "User.ReadWrite.All";
            case Scope.UserInviteAll: return "User.Invite.All";
            case Scope.UserEnableDisableAccountAll: return "User.EnableDisableAccount.All";
            case Scope.UserExportAll: return "User.Export.All";
            case Scope.UserManageIdentitiesAll: return "User.ManageIdentities.All";
            case Scope.UserLifeCycleInfoReadAll: return "User-LifeCycleInfo.Read.All";
            case Scope.UserLifeCycleInfoReadWriteAll: return "User-LifeCycleInfo.ReadWrite.All";
            case Scope.UserActivityReadWriteCreatedByApp: return "UserActivity.ReadWrite.CreatedByApp";
            case Scope.UserAuthenticationMethodRead: return "UserAuthenticationMethod.Read";
            case Scope.UserAuthenticationMethodReadAll: return "UserAuthenticationMethod.Read.All";
            case Scope.UserAuthenticationMethodReadWrite: return "UserAuthenticationMethod.ReadWrite";
            case Scope.UserAuthenticationMethodReadWriteAll: return "UserAuthenticationMethod.ReadWrite.All";
            case Scope.WindowsUpdatesReadWriteAll: return "WindowsUpdates.ReadWrite.All";
            default: throw new SwitchStatementNotImplementException<Scope>(value);
        }
    }
}
