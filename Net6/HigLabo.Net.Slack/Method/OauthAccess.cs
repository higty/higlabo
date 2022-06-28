
namespace HigLabo.Net.Slack
{
    public class OauthAccessParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "oauth.access";
        public string HttpMethod { get; private set; } = "POST";
        public string Client_Id { get; set; } = "";
        public string Client_Secret { get; set; } = "";
        public string Code { get; set; } = "";
        public string Redirect_Uri { get; set; } = "";
        public bool? Single_Channel { get; set; }
    }
    public partial class OauthAccessResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<OauthAccessResponse> OauthAccessAsync()
        {
            var p = new OauthAccessParameter();
            return await this.SendAsync<OauthAccessParameter, OauthAccessResponse>(p, CancellationToken.None);
        }
        public async Task<OauthAccessResponse> OauthAccessAsync(CancellationToken cancellationToken)
        {
            var p = new OauthAccessParameter();
            return await this.SendAsync<OauthAccessParameter, OauthAccessResponse>(p, cancellationToken);
        }
        public async Task<OauthAccessResponse> OauthAccessAsync(OauthAccessParameter parameter)
        {
            return await this.SendAsync<OauthAccessParameter, OauthAccessResponse>(parameter, CancellationToken.None);
        }
        public async Task<OauthAccessResponse> OauthAccessAsync(OauthAccessParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OauthAccessParameter, OauthAccessResponse>(parameter, cancellationToken);
        }
    }
}
