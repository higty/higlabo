using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupGetConversationParameter : IRestApiParameter, IQueryParameterProperty
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
            Groups_Id_Conversations_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_Conversations_Id: return $"/groups/{GroupsId}/conversations/{ConversationsId}";
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
        public string ConversationsId { get; set; }
    }
    public partial class GroupGetConversationResponse : RestApiResponse
    {
        public bool? HasAttachments { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastDeliveredDateTime { get; set; }
        public string? Preview { get; set; }
        public string? Topic { get; set; }
        public String[]? UniqueSenders { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-get-conversation?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupGetConversationResponse> GroupGetConversationAsync()
        {
            var p = new GroupGetConversationParameter();
            return await this.SendAsync<GroupGetConversationParameter, GroupGetConversationResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-get-conversation?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupGetConversationResponse> GroupGetConversationAsync(CancellationToken cancellationToken)
        {
            var p = new GroupGetConversationParameter();
            return await this.SendAsync<GroupGetConversationParameter, GroupGetConversationResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-get-conversation?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupGetConversationResponse> GroupGetConversationAsync(GroupGetConversationParameter parameter)
        {
            return await this.SendAsync<GroupGetConversationParameter, GroupGetConversationResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-get-conversation?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupGetConversationResponse> GroupGetConversationAsync(GroupGetConversationParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupGetConversationParameter, GroupGetConversationResponse>(parameter, cancellationToken);
        }
    }
}
