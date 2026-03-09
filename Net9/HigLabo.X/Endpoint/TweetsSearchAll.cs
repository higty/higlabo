using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class TweetsSearchAllParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
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
        return "/tweets/search/all";
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
public partial class TweetsSearchAllResponse : XApiResult<List<XTweet>>
{
}
public partial class XClient
{
    public async ValueTask<TweetsSearchAllResponse> TweetsSearchAllAsync(string query)
    {
        var p = new TweetsSearchAllParameter();
        p.Query = query;
        return await this.SendJsonAsync<TweetsSearchAllParameter, TweetsSearchAllResponse>(p);
    }
    public async ValueTask<TweetsSearchAllResponse> TweetsSearchAllAsync(string query, CancellationToken cancellationToken)
    {
        var p = new TweetsSearchAllParameter();
        p.Query = query;
        return await this.SendJsonAsync<TweetsSearchAllParameter, TweetsSearchAllResponse>(p, cancellationToken);
    }
    public async ValueTask<TweetsSearchAllResponse> TweetsSearchAllAsync(TweetsSearchAllParameter parameter)
    {
        return await this.SendJsonAsync<TweetsSearchAllParameter, TweetsSearchAllResponse>(parameter);
    }
    public async ValueTask<TweetsSearchAllResponse> TweetsSearchAllAsync(TweetsSearchAllParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<TweetsSearchAllParameter, TweetsSearchAllResponse>(parameter, cancellationToken);
    }
}
