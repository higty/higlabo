
namespace HigLabo.Net.Slack
{
    public class AdminUsersSessionSetSettingsParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.users.session.setSettings";
        public string HttpMethod { get; private set; } = "POST";
        public string User_Ids { get; set; } = "";
        public bool? Desktop_App_Browser_Quit { get; set; }
        public int? Duration { get; set; }
    }
    public partial class AdminUsersSessionSetSettingsResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminUsersSessionSetSettingsResponse> AdminUsersSessionSetSettingsAsync(string user_Ids)
        {
            var p = new AdminUsersSessionSetSettingsParameter();
            p.User_Ids = user_Ids;
            return await this.SendAsync<AdminUsersSessionSetSettingsParameter, AdminUsersSessionSetSettingsResponse>(p, CancellationToken.None);
        }
        public async Task<AdminUsersSessionSetSettingsResponse> AdminUsersSessionSetSettingsAsync(string user_Ids, CancellationToken cancellationToken)
        {
            var p = new AdminUsersSessionSetSettingsParameter();
            p.User_Ids = user_Ids;
            return await this.SendAsync<AdminUsersSessionSetSettingsParameter, AdminUsersSessionSetSettingsResponse>(p, cancellationToken);
        }
        public async Task<AdminUsersSessionSetSettingsResponse> AdminUsersSessionSetSettingsAsync(AdminUsersSessionSetSettingsParameter parameter)
        {
            return await this.SendAsync<AdminUsersSessionSetSettingsParameter, AdminUsersSessionSetSettingsResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminUsersSessionSetSettingsResponse> AdminUsersSessionSetSettingsAsync(AdminUsersSessionSetSettingsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsersSessionSetSettingsParameter, AdminUsersSessionSetSettingsResponse>(parameter, cancellationToken);
        }
    }
}
