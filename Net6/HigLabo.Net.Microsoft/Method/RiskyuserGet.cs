using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class RiskyuserGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityProtection_RiskyUsers_RiskyUserId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityProtection_RiskyUsers_RiskyUserId: return $"/identityProtection/riskyUsers/{RiskyUserId}";
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
    }
    public partial class RiskyuserGetResponse : RestApiResponse
    {
        public enum RiskyUserRiskDetail
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
        public enum RiskyUserRiskLevel
        {
            Low,
            Medium,
            High,
            Hidden,
            None,
            UnknownFutureValue,
        }
        public enum RiskyUserRiskState
        {
            None,
            ConfirmedSafe,
            Remediated,
            Dismissed,
            AtRisk,
            ConfirmedCompromised,
            UnknownFutureValue,
        }

        public string? Id { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsProcessing { get; set; }
        public RiskyUserRiskDetail RiskDetail { get; set; }
        public DateTimeOffset? RiskLastUpdatedDateTime { get; set; }
        public RiskyUserRiskLevel RiskLevel { get; set; }
        public RiskyUserRiskState RiskState { get; set; }
        public string? UserDisplayName { get; set; }
        public string? UserPrincipalName { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-get?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyuserGetResponse> RiskyuserGetAsync()
        {
            var p = new RiskyuserGetParameter();
            return await this.SendAsync<RiskyuserGetParameter, RiskyuserGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-get?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyuserGetResponse> RiskyuserGetAsync(CancellationToken cancellationToken)
        {
            var p = new RiskyuserGetParameter();
            return await this.SendAsync<RiskyuserGetParameter, RiskyuserGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-get?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyuserGetResponse> RiskyuserGetAsync(RiskyuserGetParameter parameter)
        {
            return await this.SendAsync<RiskyuserGetParameter, RiskyuserGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-get?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyuserGetResponse> RiskyuserGetAsync(RiskyuserGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RiskyuserGetParameter, RiskyuserGetResponse>(parameter, cancellationToken);
        }
    }
}
