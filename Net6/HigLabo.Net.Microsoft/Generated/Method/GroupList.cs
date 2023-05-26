using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list?view=graph-rest-1.0
    /// </summary>
    public partial class GroupListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups: return $"/groups";
                    case ApiPath.Ttps__Graphmicrosoftcom_V10_Groups: return $"/ttps://graph.microsoft.com/v1.0/groups";
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
            Groups,
            Ttps__Graphmicrosoftcom_V10_Groups,
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
    public partial class GroupListResponse : RestApiResponse
    {
        public Group[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListResponse> GroupListAsync()
        {
            var p = new GroupListParameter();
            return await this.SendAsync<GroupListParameter, GroupListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListResponse> GroupListAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListParameter();
            return await this.SendAsync<GroupListParameter, GroupListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListResponse> GroupListAsync(GroupListParameter parameter)
        {
            return await this.SendAsync<GroupListParameter, GroupListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListResponse> GroupListAsync(GroupListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListParameter, GroupListResponse>(parameter, cancellationToken);
        }
    }
}
