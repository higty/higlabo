using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/directoryrole-post-directoryroles?view=graph-rest-1.0
/// </summary>
public partial class DirectoryrolePostDirectoryrolesParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.DirectoryRoles: return $"/directoryRoles";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        DirectoryRoles,
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
    public string? RoleTemplateId { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public DirectoryObject[]? Members { get; set; }
    public ScopedRoleMembership[]? ScopedMembers { get; set; }
}
public partial class DirectoryrolePostDirectoryrolesResponse : RestApiResponse
{
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public string? RoleTemplateId { get; set; }
    public DirectoryObject[]? Members { get; set; }
    public ScopedRoleMembership[]? ScopedMembers { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/directoryrole-post-directoryroles?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryrole-post-directoryroles?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryrolePostDirectoryrolesResponse> DirectoryrolePostDirectoryrolesAsync()
    {
        var p = new DirectoryrolePostDirectoryrolesParameter();
        return await this.SendAsync<DirectoryrolePostDirectoryrolesParameter, DirectoryrolePostDirectoryrolesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryrole-post-directoryroles?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryrolePostDirectoryrolesResponse> DirectoryrolePostDirectoryrolesAsync(CancellationToken cancellationToken)
    {
        var p = new DirectoryrolePostDirectoryrolesParameter();
        return await this.SendAsync<DirectoryrolePostDirectoryrolesParameter, DirectoryrolePostDirectoryrolesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryrole-post-directoryroles?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryrolePostDirectoryrolesResponse> DirectoryrolePostDirectoryrolesAsync(DirectoryrolePostDirectoryrolesParameter parameter)
    {
        return await this.SendAsync<DirectoryrolePostDirectoryrolesParameter, DirectoryrolePostDirectoryrolesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryrole-post-directoryroles?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryrolePostDirectoryrolesResponse> DirectoryrolePostDirectoryrolesAsync(DirectoryrolePostDirectoryrolesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DirectoryrolePostDirectoryrolesParameter, DirectoryrolePostDirectoryrolesResponse>(parameter, cancellationToken);
    }
}
