using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class UsersBookmarksParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Id { get; set; } = "";
    public int? Max_Results { get; set; }
    public string Pagination_Token { get; set; } = "";
    public string Expansions { get; set; } = "";
    public string Tweet_Fields { get; set; } = "";
    public string User_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/users/{this.Id}/bookmarks";
    }
    Dictionary<string, string> IQueryParameterProperty.CreateQueryParameter()
    {
        var d = new Dictionary<string, string>();
        QueryParameterBuilder.AddValue(d, "max_results", this.Max_Results);
        QueryParameterBuilder.Add(d, "pagination_token", this.Pagination_Token);
        QueryParameterBuilder.Add(d, "expansions", this.Expansions);
        QueryParameterBuilder.Add(d, "tweet.fields", this.Tweet_Fields);
        QueryParameterBuilder.Add(d, "user.fields", this.User_Fields);
        return d;
    }
    public override object GetRequestBody()
    {
        return EmptyParameter;
    }
}
public partial class UsersBookmarksResponse : XApiResult<List<XTweet>>
{
}
public partial class XClient
{
    public async ValueTask<UsersBookmarksResponse> UsersBookmarksAsync(string id)
    {
        var p = new UsersBookmarksParameter();
        p.Id = id;
        return await this.SendJsonAsync<UsersBookmarksParameter, UsersBookmarksResponse>(p);
    }
    public async ValueTask<UsersBookmarksResponse> UsersBookmarksAsync(string id, CancellationToken cancellationToken)
    {
        var p = new UsersBookmarksParameter();
        p.Id = id;
        return await this.SendJsonAsync<UsersBookmarksParameter, UsersBookmarksResponse>(p, cancellationToken);
    }
    public async ValueTask<UsersBookmarksResponse> UsersBookmarksAsync(UsersBookmarksParameter parameter)
    {
        return await this.SendJsonAsync<UsersBookmarksParameter, UsersBookmarksResponse>(parameter);
    }
    public async ValueTask<UsersBookmarksResponse> UsersBookmarksAsync(UsersBookmarksParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<UsersBookmarksParameter, UsersBookmarksResponse>(parameter, cancellationToken);
    }
}
