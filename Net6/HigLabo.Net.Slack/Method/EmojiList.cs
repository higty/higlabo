
namespace HigLabo.Net.Slack
{
    public partial class EmojiListParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "emoji.list";
        string IRestApiParameter.HttpMethod { get; } = "GET";
    }
    public partial class EmojiListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/emoji.list
        /// </summary>
        public async Task<EmojiListResponse> EmojiListAsync()
        {
            var p = new EmojiListParameter();
            return await this.SendAsync<EmojiListParameter, EmojiListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/emoji.list
        /// </summary>
        public async Task<EmojiListResponse> EmojiListAsync(CancellationToken cancellationToken)
        {
            var p = new EmojiListParameter();
            return await this.SendAsync<EmojiListParameter, EmojiListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/emoji.list
        /// </summary>
        public async Task<EmojiListResponse> EmojiListAsync(EmojiListParameter parameter)
        {
            return await this.SendAsync<EmojiListParameter, EmojiListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/emoji.list
        /// </summary>
        public async Task<EmojiListResponse> EmojiListAsync(EmojiListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EmojiListParameter, EmojiListResponse>(parameter, cancellationToken);
        }
    }
}
