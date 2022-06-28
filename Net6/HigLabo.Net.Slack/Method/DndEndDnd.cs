
namespace HigLabo.Net.Slack
{
    public class DndEndDndParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "dnd.endDnd";
        public string HttpMethod { get; private set; } = "POST";
    }
    public partial class DndEndDndResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<DndEndDndResponse> DndEndDndAsync()
        {
            var p = new DndEndDndParameter();
            return await this.SendAsync<DndEndDndParameter, DndEndDndResponse>(p, CancellationToken.None);
        }
        public async Task<DndEndDndResponse> DndEndDndAsync(CancellationToken cancellationToken)
        {
            var p = new DndEndDndParameter();
            return await this.SendAsync<DndEndDndParameter, DndEndDndResponse>(p, cancellationToken);
        }
        public async Task<DndEndDndResponse> DndEndDndAsync(DndEndDndParameter parameter)
        {
            return await this.SendAsync<DndEndDndParameter, DndEndDndResponse>(parameter, CancellationToken.None);
        }
        public async Task<DndEndDndResponse> DndEndDndAsync(DndEndDndParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DndEndDndParameter, DndEndDndResponse>(parameter, cancellationToken);
        }
    }
}
