
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
        /// <summary>
        /// https://api.slack.com/methods/calls.end
        /// </summary>
        public async Task<CallsEndResponse> CallsEndAsync(string id)
        {
            var p = new CallsEndParameter();
            p.Id = id;
            return await this.SendAsync<CallsEndParameter, CallsEndResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/calls.end
        /// </summary>
        public async Task<CallsEndResponse> CallsEndAsync(string id, CancellationToken cancellationToken)
        {
            var p = new CallsEndParameter();
            p.Id = id;
            return await this.SendAsync<CallsEndParameter, CallsEndResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/calls.end
        /// </summary>
        public async Task<CallsEndResponse> CallsEndAsync(CallsEndParameter parameter)
        {
            return await this.SendAsync<CallsEndParameter, CallsEndResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/calls.end
        /// </summary>
        public async Task<CallsEndResponse> CallsEndAsync(CallsEndParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallsEndParameter, CallsEndResponse>(parameter, cancellationToken);
        }
    }
}
