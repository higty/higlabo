using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class RiskyuserListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityProtection_RiskyUsers,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityProtection_RiskyUsers: return $"/identityProtection/riskyUsers";
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
    }
    public partial class RiskyuserListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/riskyuser?view=graph-rest-1.0
        /// </summary>
        public partial class RiskyUser
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

        public RiskyUser[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-list?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyuserListResponse> RiskyuserListAsync()
        {
            var p = new RiskyuserListParameter();
            return await this.SendAsync<RiskyuserListParameter, RiskyuserListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-list?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyuserListResponse> RiskyuserListAsync(CancellationToken cancellationToken)
        {
            var p = new RiskyuserListParameter();
            return await this.SendAsync<RiskyuserListParameter, RiskyuserListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-list?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyuserListResponse> RiskyuserListAsync(RiskyuserListParameter parameter)
        {
            return await this.SendAsync<RiskyuserListParameter, RiskyuserListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-list?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyuserListResponse> RiskyuserListAsync(RiskyuserListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RiskyuserListParameter, RiskyuserListResponse>(parameter, cancellationToken);
        }
    }
}
