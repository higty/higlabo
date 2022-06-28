
namespace HigLabo.Net.Slack
{
    public class AdminUsersSessionResetParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.users.session.reset";
        public string HttpMethod { get; private set; } = "POST";
        public string User_Id { get; set; } = "";
        public bool? Mobile_Only { get; set; }
        public bool? Web_Only { get; set; }
    }
    public partial class AdminUsersSessionResetResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminUsersSessionResetResponse> AdminUsersSessionResetAsync(string user_Id)
        {
            var p = new AdminUsersSessionResetParameter();
            p.User_Id = user_Id;
            return await this.SendAsync<AdminUsersSessionResetParameter, AdminUsersSessionResetResponse>(p, CancellationToken.None);
        }
        public async Task<AdminUsersSessionResetResponse> AdminUsersSessionResetAsync(string user_Id, CancellationToken cancellationToken)
        {
            var p = new AdminUsersSessionResetParameter();
            p.User_Id = user_Id;
            return await this.SendAsync<AdminUsersSessionResetParameter, AdminUsersSessionResetResponse>(p, cancellationToken);
        }
        public async Task<AdminUsersSessionResetResponse> AdminUsersSessionResetAsync(AdminUsersSessionResetParameter parameter)
        {
            return await this.SendAsync<AdminUsersSessionResetParameter, AdminUsersSessionResetResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminUsersSessionResetResponse> AdminUsersSessionResetAsync(AdminUsersSessionResetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsersSessionResetParameter, AdminUsersSessionResetResponse>(parameter, cancellationToken);
        }
    }
}
