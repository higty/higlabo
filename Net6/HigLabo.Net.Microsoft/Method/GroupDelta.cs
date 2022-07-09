using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Delta: return $"/groups/delta";
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
        }
        public enum ApiPath
        {
            Groups_Delta,
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
    public partial class GroupDeltaResponse : RestApiResponse
    {
        public Group[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeltaResponse> GroupDeltaAsync()
        {
            var p = new GroupDeltaParameter();
            return await this.SendAsync<GroupDeltaParameter, GroupDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeltaResponse> GroupDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new GroupDeltaParameter();
            return await this.SendAsync<GroupDeltaParameter, GroupDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeltaResponse> GroupDeltaAsync(GroupDeltaParameter parameter)
        {
            return await this.SendAsync<GroupDeltaParameter, GroupDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeltaResponse> GroupDeltaAsync(GroupDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupDeltaParameter, GroupDeltaResponse>(parameter, cancellationToken);
        }
    }
}
