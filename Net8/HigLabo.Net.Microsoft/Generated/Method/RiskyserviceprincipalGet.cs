using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-get?view=graph-rest-1.0
    /// </summary>
    public partial class RiskyServicePrincipalGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? RiskyServicePrincipalId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityProtection_RiskyServicePrincipals_RiskyServicePrincipalId: return $"/identityProtection/riskyServicePrincipals/{RiskyServicePrincipalId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityProtection_RiskyServicePrincipals_RiskyServicePrincipalId,
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
    public partial class RiskyServicePrincipalGetResponse : RestApiResponse
    {
        public enum RiskyServicePrincipalRiskDetail
        {
            Hidden,
            None,
            UnknownFutureValue,
            AdminConfirmedServicePrincipalCompromised,
            AdminDismissedAllRiskForServicePrincipal,
        }
        public enum RiskyServicePrincipalRiskLevel
        {
            Low,
            Medium,
            High,
            Hidden,
            None,
            UnknownFutureValue,
            Eq,
        }
        public enum RiskyServicePrincipalRiskState
        {
            None,
            ConfirmedSafe,
            Remediated,
            Dismissed,
            AtRisk,
            ConfirmedCompromised,
            UnknownFutureValue,
        }

        public string? AppId { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsEnabled { get; set; }
        public bool? IsProcessing { get; set; }
        public RiskyServicePrincipalRiskDetail RiskDetail { get; set; }
        public DateTimeOffset? RiskLastUpdatedDateTime { get; set; }
        public RiskyServicePrincipalRiskLevel RiskLevel { get; set; }
        public RiskyServicePrincipalRiskState RiskState { get; set; }
        public string? ServicePrincipalType { get; set; }
        public RiskyServicePrincipalHistoryItem[]? History { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyServicePrincipalGetResponse> RiskyServicePrincipalGetAsync()
        {
            var p = new RiskyServicePrincipalGetParameter();
            return await this.SendAsync<RiskyServicePrincipalGetParameter, RiskyServicePrincipalGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyServicePrincipalGetResponse> RiskyServicePrincipalGetAsync(CancellationToken cancellationToken)
        {
            var p = new RiskyServicePrincipalGetParameter();
            return await this.SendAsync<RiskyServicePrincipalGetParameter, RiskyServicePrincipalGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyServicePrincipalGetResponse> RiskyServicePrincipalGetAsync(RiskyServicePrincipalGetParameter parameter)
        {
            return await this.SendAsync<RiskyServicePrincipalGetParameter, RiskyServicePrincipalGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyServicePrincipalGetResponse> RiskyServicePrincipalGetAsync(RiskyServicePrincipalGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RiskyServicePrincipalGetParameter, RiskyServicePrincipalGetResponse>(parameter, cancellationToken);
        }
    }
}
