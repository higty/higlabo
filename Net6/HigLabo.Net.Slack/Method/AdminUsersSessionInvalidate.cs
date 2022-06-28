
namespace HigLabo.Net.Slack
{
    public class AdminUsersSessionInvalidateParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.users.session.invalidate";
        public string HttpMethod { get; private set; } = "POST";
        public int Session_Id { get; set; }
        public string Team_Id { get; set; } = "";
    }
    public partial class AdminUsersSessionInvalidateResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminUsersSessionInvalidateResponse> AdminUsersSessionInvalidateAsync(int session_Id, string team_Id)
        {
            var p = new AdminUsersSessionInvalidateParameter();
            p.Session_Id = session_Id;
            p.Team_Id = team_Id;
            return await this.SendAsync<AdminUsersSessionInvalidateParameter, AdminUsersSessionInvalidateResponse>(p, CancellationToken.None);
        }
        public async Task<AdminUsersSessionInvalidateResponse> AdminUsersSessionInvalidateAsync(int session_Id, string team_Id, CancellationToken cancellationToken)
        {
            var p = new AdminUsersSessionInvalidateParameter();
            p.Session_Id = session_Id;
            p.Team_Id = team_Id;
            return await this.SendAsync<AdminUsersSessionInvalidateParameter, AdminUsersSessionInvalidateResponse>(p, cancellationToken);
        }
        public async Task<AdminUsersSessionInvalidateResponse> AdminUsersSessionInvalidateAsync(AdminUsersSessionInvalidateParameter parameter)
        {
            return await this.SendAsync<AdminUsersSessionInvalidateParameter, AdminUsersSessionInvalidateResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminUsersSessionInvalidateResponse> AdminUsersSessionInvalidateAsync(AdminUsersSessionInvalidateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsersSessionInvalidateParameter, AdminUsersSessionInvalidateResponse>(parameter, cancellationToken);
        }
    }
}
