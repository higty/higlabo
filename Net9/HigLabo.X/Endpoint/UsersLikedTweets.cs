using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class UsersLikedTweetsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Id { get; set; } = "";
    public int? Max_Results { get; set; }
    public string Pagination_Token { get; set; } = "";
    public string Expansions { get; set; } = "";
    public List<TweetField> TweetFieldList { get; init; } = new();
    public string Tweet_Fields { get; set; } = "";
    public List<UserField> UserFieldList { get; init; } = new();
    public string User_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/users/{this.Id}/liked_tweets";
    }
    Dictionary<string, string> IQueryParameterProperty.CreateQueryParameter()
    {
        var d = new Dictionary<string, string>();
        QueryParameterBuilder.AddValue(d, "max_results", this.Max_Results);
        QueryParameterBuilder.Add(d, "pagination_token", this.Pagination_Token);
        QueryParameterBuilder.Add(d, "expansions", this.Expansions);
        QueryParameterBuilder.AddField(d, "tweet.fields", this.TweetFieldList, this.Tweet_Fields);
        QueryParameterBuilder.AddField(d, "user.fields", this.UserFieldList, this.User_Fields);
        return d;
    }
    public override object GetRequestBody()
    {
        return EmptyParameter;
    }
}
public partial class UsersLikedTweetsResponse : XApiResult<List<XTweet>>
{
}
public partial class XClient
{
    public async ValueTask<UsersLikedTweetsResponse> UsersLikedTweetsAsync(string id)
    {
        var p = new UsersLikedTweetsParameter();
        p.Id = id;
        return await this.SendJsonAsync<UsersLikedTweetsParameter, UsersLikedTweetsResponse>(p);
    }
    public async ValueTask<UsersLikedTweetsResponse> UsersLikedTweetsAsync(string id, CancellationToken cancellationToken)
    {
        var p = new UsersLikedTweetsParameter();
        p.Id = id;
        return await this.SendJsonAsync<UsersLikedTweetsParameter, UsersLikedTweetsResponse>(p, cancellationToken);
    }
    public async ValueTask<UsersLikedTweetsResponse> UsersLikedTweetsAsync(UsersLikedTweetsParameter parameter)
    {
        return await this.SendJsonAsync<UsersLikedTweetsParameter, UsersLikedTweetsResponse>(parameter);
    }
    public async ValueTask<UsersLikedTweetsResponse> UsersLikedTweetsAsync(UsersLikedTweetsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<UsersLikedTweetsParameter, UsersLikedTweetsResponse>(parameter, cancellationToken);
    }
}
