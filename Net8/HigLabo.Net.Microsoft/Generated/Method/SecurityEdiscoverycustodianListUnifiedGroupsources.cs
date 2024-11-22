using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-unifiedgroupsources?view=graph-rest-1.0
/// </summary>
public partial class SecurityEDiscoverycustodianListUnifiedGroupsourcesParameter : IRestApiParameter, IQueryParameterProperty
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
                case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_CustodianId_UnifiedGroupSources: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/custodians/{CustodianId}/unifiedGroupSources";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_CustodianId_UnifiedGroupSources,
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
public partial class SecurityEDiscoverycustodianListUnifiedGroupsourcesResponse : RestApiResponse<UnifiedGroupSource>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-unifiedgroupsources?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-unifiedgroupsources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycustodianListUnifiedGroupsourcesResponse> SecurityEDiscoverycustodianListUnifiedGroupsourcesAsync()
    {
        var p = new SecurityEDiscoverycustodianListUnifiedGroupsourcesParameter();
        return await this.SendAsync<SecurityEDiscoverycustodianListUnifiedGroupsourcesParameter, SecurityEDiscoverycustodianListUnifiedGroupsourcesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-unifiedgroupsources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycustodianListUnifiedGroupsourcesResponse> SecurityEDiscoverycustodianListUnifiedGroupsourcesAsync(CancellationToken cancellationToken)
    {
        var p = new SecurityEDiscoverycustodianListUnifiedGroupsourcesParameter();
        return await this.SendAsync<SecurityEDiscoverycustodianListUnifiedGroupsourcesParameter, SecurityEDiscoverycustodianListUnifiedGroupsourcesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-unifiedgroupsources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycustodianListUnifiedGroupsourcesResponse> SecurityEDiscoverycustodianListUnifiedGroupsourcesAsync(SecurityEDiscoverycustodianListUnifiedGroupsourcesParameter parameter)
    {
        return await this.SendAsync<SecurityEDiscoverycustodianListUnifiedGroupsourcesParameter, SecurityEDiscoverycustodianListUnifiedGroupsourcesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-unifiedgroupsources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycustodianListUnifiedGroupsourcesResponse> SecurityEDiscoverycustodianListUnifiedGroupsourcesAsync(SecurityEDiscoverycustodianListUnifiedGroupsourcesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityEDiscoverycustodianListUnifiedGroupsourcesParameter, SecurityEDiscoverycustodianListUnifiedGroupsourcesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-unifiedgroupsources?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<UnifiedGroupSource> SecurityEDiscoverycustodianListUnifiedGroupsourcesEnumerateAsync(SecurityEDiscoverycustodianListUnifiedGroupsourcesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<SecurityEDiscoverycustodianListUnifiedGroupsourcesParameter, SecurityEDiscoverycustodianListUnifiedGroupsourcesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<UnifiedGroupSource>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
