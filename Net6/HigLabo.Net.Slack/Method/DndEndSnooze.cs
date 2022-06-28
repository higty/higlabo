
namespace HigLabo.Net.Slack
{
    public class DndEndSnoozeParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "dnd.endSnooze";
        public string HttpMethod { get; private set; } = "POST";
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
