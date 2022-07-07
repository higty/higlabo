using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupGetThreadParameter : IRestApiParameter, IQueryParameterProperty
    {
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
        }
        public enum ApiPath
        {
            Groups_Id_Threads_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_Threads_Id: return $"/groups/{GroupsId}/threads/{ThreadsId}";
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
        public string GroupsId { get; set; }
        public string ThreadsId { get; set; }
    }
    public partial class GroupGetThreadResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public Recipient[]? ToRecipients { get; set; }
        public Recipient[]? CcRecipients { get; set; }
        public string? Topic { get; set; }
        public bool? HasAttachments { get; set; }
        public DateTimeOffset? LastDeliveredDateTime { get; set; }
        public String[]? UniqueSenders { get; set; }
        public string? Preview { get; set; }
        public bool? IsLocked { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-get-thread?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupGetThreadResponse> GroupGetThreadAsync()
        {
            var p = new GroupGetThreadParameter();
            return await this.SendAsync<GroupGetThreadParameter, GroupGetThreadResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-get-thread?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupGetThreadResponse> GroupGetThreadAsync(CancellationToken cancellationToken)
        {
            var p = new GroupGetThreadParameter();
            return await this.SendAsync<GroupGetThreadParameter, GroupGetThreadResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-get-thread?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupGetThreadResponse> GroupGetThreadAsync(GroupGetThreadParameter parameter)
        {
            return await this.SendAsync<GroupGetThreadParameter, GroupGetThreadResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-get-thread?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupGetThreadResponse> GroupGetThreadAsync(GroupGetThreadParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupGetThreadParameter, GroupGetThreadResponse>(parameter, cancellationToken);
        }
    }
}
