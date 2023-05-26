using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-custodiansources?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverysearchListCustodiansourcesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }
            public string? EdiscoverySearchId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId_CustodianSources: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/searches/{EdiscoverySearchId}/custodianSources";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId_CustodianSources,
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
    public partial class SecurityEdiscoverysearchListCustodiansourcesResponse : RestApiResponse
    {
        public DataSource[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-custodiansources?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-custodiansources?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverysearchListCustodiansourcesResponse> SecurityEdiscoverysearchListCustodiansourcesAsync()
        {
            var p = new SecurityEdiscoverysearchListCustodiansourcesParameter();
            return await this.SendAsync<SecurityEdiscoverysearchListCustodiansourcesParameter, SecurityEdiscoverysearchListCustodiansourcesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-custodiansources?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverysearchListCustodiansourcesResponse> SecurityEdiscoverysearchListCustodiansourcesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverysearchListCustodiansourcesParameter();
            return await this.SendAsync<SecurityEdiscoverysearchListCustodiansourcesParameter, SecurityEdiscoverysearchListCustodiansourcesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-custodiansources?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverysearchListCustodiansourcesResponse> SecurityEdiscoverysearchListCustodiansourcesAsync(SecurityEdiscoverysearchListCustodiansourcesParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverysearchListCustodiansourcesParameter, SecurityEdiscoverysearchListCustodiansourcesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-custodiansources?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverysearchListCustodiansourcesResponse> SecurityEdiscoverysearchListCustodiansourcesAsync(SecurityEdiscoverysearchListCustodiansourcesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverysearchListCustodiansourcesParameter, SecurityEdiscoverysearchListCustodiansourcesResponse>(parameter, cancellationToken);
        }
    }
}
