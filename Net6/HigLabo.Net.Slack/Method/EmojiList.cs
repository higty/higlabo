
namespace HigLabo.Net.Slack
{
    public class EmojiListParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "emoji.list";
        public string HttpMethod { get; private set; } = "GET";
    }
    public partial class EmojiListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<EmojiListResponse> EmojiListAsync()
        {
            var p = new EmojiListParameter();
            return await this.SendAsync<EmojiListParameter, EmojiListResponse>(p, CancellationToken.None);
        }
        public async Task<EmojiListResponse> EmojiListAsync(CancellationToken cancellationToken)
        {
            var p = new EmojiListParameter();
            return await this.SendAsync<EmojiListParameter, EmojiListResponse>(p, cancellationToken);
        }
        public async Task<EmojiListResponse> EmojiListAsync(EmojiListParameter parameter)
        {
            return await this.SendAsync<EmojiListParameter, EmojiListResponse>(parameter, CancellationToken.None);
        }
        public async Task<EmojiListResponse> EmojiListAsync(EmojiListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EmojiListParameter, EmojiListResponse>(parameter, cancellationToken);
        }
    }
}
