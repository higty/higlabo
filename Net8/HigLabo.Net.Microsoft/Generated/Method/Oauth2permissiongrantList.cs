using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-list?view=graph-rest-1.0
/// </summary>
public partial class Oauth2PermissionGrantListParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Oauth2PermissionGrants: return $"/oauth2PermissionGrants";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Oauth2PermissionGrants,
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
public partial class Oauth2PermissionGrantListResponse : RestApiResponse<OAuth2PermissionGrant>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<Oauth2PermissionGrantListResponse> Oauth2PermissionGrantListAsync()
    {
        var p = new Oauth2PermissionGrantListParameter();
        return await this.SendAsync<Oauth2PermissionGrantListParameter, Oauth2PermissionGrantListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<Oauth2PermissionGrantListResponse> Oauth2PermissionGrantListAsync(CancellationToken cancellationToken)
    {
        var p = new Oauth2PermissionGrantListParameter();
        return await this.SendAsync<Oauth2PermissionGrantListParameter, Oauth2PermissionGrantListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<Oauth2PermissionGrantListResponse> Oauth2PermissionGrantListAsync(Oauth2PermissionGrantListParameter parameter)
    {
        return await this.SendAsync<Oauth2PermissionGrantListParameter, Oauth2PermissionGrantListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<Oauth2PermissionGrantListResponse> Oauth2PermissionGrantListAsync(Oauth2PermissionGrantListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<Oauth2PermissionGrantListParameter, Oauth2PermissionGrantListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-list?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<OAuth2PermissionGrant> Oauth2PermissionGrantListEnumerateAsync(Oauth2PermissionGrantListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<Oauth2PermissionGrantListParameter, Oauth2PermissionGrantListResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<OAuth2PermissionGrant>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
