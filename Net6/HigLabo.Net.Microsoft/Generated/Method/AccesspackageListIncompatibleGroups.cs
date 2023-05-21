using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-incompatiblegroups?view=graph-rest-1.0
    /// </summary>
    public partial class AccesspackageListIncompatibleGroupsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AccessPackages_Id_IncompatibleGroups: return $"/identityGovernance/entitlementManagement/accessPackages/{Id}/incompatibleGroups";
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
            IdentityGovernance_EntitlementManagement_AccessPackages_Id_IncompatibleGroups,
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
    public partial class AccesspackageListIncompatibleGroupsResponse : RestApiResponse
    {
        public Group[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-incompatiblegroups?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-incompatiblegroups?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageListIncompatibleGroupsResponse> AccesspackageListIncompatibleGroupsAsync()
        {
            var p = new AccesspackageListIncompatibleGroupsParameter();
            return await this.SendAsync<AccesspackageListIncompatibleGroupsParameter, AccesspackageListIncompatibleGroupsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-incompatiblegroups?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageListIncompatibleGroupsResponse> AccesspackageListIncompatibleGroupsAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageListIncompatibleGroupsParameter();
            return await this.SendAsync<AccesspackageListIncompatibleGroupsParameter, AccesspackageListIncompatibleGroupsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-incompatiblegroups?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageListIncompatibleGroupsResponse> AccesspackageListIncompatibleGroupsAsync(AccesspackageListIncompatibleGroupsParameter parameter)
        {
            return await this.SendAsync<AccesspackageListIncompatibleGroupsParameter, AccesspackageListIncompatibleGroupsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-incompatiblegroups?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageListIncompatibleGroupsResponse> AccesspackageListIncompatibleGroupsAsync(AccesspackageListIncompatibleGroupsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageListIncompatibleGroupsParameter, AccesspackageListIncompatibleGroupsResponse>(parameter, cancellationToken);
        }
    }
}
