using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-lastindexoperation?view=graph-rest-1.0
/// </summary>
public partial class SecurityEDiscoverycustodianListLastindexOperationParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? EdiscoveryCaseId { get; set; }
        public string? EdiscoverycustodianId { get; set; }
        public string? EdiscoveryNoncustodialDataSourceId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_EdiscoverycustodianId_LastIndexOperation: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/custodians/{EdiscoverycustodianId}/lastIndexOperation";
                case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_NoncustodialSources_EdiscoveryNoncustodialDataSourceId_LastIndexOperation: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/noncustodialSources/{EdiscoveryNoncustodialDataSourceId}/lastIndexOperation";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_EdiscoverycustodianId_LastIndexOperation,
        Security_Cases_EdiscoveryCases_EdiscoveryCaseId_NoncustodialSources_EdiscoveryNoncustodialDataSourceId_LastIndexOperation,
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
public partial class SecurityEDiscoverycustodianListLastindexOperationResponse : RestApiResponse<EDiscoveryIndexOperation>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-lastindexoperation?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-lastindexoperation?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycustodianListLastindexOperationResponse> SecurityEDiscoverycustodianListLastindexOperationAsync()
    {
        var p = new SecurityEDiscoverycustodianListLastindexOperationParameter();
        return await this.SendAsync<SecurityEDiscoverycustodianListLastindexOperationParameter, SecurityEDiscoverycustodianListLastindexOperationResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-lastindexoperation?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycustodianListLastindexOperationResponse> SecurityEDiscoverycustodianListLastindexOperationAsync(CancellationToken cancellationToken)
    {
        var p = new SecurityEDiscoverycustodianListLastindexOperationParameter();
        return await this.SendAsync<SecurityEDiscoverycustodianListLastindexOperationParameter, SecurityEDiscoverycustodianListLastindexOperationResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-lastindexoperation?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycustodianListLastindexOperationResponse> SecurityEDiscoverycustodianListLastindexOperationAsync(SecurityEDiscoverycustodianListLastindexOperationParameter parameter)
    {
        return await this.SendAsync<SecurityEDiscoverycustodianListLastindexOperationParameter, SecurityEDiscoverycustodianListLastindexOperationResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-lastindexoperation?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycustodianListLastindexOperationResponse> SecurityEDiscoverycustodianListLastindexOperationAsync(SecurityEDiscoverycustodianListLastindexOperationParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityEDiscoverycustodianListLastindexOperationParameter, SecurityEDiscoverycustodianListLastindexOperationResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-lastindexoperation?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<EDiscoveryIndexOperation> SecurityEDiscoverycustodianListLastindexOperationEnumerateAsync(SecurityEDiscoverycustodianListLastindexOperationParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<SecurityEDiscoverycustodianListLastindexOperationParameter, SecurityEDiscoverycustodianListLastindexOperationResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<EDiscoveryIndexOperation>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
