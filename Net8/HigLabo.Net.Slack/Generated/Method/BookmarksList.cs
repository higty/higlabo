using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class BookmarksListParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "bookmarks.list";
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public string? Channel_Id { get; set; }
}
public partial class BookmarksListResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/bookmarks.list
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/bookmarks.list
    /// </summary>
    public async ValueTask<BookmarksListResponse> BookmarksListAsync(string? channel_Id)
    {
        var p = new BookmarksListParameter();
        p.Channel_Id = channel_Id;
        return await this.SendAsync<BookmarksListParameter, BookmarksListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/bookmarks.list
    /// </summary>
    public async ValueTask<BookmarksListResponse> BookmarksListAsync(string? channel_Id, CancellationToken cancellationToken)
    {
        var p = new BookmarksListParameter();
        p.Channel_Id = channel_Id;
        return await this.SendAsync<BookmarksListParameter, BookmarksListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/bookmarks.list
    /// </summary>
    public async ValueTask<BookmarksListResponse> BookmarksListAsync(BookmarksListParameter parameter)
    {
        return await this.SendAsync<BookmarksListParameter, BookmarksListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/bookmarks.list
    /// </summary>
    public async ValueTask<BookmarksListResponse> BookmarksListAsync(BookmarksListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<BookmarksListParameter, BookmarksListResponse>(parameter, cancellationToken);
    }
}
