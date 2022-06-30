
namespace HigLabo.Net.Slack
{
    public partial class BookmarksEditParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "bookmarks.edit";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Bookmark_Id { get; set; }
        public string Channel_Id { get; set; }
        public string Emoji { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
    }
    public partial class BookmarksEditResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/bookmarks.edit
        /// </summary>
        public async Task<BookmarksEditResponse> BookmarksEditAsync(string bookmark_Id, string channel_Id)
        {
            var p = new BookmarksEditParameter();
            p.Bookmark_Id = bookmark_Id;
            p.Channel_Id = channel_Id;
            return await this.SendAsync<BookmarksEditParameter, BookmarksEditResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/bookmarks.edit
        /// </summary>
        public async Task<BookmarksEditResponse> BookmarksEditAsync(string bookmark_Id, string channel_Id, CancellationToken cancellationToken)
        {
            var p = new BookmarksEditParameter();
            p.Bookmark_Id = bookmark_Id;
            p.Channel_Id = channel_Id;
            return await this.SendAsync<BookmarksEditParameter, BookmarksEditResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/bookmarks.edit
        /// </summary>
        public async Task<BookmarksEditResponse> BookmarksEditAsync(BookmarksEditParameter parameter)
        {
            return await this.SendAsync<BookmarksEditParameter, BookmarksEditResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/bookmarks.edit
        /// </summary>
        public async Task<BookmarksEditResponse> BookmarksEditAsync(BookmarksEditParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookmarksEditParameter, BookmarksEditResponse>(parameter, cancellationToken);
        }
    }
}
