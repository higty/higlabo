
namespace HigLabo.Net.Slack
{
    public partial class ReactionsRemoveParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "reactions.remove";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Name { get; set; }
        public string Channel { get; set; }
        public string File { get; set; }
        public string File_Comment { get; set; }
        public string Timestamp { get; set; }
    }
    public partial class ReactionsRemoveResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ReactionsRemoveResponse> ReactionsRemoveAsync(string name)
        {
            var p = new ReactionsRemoveParameter();
            p.Name = name;
            return await this.SendAsync<ReactionsRemoveParameter, ReactionsRemoveResponse>(p, CancellationToken.None);
        }
        public async Task<ReactionsRemoveResponse> ReactionsRemoveAsync(string name, CancellationToken cancellationToken)
        {
            var p = new ReactionsRemoveParameter();
            p.Name = name;
            return await this.SendAsync<ReactionsRemoveParameter, ReactionsRemoveResponse>(p, cancellationToken);
        }
        public async Task<ReactionsRemoveResponse> ReactionsRemoveAsync(ReactionsRemoveParameter parameter)
        {
            return await this.SendAsync<ReactionsRemoveParameter, ReactionsRemoveResponse>(parameter, CancellationToken.None);
        }
        public async Task<ReactionsRemoveResponse> ReactionsRemoveAsync(ReactionsRemoveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReactionsRemoveParameter, ReactionsRemoveResponse>(parameter, cancellationToken);
        }
    }
}
