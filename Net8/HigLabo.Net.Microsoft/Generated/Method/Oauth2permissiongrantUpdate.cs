using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-update?view=graph-rest-1.0
/// </summary>
public partial class Oauth2PermissionGrantUpdateParameter : IRestApiParameter
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
    string IRestApiParameter.HttpMethod { get; } = "PATCH";
    public string? Scope { get; set; }
}
public partial class Oauth2PermissionGrantUpdateResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<Oauth2PermissionGrantUpdateResponse> Oauth2PermissionGrantUpdateAsync()
    {
        var p = new Oauth2PermissionGrantUpdateParameter();
        return await this.SendAsync<Oauth2PermissionGrantUpdateParameter, Oauth2PermissionGrantUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<Oauth2PermissionGrantUpdateResponse> Oauth2PermissionGrantUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new Oauth2PermissionGrantUpdateParameter();
        return await this.SendAsync<Oauth2PermissionGrantUpdateParameter, Oauth2PermissionGrantUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<Oauth2PermissionGrantUpdateResponse> Oauth2PermissionGrantUpdateAsync(Oauth2PermissionGrantUpdateParameter parameter)
    {
        return await this.SendAsync<Oauth2PermissionGrantUpdateParameter, Oauth2PermissionGrantUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/oauth2permissiongrant-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<Oauth2PermissionGrantUpdateResponse> Oauth2PermissionGrantUpdateAsync(Oauth2PermissionGrantUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<Oauth2PermissionGrantUpdateParameter, Oauth2PermissionGrantUpdateResponse>(parameter, cancellationToken);
    }
}
