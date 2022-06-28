
namespace HigLabo.Net.Slack
{
    public class OpenidConnectTokenParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "openid.connect.token";
        public string HttpMethod { get; private set; } = "POST";
        public string Client_Id { get; set; } = "";
        public string Client_Secret { get; set; } = "";
        public string Code { get; set; } = "";
        public string Grant_Type { get; set; } = "";
        public string Redirect_Uri { get; set; } = "";
        public string Refresh_Token { get; set; } = "";
    }
    public partial class OpenidConnectTokenResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<OpenidConnectTokenResponse> OpenidConnectTokenAsync()
        {
            var p = new OpenidConnectTokenParameter();
            return await this.SendAsync<OpenidConnectTokenParameter, OpenidConnectTokenResponse>(p, CancellationToken.None);
        }
        public async Task<OpenidConnectTokenResponse> OpenidConnectTokenAsync(CancellationToken cancellationToken)
        {
            var p = new OpenidConnectTokenParameter();
            return await this.SendAsync<OpenidConnectTokenParameter, OpenidConnectTokenResponse>(p, cancellationToken);
        }
        public async Task<OpenidConnectTokenResponse> OpenidConnectTokenAsync(OpenidConnectTokenParameter parameter)
        {
            return await this.SendAsync<OpenidConnectTokenParameter, OpenidConnectTokenResponse>(parameter, CancellationToken.None);
        }
        public async Task<OpenidConnectTokenResponse> OpenidConnectTokenAsync(OpenidConnectTokenParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OpenidConnectTokenParameter, OpenidConnectTokenResponse>(parameter, cancellationToken);
        }
    }
}
