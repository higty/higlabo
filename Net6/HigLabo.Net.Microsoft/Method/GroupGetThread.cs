using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-get-thread?view=graph-rest-1.0
    /// </summary>
    public partial class GroupGetThreadParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? GroupsId { get; set; }
            public string? ThreadsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_Threads_Id: return $"/groups/{GroupsId}/threads/{ThreadsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AllowExternalSenders,
            AssignedLabels,
            AssignedLicenses,
            AutoSubscribeNewMembers,
            Classification,
            CreatedDateTime,
            DeletedDateTime,
            Description,
            DisplayName,
            ExpirationDateTime,
            GroupTypes,
            HasMembersWithLicenseErrors,
            HideFromAddressLists,
            HideFromOutlookClients,
            Id,
            IsArchived,
            IsAssignableToRole,
            IsSubscribedByMail,
            LicenseProcessingState,
            Mail,
            MailEnabled,
            MailNickname,
            MembershipRule,
            MembershipRuleProcessingState,
            OnPremisesLastSyncDateTime,
            OnPremisesProvisioningErrors,
            OnPremisesSamAccountName,
            OnPremisesSecurityIdentifier,
            OnPremisesSyncEnabled,
            PreferredDataLocation,
            PreferredLanguage,
            ProxyAddresses,
            RenewedDateTime,
            ResourceBehaviorOptions,
            ResourceProvisioningOptions,
            SecurityEnabled,
            SecurityIdentifier,
            Theme,
            UnseenCount,
            Visibility,
            AcceptedSenders,
            AppRoleAssignments,
            Calendar,
            CalendarView,
            Conversations,
            CreatedOnBehalfOf,
            Drive,
            Drives,
            Events,
            Extensions,
            GroupLifecyclePolicies,
            MemberOf,
            Members,
            MembersWithLicenseErrors,
            Onenote,
            Owners,
            PermissionGrants,
            Photo,
            Photos,
            Planner,
            RejectedSenders,
            Settings,
            Sites,
            Team,
            Threads,
            TransitiveMemberOf,
            TransitiveMembers,
        }
        public enum ApiPath
        {
            Groups_Id_Threads_Id,
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
    public partial class GroupGetThreadResponse : RestApiResponse
    {
        public Recipient[]? CcRecipients { get; set; }
        public bool? HasAttachments { get; set; }
        public string? Id { get; set; }
        public bool? IsLocked { get; set; }
        public DateTimeOffset? LastDeliveredDateTime { get; set; }
        public string? Preview { get; set; }
        public string? Topic { get; set; }
        public Recipient[]? ToRecipients { get; set; }
        public String[]? UniqueSenders { get; set; }
        public Post[]? Posts { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-get-thread?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-get-thread?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupGetThreadResponse> GroupGetThreadAsync()
        {
            var p = new GroupGetThreadParameter();
            return await this.SendAsync<GroupGetThreadParameter, GroupGetThreadResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-get-thread?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupGetThreadResponse> GroupGetThreadAsync(CancellationToken cancellationToken)
        {
            var p = new GroupGetThreadParameter();
            return await this.SendAsync<GroupGetThreadParameter, GroupGetThreadResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-get-thread?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupGetThreadResponse> GroupGetThreadAsync(GroupGetThreadParameter parameter)
        {
            return await this.SendAsync<GroupGetThreadParameter, GroupGetThreadResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-get-thread?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupGetThreadResponse> GroupGetThreadAsync(GroupGetThreadParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupGetThreadParameter, GroupGetThreadResponse>(parameter, cancellationToken);
        }
    }
}
