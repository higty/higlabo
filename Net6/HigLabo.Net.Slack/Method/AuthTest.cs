
namespace HigLabo.Net.Slack
{
    public partial class AuthTestParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "auth.test";
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class AuthTestResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AuthTestResponse> AuthTestAsync()
        {
            var p = new AuthTestParameter();
            return await this.SendAsync<AuthTestParameter, AuthTestResponse>(p, CancellationToken.None);
        }
        public async Task<AuthTestResponse> AuthTestAsync(CancellationToken cancellationToken)
        {
            var p = new AuthTestParameter();
            return await this.SendAsync<AuthTestParameter, AuthTestResponse>(p, cancellationToken);
        }
        public async Task<AuthTestResponse> AuthTestAsync(AuthTestParameter parameter)
        {
            return await this.SendAsync<AuthTestParameter, AuthTestResponse>(parameter, CancellationToken.None);
        }
        public async Task<AuthTestResponse> AuthTestAsync(AuthTestParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthTestParameter, AuthTestResponse>(parameter, cancellationToken);
        }
    }
}
