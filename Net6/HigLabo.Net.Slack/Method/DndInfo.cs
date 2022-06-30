
namespace HigLabo.Net.Slack
{
    public partial class DndInfoParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "dnd.info";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Team_Id { get; set; }
        public string User { get; set; }
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
