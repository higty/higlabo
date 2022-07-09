using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class OauthV2AccessParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "oauth.v2.access";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Client_Id { get; set; }
        public string? Client_Secret { get; set; }
        public string? Code { get; set; }
        public string? Grant_Type { get; set; }
        public string? Redirect_Uri { get; set; }
        public string? Refresh_Token { get; set; }
    }
    public partial class OauthV2AccessResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/oauth.v2.access
        /// </summary>
        public async Task<OauthV2AccessResponse> OauthV2AccessAsync()
        {
            var p = new OauthV2AccessParameter();
            return await this.SendAsync<OauthV2AccessParameter, OauthV2AccessResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/oauth.v2.access
        /// </summary>
        public async Task<OauthV2AccessResponse> OauthV2AccessAsync(CancellationToken cancellationToken)
        {
            var p = new OauthV2AccessParameter();
            return await this.SendAsync<OauthV2AccessParameter, OauthV2AccessResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/oauth.v2.access
        /// </summary>
        public async Task<OauthV2AccessResponse> OauthV2AccessAsync(OauthV2AccessParameter parameter)
        {
            return await this.SendAsync<OauthV2AccessParameter, OauthV2AccessResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/oauth.v2.access
        /// </summary>
        public async Task<OauthV2AccessResponse> OauthV2AccessAsync(OauthV2AccessParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OauthV2AccessParameter, OauthV2AccessResponse>(parameter, cancellationToken);
        }
    }
}
