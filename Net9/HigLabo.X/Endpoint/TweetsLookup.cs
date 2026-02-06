using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class TweetsLookupParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Ids { get; set; } = "";
    public string Expansions { get; set; } = "";
    public string Tweet_Fields { get; set; } = "";
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
        QueryParameterBuilder.Add(d, "tweet.fields", this.Tweet_Fields);
        QueryParameterBuilder.Add(d, "user.fields", this.User_Fields);
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
