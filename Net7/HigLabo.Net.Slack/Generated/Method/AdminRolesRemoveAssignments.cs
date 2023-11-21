using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/admin.roles.removeAssignments
    /// </summary>
    public partial class AdminRolesRemoveAssignmentsParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.roles.removeAssignments";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string? Entity_Ids { get; set; }
        public string? Role_Id { get; set; }
        public string? User_Ids { get; set; }
    }
    public partial class AdminRolesRemoveAssignmentsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.roles.removeAssignments
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.roles.removeAssignments
        /// </summary>
        public async ValueTask<AdminRolesRemoveAssignmentsResponse> AdminRolesRemoveAssignmentsAsync(string? entity_Ids, string? role_Id, string? user_Ids)
        {
            var p = new AdminRolesRemoveAssignmentsParameter();
            p.Entity_Ids = entity_Ids;
            p.Role_Id = role_Id;
            p.User_Ids = user_Ids;
            return await this.SendAsync<AdminRolesRemoveAssignmentsParameter, AdminRolesRemoveAssignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.roles.removeAssignments
        /// </summary>
        public async ValueTask<AdminRolesRemoveAssignmentsResponse> AdminRolesRemoveAssignmentsAsync(string? entity_Ids, string? role_Id, string? user_Ids, CancellationToken cancellationToken)
        {
            var p = new AdminRolesRemoveAssignmentsParameter();
            p.Entity_Ids = entity_Ids;
            p.Role_Id = role_Id;
            p.User_Ids = user_Ids;
            return await this.SendAsync<AdminRolesRemoveAssignmentsParameter, AdminRolesRemoveAssignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.roles.removeAssignments
        /// </summary>
        public async ValueTask<AdminRolesRemoveAssignmentsResponse> AdminRolesRemoveAssignmentsAsync(AdminRolesRemoveAssignmentsParameter parameter)
        {
            return await this.SendAsync<AdminRolesRemoveAssignmentsParameter, AdminRolesRemoveAssignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.roles.removeAssignments
        /// </summary>
        public async ValueTask<AdminRolesRemoveAssignmentsResponse> AdminRolesRemoveAssignmentsAsync(AdminRolesRemoveAssignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminRolesRemoveAssignmentsParameter, AdminRolesRemoveAssignmentsResponse>(parameter, cancellationToken);
        }
    }
}
