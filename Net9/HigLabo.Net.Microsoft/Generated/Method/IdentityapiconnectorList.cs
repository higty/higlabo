using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/identityapiconnector-list?view=graph-rest-1.0
/// </summary>
public partial class IdentityapiConnectorListParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Identity_ApiConnectors_: return $"/identity/apiConnectors/";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Identity_ApiConnectors_,
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
public partial class IdentityapiConnectorListResponse : RestApiResponse<IdentityApiConnector>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/identityapiconnector-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityapiconnector-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityapiConnectorListResponse> IdentityapiConnectorListAsync()
    {
        var p = new IdentityapiConnectorListParameter();
        return await this.SendAsync<IdentityapiConnectorListParameter, IdentityapiConnectorListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityapiconnector-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityapiConnectorListResponse> IdentityapiConnectorListAsync(CancellationToken cancellationToken)
    {
        var p = new IdentityapiConnectorListParameter();
        return await this.SendAsync<IdentityapiConnectorListParameter, IdentityapiConnectorListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityapiconnector-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityapiConnectorListResponse> IdentityapiConnectorListAsync(IdentityapiConnectorListParameter parameter)
    {
        return await this.SendAsync<IdentityapiConnectorListParameter, IdentityapiConnectorListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityapiconnector-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityapiConnectorListResponse> IdentityapiConnectorListAsync(IdentityapiConnectorListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<IdentityapiConnectorListParameter, IdentityapiConnectorListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityapiconnector-list?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<IdentityApiConnector> IdentityapiConnectorListEnumerateAsync(IdentityapiConnectorListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<IdentityapiConnectorListParameter, IdentityapiConnectorListResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<IdentityApiConnector>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
