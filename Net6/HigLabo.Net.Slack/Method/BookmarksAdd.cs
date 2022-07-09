using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class BookmarksAddParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "bookmarks.add";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Channel_Id { get; set; }
        public string? Title { get; set; }
        public string? Type { get; set; }
        public string? Emoji { get; set; }
        public string? Entity_Id { get; set; }
        public string? Link { get; set; }
        public string? Parent_Id { get; set; }
    }
    public partial class BookmarksAddResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/bookmarks.add
        /// </summary>
        public async Task<BookmarksAddResponse> BookmarksAddAsync(string? channel_Id, string? title, string? type)
        {
            var p = new BookmarksAddParameter();
            p.Channel_Id = channel_Id;
            p.Title = title;
            p.Type = type;
            return await this.SendAsync<BookmarksAddParameter, BookmarksAddResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/bookmarks.add
        /// </summary>
        public async Task<BookmarksAddResponse> BookmarksAddAsync(string? channel_Id, string? title, string? type, CancellationToken cancellationToken)
        {
            var p = new BookmarksAddParameter();
            p.Channel_Id = channel_Id;
            p.Title = title;
            p.Type = type;
            return await this.SendAsync<BookmarksAddParameter, BookmarksAddResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/bookmarks.add
        /// </summary>
        public async Task<BookmarksAddResponse> BookmarksAddAsync(BookmarksAddParameter parameter)
        {
            return await this.SendAsync<BookmarksAddParameter, BookmarksAddResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/bookmarks.add
        /// </summary>
        public async Task<BookmarksAddResponse> BookmarksAddAsync(BookmarksAddParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookmarksAddParameter, BookmarksAddResponse>(parameter, cancellationToken);
        }
    }
}
