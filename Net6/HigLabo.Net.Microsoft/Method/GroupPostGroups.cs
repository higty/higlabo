using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupPostGroupsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Groups,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups: return $"/groups";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public bool? MailEnabled { get; set; }
        public string? MailNickname { get; set; }
        public bool? SecurityEnabled { get; set; }
    }
    public partial class GroupPostGroupsResponse : RestApiResponse
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
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-groups?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostGroupsResponse> GroupPostGroupsAsync()
        {
            var p = new GroupPostGroupsParameter();
            return await this.SendAsync<GroupPostGroupsParameter, GroupPostGroupsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-groups?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostGroupsResponse> GroupPostGroupsAsync(CancellationToken cancellationToken)
        {
            var p = new GroupPostGroupsParameter();
            return await this.SendAsync<GroupPostGroupsParameter, GroupPostGroupsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-groups?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostGroupsResponse> GroupPostGroupsAsync(GroupPostGroupsParameter parameter)
        {
            return await this.SendAsync<GroupPostGroupsParameter, GroupPostGroupsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-groups?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostGroupsResponse> GroupPostGroupsAsync(GroupPostGroupsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupPostGroupsParameter, GroupPostGroupsResponse>(parameter, cancellationToken);
        }
    }
}
