using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/administrativeunit-post-members?view=graph-rest-1.0
/// </summary>
public partial class AdministrativeunitPostMembersParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Directory_AdministrativeUnits_Id_Members_ref: return $"/directory/administrativeUnits/{Id}/members/$ref";
                case ApiPath.Directory_AdministrativeUnits_Id_Members: return $"/directory/administrativeUnits/{Id}/members";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Directory_AdministrativeUnits_Id_Members_ref,
        Directory_AdministrativeUnits_Id_Members,
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
    public string? DisplayName { get; set; }
    public string? Description { get; set; }
    public bool? IsAssignableToRole { get; set; }
    public bool? MailEnabled { get; set; }
    public string? MailNickname { get; set; }
    public bool? SecurityEnabled { get; set; }
    public DirectoryObject[]? Owners { get; set; }
    public DirectoryObject[]? Members { get; set; }
    public string? Visibility { get; set; }
}
public partial class AdministrativeunitPostMembersResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/administrativeunit-post-members?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-post-members?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AdministrativeunitPostMembersResponse> AdministrativeunitPostMembersAsync()
    {
        var p = new AdministrativeunitPostMembersParameter();
        return await this.SendAsync<AdministrativeunitPostMembersParameter, AdministrativeunitPostMembersResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-post-members?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AdministrativeunitPostMembersResponse> AdministrativeunitPostMembersAsync(CancellationToken cancellationToken)
    {
        var p = new AdministrativeunitPostMembersParameter();
        return await this.SendAsync<AdministrativeunitPostMembersParameter, AdministrativeunitPostMembersResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-post-members?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AdministrativeunitPostMembersResponse> AdministrativeunitPostMembersAsync(AdministrativeunitPostMembersParameter parameter)
    {
        return await this.SendAsync<AdministrativeunitPostMembersParameter, AdministrativeunitPostMembersResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-post-members?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AdministrativeunitPostMembersResponse> AdministrativeunitPostMembersAsync(AdministrativeunitPostMembersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AdministrativeunitPostMembersParameter, AdministrativeunitPostMembersResponse>(parameter, cancellationToken);
    }
}
