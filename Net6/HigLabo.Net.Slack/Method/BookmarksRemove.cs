
namespace HigLabo.Net.Slack
{
    public class BookmarksRemoveParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "bookmarks.remove";
        public string HttpMethod { get; private set; } = "POST";
        public string Bookmark_Id { get; set; } = "";
        public string Channel_Id { get; set; } = "";
    }
    public partial class BookmarksRemoveResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<BookmarksRemoveResponse> BookmarksRemoveAsync(string bookmark_Id, string channel_Id)
        {
            var p = new BookmarksRemoveParameter();
            p.Bookmark_Id = bookmark_Id;
            p.Channel_Id = channel_Id;
            return await this.SendAsync<BookmarksRemoveParameter, BookmarksRemoveResponse>(p, CancellationToken.None);
        }
        public async Task<BookmarksRemoveResponse> BookmarksRemoveAsync(string bookmark_Id, string channel_Id, CancellationToken cancellationToken)
        {
            var p = new BookmarksRemoveParameter();
            p.Bookmark_Id = bookmark_Id;
            p.Channel_Id = channel_Id;
            return await this.SendAsync<BookmarksRemoveParameter, BookmarksRemoveResponse>(p, cancellationToken);
        }
        public async Task<BookmarksRemoveResponse> BookmarksRemoveAsync(BookmarksRemoveParameter parameter)
        {
            return await this.SendAsync<BookmarksRemoveParameter, BookmarksRemoveResponse>(parameter, CancellationToken.None);
        }
        public async Task<BookmarksRemoveResponse> BookmarksRemoveAsync(BookmarksRemoveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookmarksRemoveParameter, BookmarksRemoveResponse>(parameter, cancellationToken);
        }
    }
}
