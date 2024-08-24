using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-custodians?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEDiscoverycaseListCustodiansParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/custodians";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians,
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
    public partial class SecurityEDiscoverycaseListCustodiansResponse : RestApiResponse<EDiscoveryCustodian>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-custodians?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-custodians?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycaseListCustodiansResponse> SecurityEDiscoverycaseListCustodiansAsync()
        {
            var p = new SecurityEDiscoverycaseListCustodiansParameter();
            return await this.SendAsync<SecurityEDiscoverycaseListCustodiansParameter, SecurityEDiscoverycaseListCustodiansResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-custodians?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycaseListCustodiansResponse> SecurityEDiscoverycaseListCustodiansAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEDiscoverycaseListCustodiansParameter();
            return await this.SendAsync<SecurityEDiscoverycaseListCustodiansParameter, SecurityEDiscoverycaseListCustodiansResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-custodians?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycaseListCustodiansResponse> SecurityEDiscoverycaseListCustodiansAsync(SecurityEDiscoverycaseListCustodiansParameter parameter)
        {
            return await this.SendAsync<SecurityEDiscoverycaseListCustodiansParameter, SecurityEDiscoverycaseListCustodiansResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-custodians?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycaseListCustodiansResponse> SecurityEDiscoverycaseListCustodiansAsync(SecurityEDiscoverycaseListCustodiansParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEDiscoverycaseListCustodiansParameter, SecurityEDiscoverycaseListCustodiansResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-custodians?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<EDiscoveryCustodian> SecurityEDiscoverycaseListCustodiansEnumerateAsync(SecurityEDiscoverycaseListCustodiansParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<SecurityEDiscoverycaseListCustodiansParameter, SecurityEDiscoverycaseListCustodiansResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<EDiscoveryCustodian>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
