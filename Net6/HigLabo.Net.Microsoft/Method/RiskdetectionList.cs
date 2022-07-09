using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class RiskdetectionListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityProtection_RiskDetections: return $"/identityProtection/riskDetections";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Activity,
            ActivityDateTime,
            AdditionalInfo,
            CorrelationId,
            DetectedDateTime,
            DetectionTimingType,
            Id,
            IpAddress,
            LastUpdatedDateTime,
            Location,
            RequestId,
            RiskDetail,
            RiskEventType,
            RiskLevel,
            RiskState,
            Source,
            TokenIssuerType,
            UserDisplayName,
            UserId,
            UserPrincipalName,
        }
        public enum ApiPath
        {
            IdentityProtection_RiskDetections,
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
    public partial class RiskdetectionListResponse : RestApiResponse
    {
        public RiskDetection[]? Value { get; set; }
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
