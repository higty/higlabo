using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Groups,
            Ttps__Graphmicrosoftcom_V10_Groups,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups: return $"/groups";
                    case ApiPath.Ttps__Graphmicrosoftcom_V10_Groups: return $"/ttps://graph.microsoft.com/v1.0/groups";
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
    }
    public partial class GroupListResponse : RestApiResponse
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
        }

        public Group[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListResponse> GroupListAsync()
        {
            var p = new GroupListParameter();
            return await this.SendAsync<GroupListParameter, GroupListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListResponse> GroupListAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListParameter();
            return await this.SendAsync<GroupListParameter, GroupListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListResponse> GroupListAsync(GroupListParameter parameter)
        {
            return await this.SendAsync<GroupListParameter, GroupListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListResponse> GroupListAsync(GroupListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListParameter, GroupListResponse>(parameter, cancellationToken);
        }
    }
}
