
namespace HigLabo.Net.Slack
{
    public partial class UsersSetActiveParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "users.setActive";
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class UsersSetActiveResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<UsersSetActiveResponse> UsersSetActiveAsync()
        {
            var p = new UsersSetActiveParameter();
            return await this.SendAsync<UsersSetActiveParameter, UsersSetActiveResponse>(p, CancellationToken.None);
        }
        public async Task<UsersSetActiveResponse> UsersSetActiveAsync(CancellationToken cancellationToken)
        {
            var p = new UsersSetActiveParameter();
            return await this.SendAsync<UsersSetActiveParameter, UsersSetActiveResponse>(p, cancellationToken);
        }
        public async Task<UsersSetActiveResponse> UsersSetActiveAsync(UsersSetActiveParameter parameter)
        {
            return await this.SendAsync<UsersSetActiveParameter, UsersSetActiveResponse>(parameter, CancellationToken.None);
        }
        public async Task<UsersSetActiveResponse> UsersSetActiveAsync(UsersSetActiveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UsersSetActiveParameter, UsersSetActiveResponse>(parameter, cancellationToken);
        }
    }
}
