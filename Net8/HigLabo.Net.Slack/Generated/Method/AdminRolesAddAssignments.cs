using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class AdminRolesAddAssignmentsParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "admin.roles.addAssignments";
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public string? Entity_Ids { get; set; }
    public string? Role_Id { get; set; }
    public string? User_Ids { get; set; }
}
public partial class AdminRolesAddAssignmentsResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/admin.roles.addAssignments
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/admin.roles.addAssignments
    /// </summary>
    public async ValueTask<AdminRolesAddAssignmentsResponse> AdminRolesAddAssignmentsAsync(string? entity_Ids, string? role_Id, string? user_Ids)
    {
        var p = new AdminRolesAddAssignmentsParameter();
        p.Entity_Ids = entity_Ids;
        p.Role_Id = role_Id;
        p.User_Ids = user_Ids;
        return await this.SendAsync<AdminRolesAddAssignmentsParameter, AdminRolesAddAssignmentsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.roles.addAssignments
    /// </summary>
    public async ValueTask<AdminRolesAddAssignmentsResponse> AdminRolesAddAssignmentsAsync(string? entity_Ids, string? role_Id, string? user_Ids, CancellationToken cancellationToken)
    {
        var p = new AdminRolesAddAssignmentsParameter();
        p.Entity_Ids = entity_Ids;
        p.Role_Id = role_Id;
        p.User_Ids = user_Ids;
        return await this.SendAsync<AdminRolesAddAssignmentsParameter, AdminRolesAddAssignmentsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.roles.addAssignments
    /// </summary>
    public async ValueTask<AdminRolesAddAssignmentsResponse> AdminRolesAddAssignmentsAsync(AdminRolesAddAssignmentsParameter parameter)
    {
        return await this.SendAsync<AdminRolesAddAssignmentsParameter, AdminRolesAddAssignmentsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.roles.addAssignments
    /// </summary>
    public async ValueTask<AdminRolesAddAssignmentsResponse> AdminRolesAddAssignmentsAsync(AdminRolesAddAssignmentsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AdminRolesAddAssignmentsParameter, AdminRolesAddAssignmentsResponse>(parameter, cancellationToken);
    }
}
