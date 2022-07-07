using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class RiskdetectionListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityProtection_RiskDetections,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityProtection_RiskDetections: return $"/identityProtection/riskDetections";
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
    public partial class RiskdetectionListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/riskdetection?view=graph-rest-1.0
        /// </summary>
        public partial class RiskDetection
        {
            public enum RiskDetectionActivityType
            {
                Signin,
                User,
                UnknownFutureValue,
            }
            public enum RiskDetectionRiskDetectionTimingType
            {
                NotDefined,
                Realtime,
                NearRealtime,
                Offline,
                UnknownFutureValue,
            }
            public enum RiskDetectionRiskDetail
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
            public enum RiskDetectionRiskLevel
            {
                Low,
                Medium,
                High,
                Hidden,
                None,
                UnknownFutureValue,
            }
            public enum RiskDetectionRiskState
            {
                None,
                ConfirmedSafe,
                Remediated,
                Dismissed,
                AtRisk,
                ConfirmedCompromised,
                UnknownFutureValue,
            }
            public enum RiskDetectionTokenIssuerType
            {
                AzureAD,
                ADFederationServices,
                UnknownFutureValue,
            }

            public RiskDetectionActivityType Activity { get; set; }
            public DateTimeOffset? ActivityDateTime { get; set; }
            public string? AdditionalInfo { get; set; }
            public string? CorrelationId { get; set; }
            public DateTimeOffset? DetectedDateTime { get; set; }
            public RiskDetectionRiskDetectionTimingType DetectionTimingType { get; set; }
            public string? Id { get; set; }
            public string? IpAddress { get; set; }
            public DateTimeOffset? LastUpdatedDateTime { get; set; }
            public SignInLocation? Location { get; set; }
            public string? RequestId { get; set; }
            public RiskDetectionRiskDetail RiskDetail { get; set; }
            public string? RiskEventType { get; set; }
            public RiskDetectionRiskLevel RiskLevel { get; set; }
            public RiskDetectionRiskState RiskState { get; set; }
            public string? Source { get; set; }
            public RiskDetectionTokenIssuerType TokenIssuerType { get; set; }
            public string? UserDisplayName { get; set; }
            public string? UserId { get; set; }
            public string? UserPrincipalName { get; set; }
        }

        public RiskDetection[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskdetection-list?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskdetectionListResponse> RiskdetectionListAsync()
        {
            var p = new RiskdetectionListParameter();
            return await this.SendAsync<RiskdetectionListParameter, RiskdetectionListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskdetection-list?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskdetectionListResponse> RiskdetectionListAsync(CancellationToken cancellationToken)
        {
            var p = new RiskdetectionListParameter();
            return await this.SendAsync<RiskdetectionListParameter, RiskdetectionListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskdetection-list?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskdetectionListResponse> RiskdetectionListAsync(RiskdetectionListParameter parameter)
        {
            return await this.SendAsync<RiskdetectionListParameter, RiskdetectionListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskdetection-list?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskdetectionListResponse> RiskdetectionListAsync(RiskdetectionListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RiskdetectionListParameter, RiskdetectionListResponse>(parameter, cancellationToken);
        }
    }
}
