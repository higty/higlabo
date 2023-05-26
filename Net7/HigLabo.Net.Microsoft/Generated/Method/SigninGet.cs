using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/signin-get?view=graph-rest-1.0
    /// </summary>
    public partial class SigninGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.AuditLogs_SignIns_Id: return $"/auditLogs/signIns/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            AuditLogs_SignIns_Id,
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
    public partial class SigninGetResponse : RestApiResponse
    {
        public enum SignInConditionalAccessStatus
        {
            Success,
            Failure,
            NotApplied,
            UnknownFutureValue,
            Eq,
        }
        public enum SignInRiskDetail
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
            UnknownFutureValue,
            Eq,
            Hidden,
        }
        public enum SignInRiskEventType
        {
            UnlikelyTravel,
            AnonymizedIPAddress,
            MaliciousIPAddress,
            UnfamiliarFeatures,
            MalwareInfectedIPAddress,
            SuspiciousIPAddress,
            LeakedCredentials,
            InvestigationsThreatIntelligence,
            Generic,
            UnknownFutureValue,
            Eq,
        }
        public enum SignInRiskLevel
        {
            None,
            Low,
            Medium,
            High,
            Hidden,
            UnknownFutureValue,
            Eq,
        }
        public enum SignInRiskState
        {
            None,
            ConfirmedSafe,
            Remediated,
            Dismissed,
            AtRisk,
            ConfirmedCompromised,
            UnknownFutureValue,
            Eq,
        }

        public string? AppDisplayName { get; set; }
        public string? AppId { get; set; }
        public AppliedConditionalAccessPolicy[]? AppliedConditionalAccessPolicies { get; set; }
        public string? ClientAppUsed { get; set; }
        public SignInConditionalAccessStatus ConditionalAccessStatus { get; set; }
        public string? CorrelationId { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DeviceDetail? DeviceDetail { get; set; }
        public string? Id { get; set; }
        public string? IpAddress { get; set; }
        public bool? IsInteractive { get; set; }
        public SignInLocation? Location { get; set; }
        public string? ResourceDisplayName { get; set; }
        public string? ResourceId { get; set; }
        public SignInRiskDetail RiskDetail { get; set; }
        public SignInRiskEventType RiskEventTypes { get; set; }
        public String[]? RiskEventTypes_v2 { get; set; }
        public SignInRiskLevel RiskLevelAggregated { get; set; }
        public SignInRiskLevel RiskLevelDuringSignIn { get; set; }
        public SignInRiskState RiskState { get; set; }
        public SignInStatus? Status { get; set; }
        public string? UserDisplayName { get; set; }
        public string? UserId { get; set; }
        public string? UserPrincipalName { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/signin-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/signin-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SigninGetResponse> SigninGetAsync()
        {
            var p = new SigninGetParameter();
            return await this.SendAsync<SigninGetParameter, SigninGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/signin-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SigninGetResponse> SigninGetAsync(CancellationToken cancellationToken)
        {
            var p = new SigninGetParameter();
            return await this.SendAsync<SigninGetParameter, SigninGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/signin-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SigninGetResponse> SigninGetAsync(SigninGetParameter parameter)
        {
            return await this.SendAsync<SigninGetParameter, SigninGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/signin-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SigninGetResponse> SigninGetAsync(SigninGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SigninGetParameter, SigninGetResponse>(parameter, cancellationToken);
        }
    }
}
