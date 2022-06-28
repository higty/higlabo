
namespace HigLabo.Net.Slack
{
    public class UsersLookupByEmailParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "users.lookupByEmail";
        public string HttpMethod { get; private set; } = "GET";
        public string Email { get; set; } = "";
    }
    public partial class UsersLookupByEmailResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<UsersLookupByEmailResponse> UsersLookupByEmailAsync(string email)
        {
            var p = new UsersLookupByEmailParameter();
            p.Email = email;
            return await this.SendAsync<UsersLookupByEmailParameter, UsersLookupByEmailResponse>(p, CancellationToken.None);
        }
        public async Task<UsersLookupByEmailResponse> UsersLookupByEmailAsync(string email, CancellationToken cancellationToken)
        {
            var p = new UsersLookupByEmailParameter();
            p.Email = email;
            return await this.SendAsync<UsersLookupByEmailParameter, UsersLookupByEmailResponse>(p, cancellationToken);
        }
        public async Task<UsersLookupByEmailResponse> UsersLookupByEmailAsync(UsersLookupByEmailParameter parameter)
        {
            return await this.SendAsync<UsersLookupByEmailParameter, UsersLookupByEmailResponse>(parameter, CancellationToken.None);
        }
        public async Task<UsersLookupByEmailResponse> UsersLookupByEmailAsync(UsersLookupByEmailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UsersLookupByEmailParameter, UsersLookupByEmailResponse>(parameter, cancellationToken);
        }
    }
}
