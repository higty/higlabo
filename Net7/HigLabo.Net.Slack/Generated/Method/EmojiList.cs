using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/emoji.list
    /// </summary>
    public partial class EmojiListParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "emoji.list";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public bool? Include_Categories { get; set; }
    }
    public partial class EmojiListResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/emoji.list
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/emoji.list
        /// </summary>
        public async ValueTask<EmojiListResponse> EmojiListAsync()
        {
            var p = new EmojiListParameter();
            return await this.SendAsync<EmojiListParameter, EmojiListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/emoji.list
        /// </summary>
        public async ValueTask<EmojiListResponse> EmojiListAsync(CancellationToken cancellationToken)
        {
            var p = new EmojiListParameter();
            return await this.SendAsync<EmojiListParameter, EmojiListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/emoji.list
        /// </summary>
        public async ValueTask<EmojiListResponse> EmojiListAsync(EmojiListParameter parameter)
        {
            return await this.SendAsync<EmojiListParameter, EmojiListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/emoji.list
        /// </summary>
        public async ValueTask<EmojiListResponse> EmojiListAsync(EmojiListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EmojiListParameter, EmojiListResponse>(parameter, cancellationToken);
        }
    }
}
