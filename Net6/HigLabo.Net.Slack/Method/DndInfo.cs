
namespace HigLabo.Net.Slack
{
    public class DndInfoParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "dnd.info";
        public string HttpMethod { get; private set; } = "GET";
        public string Team_Id { get; set; } = "";
        public string User { get; set; } = "";
    }
    public partial class DndInfoResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<DndInfoResponse> DndInfoAsync()
        {
            var p = new DndInfoParameter();
            return await this.SendAsync<DndInfoParameter, DndInfoResponse>(p, CancellationToken.None);
        }
        public async Task<DndInfoResponse> DndInfoAsync(CancellationToken cancellationToken)
        {
            var p = new DndInfoParameter();
            return await this.SendAsync<DndInfoParameter, DndInfoResponse>(p, cancellationToken);
        }
        public async Task<DndInfoResponse> DndInfoAsync(DndInfoParameter parameter)
        {
            return await this.SendAsync<DndInfoParameter, DndInfoResponse>(parameter, CancellationToken.None);
        }
        public async Task<DndInfoResponse> DndInfoAsync(DndInfoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DndInfoParameter, DndInfoResponse>(parameter, cancellationToken);
        }
    }
}
