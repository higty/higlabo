using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class TweetsSearchRecentParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Query { get; set; } = "";
    public int? Max_Results { get; set; }
    public string Next_Token { get; set; } = "";
    public string Start_Time { get; set; } = "";
    public string End_Time { get; set; } = "";
    public string Sort_Order { get; set; } = "";
    public string Expansions { get; set; } = "";
    public List<TweetField> TweetFieldList { get; init; } = new();
    public string Tweet_Fields { get; set; } = "";
    public List<UserField> UserFieldList { get; init; } = new();
    public string User_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return "/tweets/search/recent";
    }
    Dictionary<string, string> IQueryParameterProperty.CreateQueryParameter()
    {
        var d = new Dictionary<string, string>();
        QueryParameterBuilder.Add(d, "query", this.Query);
        QueryParameterBuilder.AddValue(d, "max_results", this.Max_Results);
        QueryParameterBuilder.Add(d, "next_token", this.Next_Token);
        QueryParameterBuilder.Add(d, "start_time", this.Start_Time);
        QueryParameterBuilder.Add(d, "end_time", this.End_Time);
        QueryParameterBuilder.Add(d, "sort_order", this.Sort_Order);
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
public partial class TweetsSearchRecentResponse : XApiResult<List<XTweet>>
{
}
public partial class XClient
{
    public async ValueTask<TweetsSearchRecentResponse> TweetsSearchRecentAsync(string query)
    {
        var p = new TweetsSearchRecentParameter();
        p.Query = query;
        return await this.SendJsonAsync<TweetsSearchRecentParameter, TweetsSearchRecentResponse>(p);
    }
    public async ValueTask<TweetsSearchRecentResponse> TweetsSearchRecentAsync(string query, CancellationToken cancellationToken)
    {
        var p = new TweetsSearchRecentParameter();
        p.Query = query;
        return await this.SendJsonAsync<TweetsSearchRecentParameter, TweetsSearchRecentResponse>(p, cancellationToken);
    }
    public async ValueTask<TweetsSearchRecentResponse> TweetsSearchRecentAsync(TweetsSearchRecentParameter parameter)
    {
        return await this.SendJsonAsync<TweetsSearchRecentParameter, TweetsSearchRecentResponse>(parameter);
    }
    public async ValueTask<TweetsSearchRecentResponse> TweetsSearchRecentAsync(TweetsSearchRecentParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<TweetsSearchRecentParameter, TweetsSearchRecentResponse>(parameter, cancellationToken);
    }
}
