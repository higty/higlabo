using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/identityprovider-list?view=graph-rest-1.0
/// </summary>
public partial class IdentityProviderListParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityProviders: return $"/identityProviders";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        IdentityProviders,
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
public partial class IdentityProviderListResponse : RestApiResponse<IdentityProvider>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/identityprovider-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprovider-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityProviderListResponse> IdentityProviderListAsync()
    {
        var p = new IdentityProviderListParameter();
        return await this.SendAsync<IdentityProviderListParameter, IdentityProviderListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprovider-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityProviderListResponse> IdentityProviderListAsync(CancellationToken cancellationToken)
    {
        var p = new IdentityProviderListParameter();
        return await this.SendAsync<IdentityProviderListParameter, IdentityProviderListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprovider-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityProviderListResponse> IdentityProviderListAsync(IdentityProviderListParameter parameter)
    {
        return await this.SendAsync<IdentityProviderListParameter, IdentityProviderListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprovider-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityProviderListResponse> IdentityProviderListAsync(IdentityProviderListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<IdentityProviderListParameter, IdentityProviderListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprovider-list?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<IdentityProvider> IdentityProviderListEnumerateAsync(IdentityProviderListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<IdentityProviderListParameter, IdentityProviderListResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<IdentityProvider>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
