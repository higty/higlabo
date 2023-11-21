using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/oauth.v2.exchange
    /// </summary>
    public partial class OauthV2ExchangeParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "oauth.v2.exchange";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string? Client_Id { get; set; }
        public string? Client_Secret { get; set; }
    }
    public partial class OauthV2ExchangeResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/oauth.v2.exchange
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/oauth.v2.exchange
        /// </summary>
        public async ValueTask<OauthV2ExchangeResponse> OauthV2ExchangeAsync(string? client_Id, string? client_Secret)
        {
            var p = new OauthV2ExchangeParameter();
            p.Client_Id = client_Id;
            p.Client_Secret = client_Secret;
            return await this.SendAsync<OauthV2ExchangeParameter, OauthV2ExchangeResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/oauth.v2.exchange
        /// </summary>
        public async ValueTask<OauthV2ExchangeResponse> OauthV2ExchangeAsync(string? client_Id, string? client_Secret, CancellationToken cancellationToken)
        {
            var p = new OauthV2ExchangeParameter();
            p.Client_Id = client_Id;
            p.Client_Secret = client_Secret;
            return await this.SendAsync<OauthV2ExchangeParameter, OauthV2ExchangeResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/oauth.v2.exchange
        /// </summary>
        public async ValueTask<OauthV2ExchangeResponse> OauthV2ExchangeAsync(OauthV2ExchangeParameter parameter)
        {
            return await this.SendAsync<OauthV2ExchangeParameter, OauthV2ExchangeResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/oauth.v2.exchange
        /// </summary>
        public async ValueTask<OauthV2ExchangeResponse> OauthV2ExchangeAsync(OauthV2ExchangeParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OauthV2ExchangeParameter, OauthV2ExchangeResponse>(parameter, cancellationToken);
        }
    }
}
