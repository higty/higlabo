
namespace HigLabo.Net.Slack
{
    public class StarsRemoveParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "stars.remove";
        public string HttpMethod { get; private set; } = "POST";
        public string Channel { get; set; } = "";
        public string File { get; set; } = "";
        public string File_Comment { get; set; } = "";
        public string Timestamp { get; set; } = "";
    }
    public partial class StarsRemoveResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<StarsRemoveResponse> StarsRemoveAsync()
        {
            var p = new StarsRemoveParameter();
            return await this.SendAsync<StarsRemoveParameter, StarsRemoveResponse>(p, CancellationToken.None);
        }
        public async Task<StarsRemoveResponse> StarsRemoveAsync(CancellationToken cancellationToken)
        {
            var p = new StarsRemoveParameter();
            return await this.SendAsync<StarsRemoveParameter, StarsRemoveResponse>(p, cancellationToken);
        }
        public async Task<StarsRemoveResponse> StarsRemoveAsync(StarsRemoveParameter parameter)
        {
            return await this.SendAsync<StarsRemoveParameter, StarsRemoveResponse>(parameter, CancellationToken.None);
        }
        public async Task<StarsRemoveResponse> StarsRemoveAsync(StarsRemoveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<StarsRemoveParameter, StarsRemoveResponse>(parameter, cancellationToken);
        }
    }
}
