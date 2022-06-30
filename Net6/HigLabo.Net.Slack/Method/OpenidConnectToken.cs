
namespace HigLabo.Net.Slack
{
    public partial class OpenidConnectTokenParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "openid.connect.token";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Client_Id { get; set; }
        public string Client_Secret { get; set; }
        public string Code { get; set; }
        public string Grant_Type { get; set; }
        public string Redirect_Uri { get; set; }
        public string Refresh_Token { get; set; }
    }
    public partial class OpenidConnectTokenResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/openid.connect.token
        /// </summary>
        public async Task<OpenidConnectTokenResponse> OpenidConnectTokenAsync()
        {
            var p = new OpenidConnectTokenParameter();
            return await this.SendAsync<OpenidConnectTokenParameter, OpenidConnectTokenResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/openid.connect.token
        /// </summary>
        public async Task<OpenidConnectTokenResponse> OpenidConnectTokenAsync(CancellationToken cancellationToken)
        {
            var p = new OpenidConnectTokenParameter();
            return await this.SendAsync<OpenidConnectTokenParameter, OpenidConnectTokenResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/openid.connect.token
        /// </summary>
        public async Task<OpenidConnectTokenResponse> OpenidConnectTokenAsync(OpenidConnectTokenParameter parameter)
        {
            return await this.SendAsync<OpenidConnectTokenParameter, OpenidConnectTokenResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/openid.connect.token
        /// </summary>
        public async Task<OpenidConnectTokenResponse> OpenidConnectTokenAsync(OpenidConnectTokenParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OpenidConnectTokenParameter, OpenidConnectTokenResponse>(parameter, cancellationToken);
        }
    }
}
