
namespace HigLabo.Net.Slack
{
    public class CallsEndParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "calls.end";
        public string HttpMethod { get; private set; } = "POST";
        public string Id { get; set; } = "";
        public int? Duration { get; set; }
    }
    public partial class CallsEndResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<CallsEndResponse> CallsEndAsync(string id)
        {
            var p = new CallsEndParameter();
            p.Id = id;
            return await this.SendAsync<CallsEndParameter, CallsEndResponse>(p, CancellationToken.None);
        }
        public async Task<CallsEndResponse> CallsEndAsync(string id, CancellationToken cancellationToken)
        {
            var p = new CallsEndParameter();
            p.Id = id;
            return await this.SendAsync<CallsEndParameter, CallsEndResponse>(p, cancellationToken);
        }
        public async Task<CallsEndResponse> CallsEndAsync(CallsEndParameter parameter)
        {
            return await this.SendAsync<CallsEndParameter, CallsEndResponse>(parameter, CancellationToken.None);
        }
        public async Task<CallsEndResponse> CallsEndAsync(CallsEndParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallsEndParameter, CallsEndResponse>(parameter, cancellationToken);
        }
    }
}
