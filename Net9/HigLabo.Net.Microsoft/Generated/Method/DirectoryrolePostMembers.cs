using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/directoryrole-post-members?view=graph-rest-1.0
/// </summary>
public partial class DirectoryrolePostMembersParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? RoleId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.DirectoryRoles_RoleId_Members_ref: return $"/directoryRoles/{RoleId}/members/$ref";
                case ApiPath.DirectoryRoles_RoleTemplateId: return $"/directoryRoles/roleTemplateId";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        DirectoryRoles_RoleId_Members_ref,
        DirectoryRoles_RoleTemplateId,
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
}
public partial class DirectoryrolePostMembersResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/directoryrole-post-members?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryrole-post-members?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryrolePostMembersResponse> DirectoryrolePostMembersAsync()
    {
        var p = new DirectoryrolePostMembersParameter();
        return await this.SendAsync<DirectoryrolePostMembersParameter, DirectoryrolePostMembersResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryrole-post-members?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryrolePostMembersResponse> DirectoryrolePostMembersAsync(CancellationToken cancellationToken)
    {
        var p = new DirectoryrolePostMembersParameter();
        return await this.SendAsync<DirectoryrolePostMembersParameter, DirectoryrolePostMembersResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryrole-post-members?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryrolePostMembersResponse> DirectoryrolePostMembersAsync(DirectoryrolePostMembersParameter parameter)
    {
        return await this.SendAsync<DirectoryrolePostMembersParameter, DirectoryrolePostMembersResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryrole-post-members?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryrolePostMembersResponse> DirectoryrolePostMembersAsync(DirectoryrolePostMembersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DirectoryrolePostMembersParameter, DirectoryrolePostMembersResponse>(parameter, cancellationToken);
    }
}
