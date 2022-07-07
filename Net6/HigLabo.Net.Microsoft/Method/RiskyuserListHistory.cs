using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class RiskyuserListHistoryParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityProtection_RiskyUsers_RiskyUserId_History,
            IdentityProtection_RiskyUsers_RiskyUserId_History_RiskyUserHistoryItemId_History,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityProtection_RiskyUsers_RiskyUserId_History: return $"/identityProtection/riskyUsers/{RiskyUserId}/history";
                    case ApiPath.IdentityProtection_RiskyUsers_RiskyUserId_History_RiskyUserHistoryItemId_History: return $"/identityProtection/riskyUsers/{RiskyUserId}/history/{RiskyUserHistoryItemId}/history";
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
        public string RiskyUserId { get; set; }
        public string RiskyUserHistoryItemId { get; set; }
    }
    public partial class RiskyuserListHistoryResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/riskyuserhistoryitem?view=graph-rest-1.0
        /// </summary>
        public partial class RiskyUserHistoryItem
        {
            public enum RiskyUserHistoryItemRiskDetail
            {
                None,
                AdminGeneratedTemporaryPassword,
                UserPerformedSecuredPasswordChange,
                UserPerformedSecuredPasswordReset,
                AdminConfirmedSigninSafe,
                AiConfirmedSigninSafe,
                UserPassedMFADrivenByRiskBasedPolicy,
                AdminDismissedAllRiskForUser,
                AdminConfirmedSigninCompromised,
                Hidden,
                AdminConfirmedUserCompromised,
                UnknownFutureValue,
            }
            public enum RiskyUserHistoryItemRiskLevel
            {
                Low,
                Medium,
                High,
                Hidden,
                None,
                UnknownFutureValue,
            }
            public enum RiskyUserHistoryItemRiskState
            {
                None,
                ConfirmedSafe,
                Remediated,
                Dismissed,
                AtRisk,
                ConfirmedCompromised,
                UnknownFutureValue,
            }

            public RiskUserActivity? Activity { get; set; }
            public string? Id { get; set; }
            public string? InitiatedBy { get; set; }
            public bool? IsDeleted { get; set; }
            public bool? IsProcessing { get; set; }
            public RiskyUserHistoryItemRiskDetail RiskDetail { get; set; }
            public DateTimeOffset? RiskLastUpdatedDateTime { get; set; }
            public RiskyUserHistoryItemRiskLevel RiskLevel { get; set; }
            public RiskyUserHistoryItemRiskState RiskState { get; set; }
            public string? UserDisplayName { get; set; }
            public string? UserId { get; set; }
            public string? UserPrincipalName { get; set; }
        }

        public RiskyUserHistoryItem[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-list-history?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyuserListHistoryResponse> RiskyuserListHistoryAsync()
        {
            var p = new RiskyuserListHistoryParameter();
            return await this.SendAsync<RiskyuserListHistoryParameter, RiskyuserListHistoryResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-list-history?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyuserListHistoryResponse> RiskyuserListHistoryAsync(CancellationToken cancellationToken)
        {
            var p = new RiskyuserListHistoryParameter();
            return await this.SendAsync<RiskyuserListHistoryParameter, RiskyuserListHistoryResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-list-history?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyuserListHistoryResponse> RiskyuserListHistoryAsync(RiskyuserListHistoryParameter parameter)
        {
            return await this.SendAsync<RiskyuserListHistoryParameter, RiskyuserListHistoryResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-list-history?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyuserListHistoryResponse> RiskyuserListHistoryAsync(RiskyuserListHistoryParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RiskyuserListHistoryParameter, RiskyuserListHistoryResponse>(parameter, cancellationToken);
        }
    }
}
