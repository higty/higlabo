using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-get?view=graph-rest-1.0
/// </summary>
public partial class Oauth2PermissionGrantGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Oauth2PermissionGrants_Id: return $"/oauth2PermissionGrants/{Id}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Oauth2PermissionGrants_Id,
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
public partial class Oauth2PermissionGrantGetResponse : RestApiResponse
{
    public string? ClientId { get; set; }
    public string? ConsentType { get; set; }
    public string? Id { get; set; }
    public string? PrincipalId { get; set; }
    public string? ResourceId { get; set; }
    public string? Scope { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<Oauth2PermissionGrantGetResponse> Oauth2PermissionGrantGetAsync()
    {
        var p = new Oauth2PermissionGrantGetParameter();
        return await this.SendAsync<Oauth2PermissionGrantGetParameter, Oauth2PermissionGrantGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<Oauth2PermissionGrantGetResponse> Oauth2PermissionGrantGetAsync(CancellationToken cancellationToken)
    {
        var p = new Oauth2PermissionGrantGetParameter();
        return await this.SendAsync<Oauth2PermissionGrantGetParameter, Oauth2PermissionGrantGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<Oauth2PermissionGrantGetResponse> Oauth2PermissionGrantGetAsync(Oauth2PermissionGrantGetParameter parameter)
    {
        return await this.SendAsync<Oauth2PermissionGrantGetParameter, Oauth2PermissionGrantGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<Oauth2PermissionGrantGetResponse> Oauth2PermissionGrantGetAsync(Oauth2PermissionGrantGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<Oauth2PermissionGrantGetParameter, Oauth2PermissionGrantGetResponse>(parameter, cancellationToken);
    }
}
