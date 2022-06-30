
namespace HigLabo.Net.Slack
{
    public partial class ReactionsGetParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "reactions.get";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Channel { get; set; }
        public string File { get; set; }
        public string File_Comment { get; set; }
        public bool? Full { get; set; }
        public string Timestamp { get; set; }
    }
    public partial class ReactionsGetResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/reactions.get
        /// </summary>
        public async Task<ReactionsGetResponse> ReactionsGetAsync()
        {
            var p = new ReactionsGetParameter();
            return await this.SendAsync<ReactionsGetParameter, ReactionsGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/reactions.get
        /// </summary>
        public async Task<ReactionsGetResponse> ReactionsGetAsync(CancellationToken cancellationToken)
        {
            var p = new ReactionsGetParameter();
            return await this.SendAsync<ReactionsGetParameter, ReactionsGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/reactions.get
        /// </summary>
        public async Task<ReactionsGetResponse> ReactionsGetAsync(ReactionsGetParameter parameter)
        {
            return await this.SendAsync<ReactionsGetParameter, ReactionsGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/reactions.get
        /// </summary>
        public async Task<ReactionsGetResponse> ReactionsGetAsync(ReactionsGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReactionsGetParameter, ReactionsGetResponse>(parameter, cancellationToken);
        }
    }
}
