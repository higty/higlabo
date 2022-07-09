using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class CallsInfoParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "calls.info";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
    }
    public partial class CallsInfoResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/calls.info
        /// </summary>
        public async Task<CallsInfoResponse> CallsInfoAsync(string? id)
        {
            var p = new CallsInfoParameter();
            p.Id = id;
            return await this.SendAsync<CallsInfoParameter, CallsInfoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/calls.info
        /// </summary>
        public async Task<CallsInfoResponse> CallsInfoAsync(string? id, CancellationToken cancellationToken)
        {
            var p = new CallsInfoParameter();
            p.Id = id;
            return await this.SendAsync<CallsInfoParameter, CallsInfoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/calls.info
        /// </summary>
        public async Task<CallsInfoResponse> CallsInfoAsync(CallsInfoParameter parameter)
        {
            return await this.SendAsync<CallsInfoParameter, CallsInfoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/calls.info
        /// </summary>
        public async Task<CallsInfoResponse> CallsInfoAsync(CallsInfoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallsInfoParameter, CallsInfoResponse>(parameter, cancellationToken);
        }
    }
}
