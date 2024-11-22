using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/directory-post-administrativeunits?view=graph-rest-1.0
/// </summary>
public partial class DirectoryPostAdministrativeunitsParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Directory_AdministrativeUnits: return $"/directory/administrativeUnits";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Directory_AdministrativeUnits,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public string? Visibility { get; set; }
    public DirectoryObject[]? Members { get; set; }
    public Extension[]? Extensions { get; set; }
    public ScopedRoleMembership[]? ScopedRoleMembers { get; set; }
}
public partial class DirectoryPostAdministrativeunitsResponse : RestApiResponse
{
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public string? Visibility { get; set; }
    public DirectoryObject[]? Members { get; set; }
    public Extension[]? Extensions { get; set; }
    public ScopedRoleMembership[]? ScopedRoleMembers { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/directory-post-administrativeunits?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directory-post-administrativeunits?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryPostAdministrativeunitsResponse> DirectoryPostAdministrativeunitsAsync()
    {
        var p = new DirectoryPostAdministrativeunitsParameter();
        return await this.SendAsync<DirectoryPostAdministrativeunitsParameter, DirectoryPostAdministrativeunitsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directory-post-administrativeunits?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryPostAdministrativeunitsResponse> DirectoryPostAdministrativeunitsAsync(CancellationToken cancellationToken)
    {
        var p = new DirectoryPostAdministrativeunitsParameter();
        return await this.SendAsync<DirectoryPostAdministrativeunitsParameter, DirectoryPostAdministrativeunitsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directory-post-administrativeunits?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryPostAdministrativeunitsResponse> DirectoryPostAdministrativeunitsAsync(DirectoryPostAdministrativeunitsParameter parameter)
    {
        return await this.SendAsync<DirectoryPostAdministrativeunitsParameter, DirectoryPostAdministrativeunitsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directory-post-administrativeunits?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryPostAdministrativeunitsResponse> DirectoryPostAdministrativeunitsAsync(DirectoryPostAdministrativeunitsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DirectoryPostAdministrativeunitsParameter, DirectoryPostAdministrativeunitsResponse>(parameter, cancellationToken);
    }
}
