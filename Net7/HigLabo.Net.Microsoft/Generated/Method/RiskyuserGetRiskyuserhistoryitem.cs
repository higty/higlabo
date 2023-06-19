using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskyuser-get-riskyuserhistoryitem?view=graph-rest-1.0
    /// </summary>
    public partial class RiskyUserGetRiskyUserhistoryitemParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityProtection_RiskyUsers_UserId_History: return $"/identityProtection/riskyUsers/{UserId}/history";
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
            IdentityProtection_RiskyUsers_UserId_History,
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
    public partial class RiskyUserGetRiskyUserhistoryitemResponse : RestApiResponse
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
        public RiskyUserHistoryItem[]? History { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskyuser-get-riskyuserhistoryitem?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyuser-get-riskyuserhistoryitem?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyUserGetRiskyUserhistoryitemResponse> RiskyUserGetRiskyUserhistoryitemAsync()
        {
            var p = new RiskyUserGetRiskyUserhistoryitemParameter();
            return await this.SendAsync<RiskyUserGetRiskyUserhistoryitemParameter, RiskyUserGetRiskyUserhistoryitemResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyuser-get-riskyuserhistoryitem?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyUserGetRiskyUserhistoryitemResponse> RiskyUserGetRiskyUserhistoryitemAsync(CancellationToken cancellationToken)
        {
            var p = new RiskyUserGetRiskyUserhistoryitemParameter();
            return await this.SendAsync<RiskyUserGetRiskyUserhistoryitemParameter, RiskyUserGetRiskyUserhistoryitemResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyuser-get-riskyuserhistoryitem?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyUserGetRiskyUserhistoryitemResponse> RiskyUserGetRiskyUserhistoryitemAsync(RiskyUserGetRiskyUserhistoryitemParameter parameter)
        {
            return await this.SendAsync<RiskyUserGetRiskyUserhistoryitemParameter, RiskyUserGetRiskyUserhistoryitemResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyuser-get-riskyuserhistoryitem?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyUserGetRiskyUserhistoryitemResponse> RiskyUserGetRiskyUserhistoryitemAsync(RiskyUserGetRiskyUserhistoryitemParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RiskyUserGetRiskyUserhistoryitemParameter, RiskyUserGetRiskyUserhistoryitemResponse>(parameter, cancellationToken);
        }
    }
}
