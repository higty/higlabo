using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class DndEndSnoozeParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "dnd.endSnooze";
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class DndEndSnoozeResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/dnd.endSnooze
        /// </summary>
        public async Task<DndEndSnoozeResponse> DndEndSnoozeAsync()
        {
            var p = new DndEndSnoozeParameter();
            return await this.SendAsync<DndEndSnoozeParameter, DndEndSnoozeResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/dnd.endSnooze
        /// </summary>
        public async Task<DndEndSnoozeResponse> DndEndSnoozeAsync(CancellationToken cancellationToken)
        {
            var p = new DndEndSnoozeParameter();
            return await this.SendAsync<DndEndSnoozeParameter, DndEndSnoozeResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/dnd.endSnooze
        /// </summary>
        public async Task<DndEndSnoozeResponse> DndEndSnoozeAsync(DndEndSnoozeParameter parameter)
        {
            return await this.SendAsync<DndEndSnoozeParameter, DndEndSnoozeResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/dnd.endSnooze
        /// </summary>
        public async Task<DndEndSnoozeResponse> DndEndSnoozeAsync(DndEndSnoozeParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DndEndSnoozeParameter, DndEndSnoozeResponse>(parameter, cancellationToken);
        }
    }
}
