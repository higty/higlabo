
namespace HigLabo.Net.Slack
{
    public class AdminUsersSessionGetSettingsParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.users.session.getSettings";
        public string HttpMethod { get; private set; } = "POST";
        public string User_Ids { get; set; } = "";
    }
    public partial class AdminUsersSessionGetSettingsResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminUsersSessionGetSettingsResponse> AdminUsersSessionGetSettingsAsync(string user_Ids)
        {
            var p = new AdminUsersSessionGetSettingsParameter();
            p.User_Ids = user_Ids;
            return await this.SendAsync<AdminUsersSessionGetSettingsParameter, AdminUsersSessionGetSettingsResponse>(p, CancellationToken.None);
        }
        public async Task<AdminUsersSessionGetSettingsResponse> AdminUsersSessionGetSettingsAsync(string user_Ids, CancellationToken cancellationToken)
        {
            var p = new AdminUsersSessionGetSettingsParameter();
            p.User_Ids = user_Ids;
            return await this.SendAsync<AdminUsersSessionGetSettingsParameter, AdminUsersSessionGetSettingsResponse>(p, cancellationToken);
        }
        public async Task<AdminUsersSessionGetSettingsResponse> AdminUsersSessionGetSettingsAsync(AdminUsersSessionGetSettingsParameter parameter)
        {
            return await this.SendAsync<AdminUsersSessionGetSettingsParameter, AdminUsersSessionGetSettingsResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminUsersSessionGetSettingsResponse> AdminUsersSessionGetSettingsAsync(AdminUsersSessionGetSettingsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsersSessionGetSettingsParameter, AdminUsersSessionGetSettingsResponse>(parameter, cancellationToken);
        }
    }
}
