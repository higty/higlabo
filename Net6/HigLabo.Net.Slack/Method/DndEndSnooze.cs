
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
        public async Task<DndEndSnoozeResponse> DndEndSnoozeAsync()
        {
            var p = new DndEndSnoozeParameter();
            return await this.SendAsync<DndEndSnoozeParameter, DndEndSnoozeResponse>(p, CancellationToken.None);
        }
        public async Task<DndEndSnoozeResponse> DndEndSnoozeAsync(CancellationToken cancellationToken)
        {
            var p = new DndEndSnoozeParameter();
            return await this.SendAsync<DndEndSnoozeParameter, DndEndSnoozeResponse>(p, cancellationToken);
        }
        public async Task<DndEndSnoozeResponse> DndEndSnoozeAsync(DndEndSnoozeParameter parameter)
        {
            return await this.SendAsync<DndEndSnoozeParameter, DndEndSnoozeResponse>(parameter, CancellationToken.None);
        }
        public async Task<DndEndSnoozeResponse> DndEndSnoozeAsync(DndEndSnoozeParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DndEndSnoozeParameter, DndEndSnoozeResponse>(parameter, cancellationToken);
        }
    }
}
