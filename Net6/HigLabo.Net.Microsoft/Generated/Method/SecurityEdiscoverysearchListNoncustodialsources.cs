using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-noncustodialsources?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverysearchListNoncustodialsourcesParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId_NoncustodialSources: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/searches/{EdiscoverySearchId}/noncustodialSources";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            CreatedDateTime,
            DisplayName,
            HoldStatus,
            Id,
            LastModifiedDateTime,
            ReleasedDateTime,
            Status,
            DataSource,
            LastIndexOperation,
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId_NoncustodialSources,
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
    public partial class SecurityEdiscoverysearchListNoncustodialsourcesResponse : RestApiResponse
    {
        public EdiscoveryNoncustodialDataSource[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-noncustodialsources?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-noncustodialsources?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverysearchListNoncustodialsourcesResponse> SecurityEdiscoverysearchListNoncustodialsourcesAsync()
        {
            var p = new SecurityEdiscoverysearchListNoncustodialsourcesParameter();
            return await this.SendAsync<SecurityEdiscoverysearchListNoncustodialsourcesParameter, SecurityEdiscoverysearchListNoncustodialsourcesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-noncustodialsources?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverysearchListNoncustodialsourcesResponse> SecurityEdiscoverysearchListNoncustodialsourcesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverysearchListNoncustodialsourcesParameter();
            return await this.SendAsync<SecurityEdiscoverysearchListNoncustodialsourcesParameter, SecurityEdiscoverysearchListNoncustodialsourcesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-noncustodialsources?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverysearchListNoncustodialsourcesResponse> SecurityEdiscoverysearchListNoncustodialsourcesAsync(SecurityEdiscoverysearchListNoncustodialsourcesParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverysearchListNoncustodialsourcesParameter, SecurityEdiscoverysearchListNoncustodialsourcesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-noncustodialsources?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverysearchListNoncustodialsourcesResponse> SecurityEdiscoverysearchListNoncustodialsourcesAsync(SecurityEdiscoverysearchListNoncustodialsourcesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverysearchListNoncustodialsourcesParameter, SecurityEdiscoverysearchListNoncustodialsourcesResponse>(parameter, cancellationToken);
        }
    }
}
