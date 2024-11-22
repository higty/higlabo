using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-additionalsources?view=graph-rest-1.0
/// </summary>
public partial class SecurityEDiscoverysearchListAdditionalsourcesParameter : IRestApiParameter, IQueryParameterProperty
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
                case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId_AdditionalSources: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/searches/{EdiscoverySearchId}/additionalSources";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId_AdditionalSources,
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
public partial class SecurityEDiscoverysearchListAdditionalsourcesResponse : RestApiResponse<DataSource>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-additionalsources?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-additionalsources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverysearchListAdditionalsourcesResponse> SecurityEDiscoverysearchListAdditionalsourcesAsync()
    {
        var p = new SecurityEDiscoverysearchListAdditionalsourcesParameter();
        return await this.SendAsync<SecurityEDiscoverysearchListAdditionalsourcesParameter, SecurityEDiscoverysearchListAdditionalsourcesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-additionalsources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverysearchListAdditionalsourcesResponse> SecurityEDiscoverysearchListAdditionalsourcesAsync(CancellationToken cancellationToken)
    {
        var p = new SecurityEDiscoverysearchListAdditionalsourcesParameter();
        return await this.SendAsync<SecurityEDiscoverysearchListAdditionalsourcesParameter, SecurityEDiscoverysearchListAdditionalsourcesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-additionalsources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverysearchListAdditionalsourcesResponse> SecurityEDiscoverysearchListAdditionalsourcesAsync(SecurityEDiscoverysearchListAdditionalsourcesParameter parameter)
    {
        return await this.SendAsync<SecurityEDiscoverysearchListAdditionalsourcesParameter, SecurityEDiscoverysearchListAdditionalsourcesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-additionalsources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverysearchListAdditionalsourcesResponse> SecurityEDiscoverysearchListAdditionalsourcesAsync(SecurityEDiscoverysearchListAdditionalsourcesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityEDiscoverysearchListAdditionalsourcesParameter, SecurityEDiscoverysearchListAdditionalsourcesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-additionalsources?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<DataSource> SecurityEDiscoverysearchListAdditionalsourcesEnumerateAsync(SecurityEDiscoverysearchListAdditionalsourcesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<SecurityEDiscoverysearchListAdditionalsourcesParameter, SecurityEDiscoverysearchListAdditionalsourcesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<DataSource>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
