
namespace HigLabo.Net.Slack
{
    public class DndSetSnoozeParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "dnd.setSnooze";
        public string HttpMethod { get; private set; } = "GET";
        public string Num_Minutes { get; set; } = "";
    }
    public partial class DndSetSnoozeResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<DndSetSnoozeResponse> DndSetSnoozeAsync()
        {
            var p = new DndSetSnoozeParameter();
            return await this.SendAsync<DndSetSnoozeParameter, DndSetSnoozeResponse>(p, CancellationToken.None);
        }
        public async Task<DndSetSnoozeResponse> DndSetSnoozeAsync(CancellationToken cancellationToken)
        {
            var p = new DndSetSnoozeParameter();
            return await this.SendAsync<DndSetSnoozeParameter, DndSetSnoozeResponse>(p, cancellationToken);
        }
        public async Task<DndSetSnoozeResponse> DndSetSnoozeAsync(DndSetSnoozeParameter parameter)
        {
            return await this.SendAsync<DndSetSnoozeParameter, DndSetSnoozeResponse>(parameter, CancellationToken.None);
        }
        public async Task<DndSetSnoozeResponse> DndSetSnoozeAsync(DndSetSnoozeParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DndSetSnoozeParameter, DndSetSnoozeResponse>(parameter, cancellationToken);
        }
    }
}
