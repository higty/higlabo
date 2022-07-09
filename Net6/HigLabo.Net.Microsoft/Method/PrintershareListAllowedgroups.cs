using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintershareListAllowedGroupsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PrinterShareId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Shares_PrinterShareId_AllowedGroups: return $"/print/shares/{PrinterShareId}/allowedGroups";
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
            Print_Shares_PrinterShareId_AllowedGroups,
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
    public partial class PrintershareListAllowedGroupsResponse : RestApiResponse
    {
        public Group[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-list-allowedgroups?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareListAllowedGroupsResponse> PrintershareListAllowedGroupsAsync()
        {
            var p = new PrintershareListAllowedGroupsParameter();
            return await this.SendAsync<PrintershareListAllowedGroupsParameter, PrintershareListAllowedGroupsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-list-allowedgroups?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareListAllowedGroupsResponse> PrintershareListAllowedGroupsAsync(CancellationToken cancellationToken)
        {
            var p = new PrintershareListAllowedGroupsParameter();
            return await this.SendAsync<PrintershareListAllowedGroupsParameter, PrintershareListAllowedGroupsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-list-allowedgroups?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareListAllowedGroupsResponse> PrintershareListAllowedGroupsAsync(PrintershareListAllowedGroupsParameter parameter)
        {
            return await this.SendAsync<PrintershareListAllowedGroupsParameter, PrintershareListAllowedGroupsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-list-allowedgroups?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareListAllowedGroupsResponse> PrintershareListAllowedGroupsAsync(PrintershareListAllowedGroupsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintershareListAllowedGroupsParameter, PrintershareListAllowedGroupsResponse>(parameter, cancellationToken);
        }
    }
}
