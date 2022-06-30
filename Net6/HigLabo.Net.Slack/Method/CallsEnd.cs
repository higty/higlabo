
namespace HigLabo.Net.Slack
{
    public partial class CallsEndParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "calls.end";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
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
