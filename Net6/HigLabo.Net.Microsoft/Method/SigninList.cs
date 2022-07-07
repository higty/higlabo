using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SigninListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            UditLogs_SignIns,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.UditLogs_SignIns: return $"/uditLogs/signIns";
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
    public partial class SigninListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/signin?view=graph-rest-1.0
        /// </summary>
        public partial class SignIn
        {
            public enum SignInConditionalAccessStatus
            {
                Success,
                Failure,
                NotApplied,
                UnknownFutureValue,
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
            }
            public enum SignInString
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
            }
            public enum SignInRiskLevel
            {
                None,
                Low,
                Medium,
                High,
                Hidden,
                UnknownFutureValue,
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
            }

            public string? AppDisplayName { get; set; }
            public string? AppId { get; set; }
            public AppliedConditionalAccessPolicy[]? AppliedConditionalAccessPolicy { get; set; }
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
            public SignInString RiskEventTypes_v2 { get; set; }
            public SignInRiskLevel RiskLevelAggregated { get; set; }
            public SignInRiskLevel RiskLevelDuringSignIn { get; set; }
            public SignInRiskState RiskState { get; set; }
            public SignInStatus? Status { get; set; }
            public string? UserDisplayName { get; set; }
            public string? UserId { get; set; }
            public string? UserPrincipalName { get; set; }
        }

        public SignIn[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/signin-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SigninListResponse> SigninListAsync()
        {
            var p = new SigninListParameter();
            return await this.SendAsync<SigninListParameter, SigninListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/signin-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SigninListResponse> SigninListAsync(CancellationToken cancellationToken)
        {
            var p = new SigninListParameter();
            return await this.SendAsync<SigninListParameter, SigninListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/signin-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SigninListResponse> SigninListAsync(SigninListParameter parameter)
        {
            return await this.SendAsync<SigninListParameter, SigninListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/signin-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SigninListResponse> SigninListAsync(SigninListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SigninListParameter, SigninListResponse>(parameter, cancellationToken);
        }
    }
}
