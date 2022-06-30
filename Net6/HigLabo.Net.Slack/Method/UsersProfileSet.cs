
namespace HigLabo.Net.Slack
{
    public partial class UsersProfileSetParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "users.profile.set";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Name { get; set; }
        public string Profile { get; set; }
        public string User { get; set; }
        public string Value { get; set; }
    }
    public partial class UsersProfileSetResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<UsersProfileSetResponse> UsersProfileSetAsync()
        {
            var p = new UsersProfileSetParameter();
            return await this.SendAsync<UsersProfileSetParameter, UsersProfileSetResponse>(p, CancellationToken.None);
        }
        public async Task<UsersProfileSetResponse> UsersProfileSetAsync(CancellationToken cancellationToken)
        {
            var p = new UsersProfileSetParameter();
            return await this.SendAsync<UsersProfileSetParameter, UsersProfileSetResponse>(p, cancellationToken);
        }
        public async Task<UsersProfileSetResponse> UsersProfileSetAsync(UsersProfileSetParameter parameter)
        {
            return await this.SendAsync<UsersProfileSetParameter, UsersProfileSetResponse>(parameter, CancellationToken.None);
        }
        public async Task<UsersProfileSetResponse> UsersProfileSetAsync(UsersProfileSetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UsersProfileSetParameter, UsersProfileSetResponse>(parameter, cancellationToken);
        }
    }
}
