
namespace HigLabo.Net.Slack
{
    public class OauthV2ExchangeParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "oauth.v2.exchange";
        public string HttpMethod { get; private set; } = "GET";
        public string Client_Id { get; set; } = "";
        public string Client_Secret { get; set; } = "";
    }
    public partial class OauthV2ExchangeResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<OauthV2ExchangeResponse> OauthV2ExchangeAsync(string client_Id, string client_Secret)
        {
            var p = new OauthV2ExchangeParameter();
            p.Client_Id = client_Id;
            p.Client_Secret = client_Secret;
            return await this.SendAsync<OauthV2ExchangeParameter, OauthV2ExchangeResponse>(p, CancellationToken.None);
        }
        public async Task<OauthV2ExchangeResponse> OauthV2ExchangeAsync(string client_Id, string client_Secret, CancellationToken cancellationToken)
        {
            var p = new OauthV2ExchangeParameter();
            p.Client_Id = client_Id;
            p.Client_Secret = client_Secret;
            return await this.SendAsync<OauthV2ExchangeParameter, OauthV2ExchangeResponse>(p, cancellationToken);
        }
        public async Task<OauthV2ExchangeResponse> OauthV2ExchangeAsync(OauthV2ExchangeParameter parameter)
        {
            return await this.SendAsync<OauthV2ExchangeParameter, OauthV2ExchangeResponse>(parameter, CancellationToken.None);
        }
        public async Task<OauthV2ExchangeResponse> OauthV2ExchangeAsync(OauthV2ExchangeParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OauthV2ExchangeParameter, OauthV2ExchangeResponse>(parameter, cancellationToken);
        }
    }
}
