using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class TweetByIdParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Id { get; set; } = "";
    public string Expansions { get; set; } = "";
    public List<TweetField> TweetFieldList { get; init; } = new();
    public string Tweet_Fields { get; set; } = "";
    public List<UserField> UserFieldList { get; init; } = new();
    public string User_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/tweets/{this.Id}";
    }
    Dictionary<string, string> IQueryParameterProperty.CreateQueryParameter()
    {
        var d = new Dictionary<string, string>();
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
