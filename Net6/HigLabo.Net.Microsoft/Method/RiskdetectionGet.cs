using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class RiskdetectionGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string RiskDetectionId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityProtection_RiskDetections_RiskDetectionId: return $"/identityProtection/riskDetections/{RiskDetectionId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityProtection_RiskDetections_RiskDetectionId,
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
    public partial class RiskdetectionGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskdetection-get?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskdetectionGetResponse> RiskdetectionGetAsync()
        {
            var p = new RiskdetectionGetParameter();
            return await this.SendAsync<RiskdetectionGetParameter, RiskdetectionGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskdetection-get?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskdetectionGetResponse> RiskdetectionGetAsync(CancellationToken cancellationToken)
        {
            var p = new RiskdetectionGetParameter();
            return await this.SendAsync<RiskdetectionGetParameter, RiskdetectionGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskdetection-get?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskdetectionGetResponse> RiskdetectionGetAsync(RiskdetectionGetParameter parameter)
        {
            return await this.SendAsync<RiskdetectionGetParameter, RiskdetectionGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskdetection-get?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskdetectionGetResponse> RiskdetectionGetAsync(RiskdetectionGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RiskdetectionGetParameter, RiskdetectionGetResponse>(parameter, cancellationToken);
        }
    }
}
