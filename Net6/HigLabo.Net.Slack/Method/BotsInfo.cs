
namespace HigLabo.Net.Slack
{
    public class BotsInfoParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "bots.info";
        public string HttpMethod { get; private set; } = "GET";
        public string Bot { get; set; } = "";
        public string Team_Id { get; set; } = "";
    }
    public partial class BotsInfoResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<BotsInfoResponse> BotsInfoAsync()
        {
            var p = new BotsInfoParameter();
            return await this.SendAsync<BotsInfoParameter, BotsInfoResponse>(p, CancellationToken.None);
        }
        public async Task<BotsInfoResponse> BotsInfoAsync(CancellationToken cancellationToken)
        {
            var p = new BotsInfoParameter();
            return await this.SendAsync<BotsInfoParameter, BotsInfoResponse>(p, cancellationToken);
        }
        public async Task<BotsInfoResponse> BotsInfoAsync(BotsInfoParameter parameter)
        {
            return await this.SendAsync<BotsInfoParameter, BotsInfoResponse>(parameter, CancellationToken.None);
        }
        public async Task<BotsInfoResponse> BotsInfoAsync(BotsInfoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BotsInfoParameter, BotsInfoResponse>(parameter, cancellationToken);
        }
    }
}
