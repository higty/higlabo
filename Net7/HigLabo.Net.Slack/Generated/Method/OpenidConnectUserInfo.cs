using HigLabo.Net.OAuth;

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
    /// <summary>
    /// https://api.slack.com/methods/openid.connect.userInfo
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/openid.connect.userInfo
        /// </summary>
        public async ValueTask<OpenidConnectUserInfoResponse> OpenidConnectUserInfoAsync()
        {
            var p = new OpenidConnectUserInfoParameter();
            return await this.SendAsync<OpenidConnectUserInfoParameter, OpenidConnectUserInfoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/openid.connect.userInfo
        /// </summary>
        public async ValueTask<OpenidConnectUserInfoResponse> OpenidConnectUserInfoAsync(CancellationToken cancellationToken)
        {
            var p = new OpenidConnectUserInfoParameter();
            return await this.SendAsync<OpenidConnectUserInfoParameter, OpenidConnectUserInfoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/openid.connect.userInfo
        /// </summary>
        public async ValueTask<OpenidConnectUserInfoResponse> OpenidConnectUserInfoAsync(OpenidConnectUserInfoParameter parameter)
        {
            return await this.SendAsync<OpenidConnectUserInfoParameter, OpenidConnectUserInfoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/openid.connect.userInfo
        /// </summary>
        public async ValueTask<OpenidConnectUserInfoResponse> OpenidConnectUserInfoAsync(OpenidConnectUserInfoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OpenidConnectUserInfoParameter, OpenidConnectUserInfoResponse>(parameter, cancellationToken);
        }
    }
}
