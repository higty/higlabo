using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-list-ediscoverycases?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityCasesRootListEDiscoverycasesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases: return $"/security/cases/ediscoveryCases";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases,
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
    public partial class SecurityCasesRootListEDiscoverycasesResponse : RestApiResponse<EDiscoveryCase>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-list-ediscoverycases?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-list-ediscoverycases?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityCasesRootListEDiscoverycasesResponse> SecurityCasesRootListEDiscoverycasesAsync()
        {
            var p = new SecurityCasesRootListEDiscoverycasesParameter();
            return await this.SendAsync<SecurityCasesRootListEDiscoverycasesParameter, SecurityCasesRootListEDiscoverycasesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-list-ediscoverycases?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityCasesRootListEDiscoverycasesResponse> SecurityCasesRootListEDiscoverycasesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityCasesRootListEDiscoverycasesParameter();
            return await this.SendAsync<SecurityCasesRootListEDiscoverycasesParameter, SecurityCasesRootListEDiscoverycasesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-list-ediscoverycases?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityCasesRootListEDiscoverycasesResponse> SecurityCasesRootListEDiscoverycasesAsync(SecurityCasesRootListEDiscoverycasesParameter parameter)
        {
            return await this.SendAsync<SecurityCasesRootListEDiscoverycasesParameter, SecurityCasesRootListEDiscoverycasesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-list-ediscoverycases?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityCasesRootListEDiscoverycasesResponse> SecurityCasesRootListEDiscoverycasesAsync(SecurityCasesRootListEDiscoverycasesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityCasesRootListEDiscoverycasesParameter, SecurityCasesRootListEDiscoverycasesResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-list-ediscoverycases?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<EDiscoveryCase> SecurityCasesRootListEDiscoverycasesEnumerateAsync(SecurityCasesRootListEDiscoverycasesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<SecurityCasesRootListEDiscoverycasesParameter, SecurityCasesRootListEDiscoverycasesResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<EDiscoveryCase>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
