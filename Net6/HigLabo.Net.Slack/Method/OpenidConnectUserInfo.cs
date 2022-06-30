
namespace HigLabo.Net.Slack
{
    public partial class OpenidConnectUserInfoParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "openid.connect.userInfo";
        string IRestApiParameter.HttpMethod { get; } = "GET";
    }
    public partial class OpenidConnectUserInfoResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<OpenidConnectUserInfoResponse> OpenidConnectUserInfoAsync()
        {
            var p = new OpenidConnectUserInfoParameter();
            return await this.SendAsync<OpenidConnectUserInfoParameter, OpenidConnectUserInfoResponse>(p, CancellationToken.None);
        }
        public async Task<OpenidConnectUserInfoResponse> OpenidConnectUserInfoAsync(CancellationToken cancellationToken)
        {
            var p = new OpenidConnectUserInfoParameter();
            return await this.SendAsync<OpenidConnectUserInfoParameter, OpenidConnectUserInfoResponse>(p, cancellationToken);
        }
        public async Task<OpenidConnectUserInfoResponse> OpenidConnectUserInfoAsync(OpenidConnectUserInfoParameter parameter)
        {
            return await this.SendAsync<OpenidConnectUserInfoParameter, OpenidConnectUserInfoResponse>(parameter, CancellationToken.None);
        }
        public async Task<OpenidConnectUserInfoResponse> OpenidConnectUserInfoAsync(OpenidConnectUserInfoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OpenidConnectUserInfoParameter, OpenidConnectUserInfoResponse>(parameter, cancellationToken);
        }
    }
}
