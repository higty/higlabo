using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-sitesources?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverycustodianListSitesourcesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }
            public string? CustodianId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_CustodianId_SiteSources: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/custodians/{CustodianId}/siteSources";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_CustodianId_SiteSources,
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
    public partial class SecurityEdiscoverycustodianListSitesourcesResponse : RestApiResponse
    {
        public SiteSource[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-sitesources?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-sitesources?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycustodianListSitesourcesResponse> SecurityEdiscoverycustodianListSitesourcesAsync()
        {
            var p = new SecurityEdiscoverycustodianListSitesourcesParameter();
            return await this.SendAsync<SecurityEdiscoverycustodianListSitesourcesParameter, SecurityEdiscoverycustodianListSitesourcesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-sitesources?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycustodianListSitesourcesResponse> SecurityEdiscoverycustodianListSitesourcesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverycustodianListSitesourcesParameter();
            return await this.SendAsync<SecurityEdiscoverycustodianListSitesourcesParameter, SecurityEdiscoverycustodianListSitesourcesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-sitesources?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycustodianListSitesourcesResponse> SecurityEdiscoverycustodianListSitesourcesAsync(SecurityEdiscoverycustodianListSitesourcesParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverycustodianListSitesourcesParameter, SecurityEdiscoverycustodianListSitesourcesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-sitesources?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycustodianListSitesourcesResponse> SecurityEdiscoverycustodianListSitesourcesAsync(SecurityEdiscoverycustodianListSitesourcesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverycustodianListSitesourcesParameter, SecurityEdiscoverycustodianListSitesourcesResponse>(parameter, cancellationToken);
        }
    }
}
