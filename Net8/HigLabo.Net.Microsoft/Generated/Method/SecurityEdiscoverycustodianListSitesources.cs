using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-sitesources?view=graph-rest-1.0
/// </summary>
public partial class SecurityEDiscoverycustodianListSitesourcesParameter : IRestApiParameter, IQueryParameterProperty
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
public partial class SecurityEDiscoverycustodianListSitesourcesResponse : RestApiResponse<SiteSource>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-sitesources?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-sitesources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycustodianListSitesourcesResponse> SecurityEDiscoverycustodianListSitesourcesAsync()
    {
        var p = new SecurityEDiscoverycustodianListSitesourcesParameter();
        return await this.SendAsync<SecurityEDiscoverycustodianListSitesourcesParameter, SecurityEDiscoverycustodianListSitesourcesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-sitesources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycustodianListSitesourcesResponse> SecurityEDiscoverycustodianListSitesourcesAsync(CancellationToken cancellationToken)
    {
        var p = new SecurityEDiscoverycustodianListSitesourcesParameter();
        return await this.SendAsync<SecurityEDiscoverycustodianListSitesourcesParameter, SecurityEDiscoverycustodianListSitesourcesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-sitesources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycustodianListSitesourcesResponse> SecurityEDiscoverycustodianListSitesourcesAsync(SecurityEDiscoverycustodianListSitesourcesParameter parameter)
    {
        return await this.SendAsync<SecurityEDiscoverycustodianListSitesourcesParameter, SecurityEDiscoverycustodianListSitesourcesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-sitesources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycustodianListSitesourcesResponse> SecurityEDiscoverycustodianListSitesourcesAsync(SecurityEDiscoverycustodianListSitesourcesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityEDiscoverycustodianListSitesourcesParameter, SecurityEDiscoverycustodianListSitesourcesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-sitesources?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<SiteSource> SecurityEDiscoverycustodianListSitesourcesEnumerateAsync(SecurityEDiscoverycustodianListSitesourcesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<SecurityEDiscoverycustodianListSitesourcesParameter, SecurityEDiscoverycustodianListSitesourcesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<SiteSource>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
