using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-delta?view=graph-rest-1.0
/// </summary>
public partial class Oauth2PermissionGrantDeltaParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Oauth2PermissionGrants_Delta: return $"/oauth2PermissionGrants/delta";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Oauth2PermissionGrants_Delta,
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
public partial class Oauth2PermissionGrantDeltaResponse : RestApiResponse<OAuth2PermissionGrant>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-delta?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<Oauth2PermissionGrantDeltaResponse> Oauth2PermissionGrantDeltaAsync()
    {
        var p = new Oauth2PermissionGrantDeltaParameter();
        return await this.SendAsync<Oauth2PermissionGrantDeltaParameter, Oauth2PermissionGrantDeltaResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<Oauth2PermissionGrantDeltaResponse> Oauth2PermissionGrantDeltaAsync(CancellationToken cancellationToken)
    {
        var p = new Oauth2PermissionGrantDeltaParameter();
        return await this.SendAsync<Oauth2PermissionGrantDeltaParameter, Oauth2PermissionGrantDeltaResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<Oauth2PermissionGrantDeltaResponse> Oauth2PermissionGrantDeltaAsync(Oauth2PermissionGrantDeltaParameter parameter)
    {
        return await this.SendAsync<Oauth2PermissionGrantDeltaParameter, Oauth2PermissionGrantDeltaResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<Oauth2PermissionGrantDeltaResponse> Oauth2PermissionGrantDeltaAsync(Oauth2PermissionGrantDeltaParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<Oauth2PermissionGrantDeltaParameter, Oauth2PermissionGrantDeltaResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-delta?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<OAuth2PermissionGrant> Oauth2PermissionGrantDeltaEnumerateAsync(Oauth2PermissionGrantDeltaParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<Oauth2PermissionGrantDeltaParameter, Oauth2PermissionGrantDeltaResponse>(parameter, cancellationToken);
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
