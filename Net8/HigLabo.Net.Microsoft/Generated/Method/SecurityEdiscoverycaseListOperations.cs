using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-operations?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEDiscoverycaseListOperationsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Operations: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/operations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Operations,
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
    public partial class SecurityEDiscoverycaseListOperationsResponse : RestApiResponse<CaseOperation>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-operations?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-operations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycaseListOperationsResponse> SecurityEDiscoverycaseListOperationsAsync()
        {
            var p = new SecurityEDiscoverycaseListOperationsParameter();
            return await this.SendAsync<SecurityEDiscoverycaseListOperationsParameter, SecurityEDiscoverycaseListOperationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-operations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycaseListOperationsResponse> SecurityEDiscoverycaseListOperationsAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEDiscoverycaseListOperationsParameter();
            return await this.SendAsync<SecurityEDiscoverycaseListOperationsParameter, SecurityEDiscoverycaseListOperationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-operations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycaseListOperationsResponse> SecurityEDiscoverycaseListOperationsAsync(SecurityEDiscoverycaseListOperationsParameter parameter)
        {
            return await this.SendAsync<SecurityEDiscoverycaseListOperationsParameter, SecurityEDiscoverycaseListOperationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-operations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycaseListOperationsResponse> SecurityEDiscoverycaseListOperationsAsync(SecurityEDiscoverycaseListOperationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEDiscoverycaseListOperationsParameter, SecurityEDiscoverycaseListOperationsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-operations?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<CaseOperation> SecurityEDiscoverycaseListOperationsEnumerateAsync(SecurityEDiscoverycaseListOperationsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<SecurityEDiscoverycaseListOperationsParameter, SecurityEDiscoverycaseListOperationsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<CaseOperation>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
