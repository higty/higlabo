using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminUsersSessionInvalidateParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.users.session.invalidate";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public int? Session_Id { get; set; }
        public string? Team_Id { get; set; }
    }
    public partial class AdminUsersSessionInvalidateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.users.session.invalidate
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.invalidate
        /// </summary>
        public async ValueTask<AdminUsersSessionInvalidateResponse> AdminUsersSessionInvalidateAsync(int? session_Id, string? team_Id)
        {
            var p = new AdminUsersSessionInvalidateParameter();
            p.Session_Id = session_Id;
            p.Team_Id = team_Id;
            return await this.SendAsync<AdminUsersSessionInvalidateParameter, AdminUsersSessionInvalidateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.invalidate
        /// </summary>
        public async ValueTask<AdminUsersSessionInvalidateResponse> AdminUsersSessionInvalidateAsync(int? session_Id, string? team_Id, CancellationToken cancellationToken)
        {
            var p = new AdminUsersSessionInvalidateParameter();
            p.Session_Id = session_Id;
            p.Team_Id = team_Id;
            return await this.SendAsync<AdminUsersSessionInvalidateParameter, AdminUsersSessionInvalidateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.invalidate
        /// </summary>
        public async ValueTask<AdminUsersSessionInvalidateResponse> AdminUsersSessionInvalidateAsync(AdminUsersSessionInvalidateParameter parameter)
        {
            return await this.SendAsync<AdminUsersSessionInvalidateParameter, AdminUsersSessionInvalidateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.invalidate
        /// </summary>
        public async ValueTask<AdminUsersSessionInvalidateResponse> AdminUsersSessionInvalidateAsync(AdminUsersSessionInvalidateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsersSessionInvalidateParameter, AdminUsersSessionInvalidateResponse>(parameter, cancellationToken);
        }
    }
}
