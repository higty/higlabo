using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class TweetsLookupParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Ids { get; set; } = "";
    public string Expansions { get; set; } = "";
    public List<TweetField> TweetFieldList { get; init; } = new();
    public string Tweet_Fields { get; set; } = "";
    public List<UserField> UserFieldList { get; init; } = new();
    public string User_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return "/tweets";
    }
    Dictionary<string, string> IQueryParameterProperty.CreateQueryParameter()
    {
        var d = new Dictionary<string, string>();
        QueryParameterBuilder.Add(d, "ids", this.Ids);
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
public partial class TweetsLookupResponse : XApiResult<List<XTweet>>
{
}
public partial class XClient
{
    public async ValueTask<TweetsLookupResponse> TweetsLookupAsync(string ids)
    {
        var p = new TweetsLookupParameter();
        p.Ids = ids;
        return await this.SendJsonAsync<TweetsLookupParameter, TweetsLookupResponse>(p);
    }
    public async ValueTask<TweetsLookupResponse> TweetsLookupAsync(string ids, CancellationToken cancellationToken)
    {
        var p = new TweetsLookupParameter();
        p.Ids = ids;
        return await this.SendJsonAsync<TweetsLookupParameter, TweetsLookupResponse>(p, cancellationToken);
    }
    public async ValueTask<TweetsLookupResponse> TweetsLookupAsync(TweetsLookupParameter parameter)
    {
        return await this.SendJsonAsync<TweetsLookupParameter, TweetsLookupResponse>(parameter);
    }
    public async ValueTask<TweetsLookupResponse> TweetsLookupAsync(TweetsLookupParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<TweetsLookupParameter, TweetsLookupResponse>(parameter, cancellationToken);
    }
}
