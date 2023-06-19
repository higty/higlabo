using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-list-history?view=graph-rest-1.0
    /// </summary>
    public partial class RiskyserviceprincipalListHistoryParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? RiskyServicePrincipalId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityProtection_RiskyServicePrincipals_RiskyServicePrincipalId_History: return $"/identityProtection/riskyServicePrincipals/{RiskyServicePrincipalId}/history";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityProtection_RiskyServicePrincipals_RiskyServicePrincipalId_History,
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
    public partial class RiskyserviceprincipalListHistoryResponse : RestApiResponse
    {
        public RiskyServicePrincipalHistoryItem[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-list-history?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-list-history?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyserviceprincipalListHistoryResponse> RiskyserviceprincipalListHistoryAsync()
        {
            var p = new RiskyserviceprincipalListHistoryParameter();
            return await this.SendAsync<RiskyserviceprincipalListHistoryParameter, RiskyserviceprincipalListHistoryResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-list-history?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyserviceprincipalListHistoryResponse> RiskyserviceprincipalListHistoryAsync(CancellationToken cancellationToken)
        {
            var p = new RiskyserviceprincipalListHistoryParameter();
            return await this.SendAsync<RiskyserviceprincipalListHistoryParameter, RiskyserviceprincipalListHistoryResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-list-history?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyserviceprincipalListHistoryResponse> RiskyserviceprincipalListHistoryAsync(RiskyserviceprincipalListHistoryParameter parameter)
        {
            return await this.SendAsync<RiskyserviceprincipalListHistoryParameter, RiskyserviceprincipalListHistoryResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-list-history?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyserviceprincipalListHistoryResponse> RiskyserviceprincipalListHistoryAsync(RiskyserviceprincipalListHistoryParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RiskyserviceprincipalListHistoryParameter, RiskyserviceprincipalListHistoryResponse>(parameter, cancellationToken);
        }
    }
}
