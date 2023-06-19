using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipalriskdetection-get?view=graph-rest-1.0
    /// </summary>
    public partial class ServiceprincipalriskdetectionGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ServicePrincipalRiskDetectionId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityProtection_ServicePrincipalRiskDetections_ServicePrincipalRiskDetectionId: return $"/identityProtection/servicePrincipalRiskDetections/{ServicePrincipalRiskDetectionId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityProtection_ServicePrincipalRiskDetections_ServicePrincipalRiskDetectionId,
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
    public partial class ServiceprincipalriskdetectionGetResponse : RestApiResponse
    {
        public enum ServicePrincipalRiskDetectionActivityType
        {
            Signin,
            ServicePrincipal,
        }
        public enum ServicePrincipalRiskDetectionRiskDetectionTimingType
        {
            NotDefined,
            Realtime,
            NearRealtime,
            Offline,
            UnknownFutureValue,
        }
        public enum ServicePrincipalRiskDetectionRiskDetail
        {
            Hidden,
            None,
            AdminConfirmedServicePrincipalCompromised,
            AdminDismissedAllRiskForServicePrincipal,
        }
        public enum ServicePrincipalRiskDetectionRiskLevel
        {
            Hidden,
            Low,
            Medium,
            High,
            None,
        }
        public enum ServicePrincipalRiskDetectionRiskState
        {
            None,
            Dismissed,
            AtRisk,
            ConfirmedCompromised,
        }
        public enum ServicePrincipalRiskDetectionTokenIssuerType
        {
            AzureAD,
        }

        public ServicePrincipalRiskDetectionActivityType Activity { get; set; }
        public DateTimeOffset? ActivityDateTime { get; set; }
        public string? AdditionalInfo { get; set; }
        public string? AppId { get; set; }
        public string? CorrelationId { get; set; }
        public DateTimeOffset? DetectedDateTime { get; set; }
        public ServicePrincipalRiskDetectionRiskDetectionTimingType DetectionTimingType { get; set; }
        public string? Id { get; set; }
        public string? IpAddress { get; set; }
        public String[]? KeyIds { get; set; }
        public DateTimeOffset? LastUpdatedDateTime { get; set; }
        public SignInLocation? Location { get; set; }
        public string? RequestId { get; set; }
        public ServicePrincipalRiskDetectionRiskDetail RiskDetail { get; set; }
        public string? RiskEventType { get; set; }
        public ServicePrincipalRiskDetectionRiskLevel RiskLevel { get; set; }
        public ServicePrincipalRiskDetectionRiskState RiskState { get; set; }
        public string? ServicePrincipalDisplayName { get; set; }
        public string? ServicePrincipalId { get; set; }
        public string? Source { get; set; }
        public ServicePrincipalRiskDetectionTokenIssuerType TokenIssuerType { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipalriskdetection-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipalriskdetection-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalriskdetectionGetResponse> ServiceprincipalriskdetectionGetAsync()
        {
            var p = new ServiceprincipalriskdetectionGetParameter();
            return await this.SendAsync<ServiceprincipalriskdetectionGetParameter, ServiceprincipalriskdetectionGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipalriskdetection-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalriskdetectionGetResponse> ServiceprincipalriskdetectionGetAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalriskdetectionGetParameter();
            return await this.SendAsync<ServiceprincipalriskdetectionGetParameter, ServiceprincipalriskdetectionGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipalriskdetection-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalriskdetectionGetResponse> ServiceprincipalriskdetectionGetAsync(ServiceprincipalriskdetectionGetParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalriskdetectionGetParameter, ServiceprincipalriskdetectionGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipalriskdetection-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalriskdetectionGetResponse> ServiceprincipalriskdetectionGetAsync(ServiceprincipalriskdetectionGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalriskdetectionGetParameter, ServiceprincipalriskdetectionGetResponse>(parameter, cancellationToken);
        }
    }
}
