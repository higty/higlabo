using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class TweetByIdParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Id { get; set; } = "";
    public string Expansions { get; set; } = "";
    public string Tweet_Fields { get; set; } = "";
    public string User_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/tweets/{this.Id}";
    }
    Dictionary<string, string> IQueryParameterProperty.CreateQueryParameter()
    {
        var d = new Dictionary<string, string>();
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
public partial class TweetByIdResponse : XApiResult<XTweet>
{
}
public partial class XClient
{
    public async ValueTask<TweetByIdResponse> TweetByIdAsync(string id)
    {
        var p = new TweetByIdParameter();
        p.Id = id;
        return await this.SendJsonAsync<TweetByIdParameter, TweetByIdResponse>(p);
    }
    public async ValueTask<TweetByIdResponse> TweetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var p = new TweetByIdParameter();
        p.Id = id;
        return await this.SendJsonAsync<TweetByIdParameter, TweetByIdResponse>(p, cancellationToken);
    }
    public async ValueTask<TweetByIdResponse> TweetByIdAsync(TweetByIdParameter parameter)
    {
        return await this.SendJsonAsync<TweetByIdParameter, TweetByIdResponse>(parameter);
    }
    public async ValueTask<TweetByIdResponse> TweetByIdAsync(TweetByIdParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<TweetByIdParameter, TweetByIdResponse>(parameter, cancellationToken);
    }
}
