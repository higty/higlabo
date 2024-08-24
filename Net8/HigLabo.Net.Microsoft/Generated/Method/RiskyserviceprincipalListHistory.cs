using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-list-history?view=graph-rest-1.0
    /// </summary>
    public partial class RiskyServicePrincipalListHistoryParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class RiskyServicePrincipalListHistoryResponse : RestApiResponse<RiskyServicePrincipalHistoryItem>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-list-history?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-list-history?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyServicePrincipalListHistoryResponse> RiskyServicePrincipalListHistoryAsync()
        {
            var p = new RiskyServicePrincipalListHistoryParameter();
            return await this.SendAsync<RiskyServicePrincipalListHistoryParameter, RiskyServicePrincipalListHistoryResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-list-history?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyServicePrincipalListHistoryResponse> RiskyServicePrincipalListHistoryAsync(CancellationToken cancellationToken)
        {
            var p = new RiskyServicePrincipalListHistoryParameter();
            return await this.SendAsync<RiskyServicePrincipalListHistoryParameter, RiskyServicePrincipalListHistoryResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-list-history?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyServicePrincipalListHistoryResponse> RiskyServicePrincipalListHistoryAsync(RiskyServicePrincipalListHistoryParameter parameter)
        {
            return await this.SendAsync<RiskyServicePrincipalListHistoryParameter, RiskyServicePrincipalListHistoryResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-list-history?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyServicePrincipalListHistoryResponse> RiskyServicePrincipalListHistoryAsync(RiskyServicePrincipalListHistoryParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RiskyServicePrincipalListHistoryParameter, RiskyServicePrincipalListHistoryResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-list-history?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<RiskyServicePrincipalHistoryItem> RiskyServicePrincipalListHistoryEnumerateAsync(RiskyServicePrincipalListHistoryParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<RiskyServicePrincipalListHistoryParameter, RiskyServicePrincipalListHistoryResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<RiskyServicePrincipalHistoryItem>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
