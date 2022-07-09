using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/group?view=graph-rest-1.0
    /// </summary>
    public partial class Group
    {
        public enum GroupString
        {
            AllowOnlyMembersToPost,
            HideGroupInOutlook,
            SubscribeNewGroupMembers,
            WelcomeEmailDisabled,
        }
        public enum Groupstring
        {
            Teal,
            Purple,
            Green,
            Blue,
            Pink,
            Orange,
            Red,
        }

        public bool? AllowExternalSenders { get; set; }
        public AssignedLabel[]? AssignedLabels { get; set; }
        public AssignedLicense[]? AssignedLicenses { get; set; }
        public bool? AutoSubscribeNewMembers { get; set; }
        public string? Classification { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? DeletedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public DateTimeOffset? ExpirationDateTime { get; set; }
        public String[]? GroupTypes { get; set; }
        public bool? HasMembersWithLicenseErrors { get; set; }
        public bool? HideFromAddressLists { get; set; }
        public bool? HideFromOutlookClients { get; set; }
        public string? Id { get; set; }
        public bool? IsArchived { get; set; }
        public bool? IsAssignableToRole { get; set; }
        public bool? IsSubscribedByMail { get; set; }
        public string? LicenseProcessingState { get; set; }
        public string? Mail { get; set; }
        public bool? MailEnabled { get; set; }
        public string? MailNickname { get; set; }
        public string? MembershipRule { get; set; }
        public string? MembershipRuleProcessingState { get; set; }
        public DateTimeOffset? OnPremisesLastSyncDateTime { get; set; }
        public OnPremisesProvisioningError[]? OnPremisesProvisioningErrors { get; set; }
        public string? OnPremisesSamAccountName { get; set; }
        public string? OnPremisesSecurityIdentifier { get; set; }
        public bool? OnPremisesSyncEnabled { get; set; }
        public string? PreferredDataLocation { get; set; }
        public string? PreferredLanguage { get; set; }
        public String[]? ProxyAddresses { get; set; }
        public DateTimeOffset? RenewedDateTime { get; set; }
        public GroupString ResourceBehaviorOptions { get; set; }
        public String[]? ResourceProvisioningOptions { get; set; }
        public bool? SecurityEnabled { get; set; }
        public string? SecurityIdentifier { get; set; }
        public Groupstring Theme { get; set; }
        public Int32? UnseenCount { get; set; }
        public string? Visibility { get; set; }
        public DirectoryObject[]? AcceptedSenders { get; set; }
        public AppRoleAssignment[]? AppRoleAssignments { get; set; }
        public Calendar? Calendar { get; set; }
        public Event[]? CalendarView { get; set; }
        public Conversation[]? Conversations { get; set; }
        public DirectoryObject? CreatedOnBehalfOf { get; set; }
        public Drive? Drive { get; set; }
        public Drive[]? Drives { get; set; }
        public Event[]? Events { get; set; }
        public Extension[]? Extensions { get; set; }
        public GroupLifecyclePolicy[]? GroupLifecyclePolicies { get; set; }
        public DirectoryObject[]? MemberOf { get; set; }
        public DirectoryObject[]? Members { get; set; }
        public User[]? MembersWithLicenseErrors { get; set; }
        public Onenote? Onenote { get; set; }
        public DirectoryObject[]? Owners { get; set; }
        public ResourceSpecificPermissionGrant? PermissionGrants { get; set; }
        public ProfilePhoto? Photo { get; set; }
        public ProfilePhoto[]? Photos { get; set; }
        public PlannerGroup? Planner { get; set; }
        public DirectoryObject[]? RejectedSenders { get; set; }
        public GroupSetting[]? Settings { get; set; }
        public Site[]? Sites { get; set; }
        public Channel[]? Team { get; set; }
        public ConversationThread[]? Threads { get; set; }
    }
}
