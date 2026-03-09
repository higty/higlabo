using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class TweetsQuoteTweetsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
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
        return $"/tweets/{this.Id}/quote_tweets";
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
public partial class TweetsQuoteTweetsResponse : XApiResult<List<XTweet>>
{
}
public partial class XClient
{
    public async ValueTask<TweetsQuoteTweetsResponse> TweetsQuoteTweetsAsync(string id)
    {
        var p = new TweetsQuoteTweetsParameter();
        p.Id = id;
        return await this.SendJsonAsync<TweetsQuoteTweetsParameter, TweetsQuoteTweetsResponse>(p);
    }
    public async ValueTask<TweetsQuoteTweetsResponse> TweetsQuoteTweetsAsync(string id, CancellationToken cancellationToken)
    {
        var p = new TweetsQuoteTweetsParameter();
        p.Id = id;
        return await this.SendJsonAsync<TweetsQuoteTweetsParameter, TweetsQuoteTweetsResponse>(p, cancellationToken);
    }
    public async ValueTask<TweetsQuoteTweetsResponse> TweetsQuoteTweetsAsync(TweetsQuoteTweetsParameter parameter)
    {
        return await this.SendJsonAsync<TweetsQuoteTweetsParameter, TweetsQuoteTweetsResponse>(parameter);
    }
    public async ValueTask<TweetsQuoteTweetsResponse> TweetsQuoteTweetsAsync(TweetsQuoteTweetsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<TweetsQuoteTweetsParameter, TweetsQuoteTweetsResponse>(parameter, cancellationToken);
    }
}
