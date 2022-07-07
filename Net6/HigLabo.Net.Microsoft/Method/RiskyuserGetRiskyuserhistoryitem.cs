using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class RiskyuserGetRiskyuserhistoryitemParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityProtection_RiskyUsers_UserId_History,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityProtection_RiskyUsers_UserId_History: return $"/identityProtection/riskyUsers/{UserId}/history";
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
        public string UserId { get; set; }
    }
    public partial class RiskyuserGetRiskyuserhistoryitemResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-get-riskyuserhistoryitem?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyuserGetRiskyuserhistoryitemResponse> RiskyuserGetRiskyuserhistoryitemAsync()
        {
            var p = new RiskyuserGetRiskyuserhistoryitemParameter();
            return await this.SendAsync<RiskyuserGetRiskyuserhistoryitemParameter, RiskyuserGetRiskyuserhistoryitemResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-get-riskyuserhistoryitem?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyuserGetRiskyuserhistoryitemResponse> RiskyuserGetRiskyuserhistoryitemAsync(CancellationToken cancellationToken)
        {
            var p = new RiskyuserGetRiskyuserhistoryitemParameter();
            return await this.SendAsync<RiskyuserGetRiskyuserhistoryitemParameter, RiskyuserGetRiskyuserhistoryitemResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-get-riskyuserhistoryitem?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyuserGetRiskyuserhistoryitemResponse> RiskyuserGetRiskyuserhistoryitemAsync(RiskyuserGetRiskyuserhistoryitemParameter parameter)
        {
            return await this.SendAsync<RiskyuserGetRiskyuserhistoryitemParameter, RiskyuserGetRiskyuserhistoryitemResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-get-riskyuserhistoryitem?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyuserGetRiskyuserhistoryitemResponse> RiskyuserGetRiskyuserhistoryitemAsync(RiskyuserGetRiskyuserhistoryitemParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RiskyuserGetRiskyuserhistoryitemParameter, RiskyuserGetRiskyuserhistoryitemResponse>(parameter, cancellationToken);
        }
    }
}
