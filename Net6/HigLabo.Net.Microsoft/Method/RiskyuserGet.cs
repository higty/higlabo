using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class RiskyUserGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string RiskyUserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityProtection_RiskyUsers_RiskyUserId: return $"/identityProtection/riskyUsers/{RiskyUserId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            IsDeleted,
            IsProcessing,
            RiskDetail,
            RiskLastUpdatedDateTime,
            RiskLevel,
            RiskState,
            UserDisplayName,
            UserPrincipalName,
            History,
        }
        public enum ApiPath
        {
            IdentityProtection_RiskyUsers_RiskyUserId,
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
    public partial class RiskyUserGetResponse : RestApiResponse
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
        public RiskyUserHistoryItem[]? History { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-get?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyUserGetResponse> RiskyUserGetAsync()
        {
            var p = new RiskyUserGetParameter();
            return await this.SendAsync<RiskyUserGetParameter, RiskyUserGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-get?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyUserGetResponse> RiskyUserGetAsync(CancellationToken cancellationToken)
        {
            var p = new RiskyUserGetParameter();
            return await this.SendAsync<RiskyUserGetParameter, RiskyUserGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-get?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyUserGetResponse> RiskyUserGetAsync(RiskyUserGetParameter parameter)
        {
            return await this.SendAsync<RiskyUserGetParameter, RiskyUserGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-get?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyUserGetResponse> RiskyUserGetAsync(RiskyUserGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RiskyUserGetParameter, RiskyUserGetResponse>(parameter, cancellationToken);
        }
    }
}
