
namespace HigLabo.Net.Slack
{
    public class AdminUsersSetExpirationParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.users.setExpiration";
        public string HttpMethod { get; private set; } = "POST";
        public int Expiration_Ts { get; set; }
        public string User_Id { get; set; } = "";
        public string Team_Id { get; set; } = "";
    }
    public partial class AdminUsersSetExpirationResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminUsersSetExpirationResponse> AdminUsersSetExpirationAsync(int expiration_Ts, string user_Id)
        {
            var p = new AdminUsersSetExpirationParameter();
            p.Expiration_Ts = expiration_Ts;
            p.User_Id = user_Id;
            return await this.SendAsync<AdminUsersSetExpirationParameter, AdminUsersSetExpirationResponse>(p, CancellationToken.None);
        }
        public async Task<AdminUsersSetExpirationResponse> AdminUsersSetExpirationAsync(int expiration_Ts, string user_Id, CancellationToken cancellationToken)
        {
            var p = new AdminUsersSetExpirationParameter();
            p.Expiration_Ts = expiration_Ts;
            p.User_Id = user_Id;
            return await this.SendAsync<AdminUsersSetExpirationParameter, AdminUsersSetExpirationResponse>(p, cancellationToken);
        }
        public async Task<AdminUsersSetExpirationResponse> AdminUsersSetExpirationAsync(AdminUsersSetExpirationParameter parameter)
        {
            return await this.SendAsync<AdminUsersSetExpirationParameter, AdminUsersSetExpirationResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminUsersSetExpirationResponse> AdminUsersSetExpirationAsync(AdminUsersSetExpirationParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsersSetExpirationParameter, AdminUsersSetExpirationResponse>(parameter, cancellationToken);
        }
    }
}
