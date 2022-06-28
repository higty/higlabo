
namespace HigLabo.Net.Slack
{
    public class StarsAddParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "stars.add";
        public string HttpMethod { get; private set; } = "POST";
        public string Channel { get; set; } = "";
        public string File { get; set; } = "";
        public string File_Comment { get; set; } = "";
        public string Timestamp { get; set; } = "";
    }
    public partial class StarsAddResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<StarsAddResponse> StarsAddAsync()
        {
            var p = new StarsAddParameter();
            return await this.SendAsync<StarsAddParameter, StarsAddResponse>(p, CancellationToken.None);
        }
        public async Task<StarsAddResponse> StarsAddAsync(CancellationToken cancellationToken)
        {
            var p = new StarsAddParameter();
            return await this.SendAsync<StarsAddParameter, StarsAddResponse>(p, cancellationToken);
        }
        public async Task<StarsAddResponse> StarsAddAsync(StarsAddParameter parameter)
        {
            return await this.SendAsync<StarsAddParameter, StarsAddResponse>(parameter, CancellationToken.None);
        }
        public async Task<StarsAddResponse> StarsAddAsync(StarsAddParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<StarsAddParameter, StarsAddResponse>(parameter, cancellationToken);
        }
    }
}
