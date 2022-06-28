
namespace HigLabo.Net.Slack
{
    public class BookmarksAddParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "bookmarks.add";
        public string HttpMethod { get; private set; } = "POST";
        public string Channel_Id { get; set; } = "";
        public string Title { get; set; } = "";
        public string Type { get; set; } = "";
        public string Emoji { get; set; } = "";
        public string Entity_Id { get; set; } = "";
        public string Link { get; set; } = "";
        public string Parent_Id { get; set; } = "";
    }
    public partial class BookmarksAddResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<BookmarksAddResponse> BookmarksAddAsync(string channel_Id, string title, string type)
        {
            var p = new BookmarksAddParameter();
            p.Channel_Id = channel_Id;
            p.Title = title;
            p.Type = type;
            return await this.SendAsync<BookmarksAddParameter, BookmarksAddResponse>(p, CancellationToken.None);
        }
        public async Task<BookmarksAddResponse> BookmarksAddAsync(string channel_Id, string title, string type, CancellationToken cancellationToken)
        {
            var p = new BookmarksAddParameter();
            p.Channel_Id = channel_Id;
            p.Title = title;
            p.Type = type;
            return await this.SendAsync<BookmarksAddParameter, BookmarksAddResponse>(p, cancellationToken);
        }
        public async Task<BookmarksAddResponse> BookmarksAddAsync(BookmarksAddParameter parameter)
        {
            return await this.SendAsync<BookmarksAddParameter, BookmarksAddResponse>(parameter, CancellationToken.None);
        }
        public async Task<BookmarksAddResponse> BookmarksAddAsync(BookmarksAddParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookmarksAddParameter, BookmarksAddResponse>(parameter, cancellationToken);
        }
    }
}
