using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class TweetsRetweetedByParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Id { get; set; } = "";
    public int? Max_Results { get; set; }
    public string Pagination_Token { get; set; } = "";
    public List<UserField> UserFieldList { get; init; } = new();
    public string User_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/tweets/{this.Id}/retweeted_by";
    }
    Dictionary<string, string> IQueryParameterProperty.CreateQueryParameter()
    {
        var d = new Dictionary<string, string>();
        QueryParameterBuilder.AddValue(d, "max_results", this.Max_Results);
        QueryParameterBuilder.Add(d, "pagination_token", this.Pagination_Token);
        QueryParameterBuilder.AddField(d, "user.fields", this.UserFieldList, this.User_Fields);
        return d;
    }
    public override object GetRequestBody()
    {
        return EmptyParameter;
    }
}
public partial class TweetsRetweetedByResponse : XApiResult<List<XUser>>
{
}
public partial class XClient
{
    public async ValueTask<TweetsRetweetedByResponse> TweetsRetweetedByAsync(string id)
    {
        var p = new TweetsRetweetedByParameter();
        p.Id = id;
        return await this.SendJsonAsync<TweetsRetweetedByParameter, TweetsRetweetedByResponse>(p);
    }
    public async ValueTask<TweetsRetweetedByResponse> TweetsRetweetedByAsync(string id, CancellationToken cancellationToken)
    {
        var p = new TweetsRetweetedByParameter();
        p.Id = id;
        return await this.SendJsonAsync<TweetsRetweetedByParameter, TweetsRetweetedByResponse>(p, cancellationToken);
    }
    public async ValueTask<TweetsRetweetedByResponse> TweetsRetweetedByAsync(TweetsRetweetedByParameter parameter)
    {
        return await this.SendJsonAsync<TweetsRetweetedByParameter, TweetsRetweetedByResponse>(parameter);
    }
    public async ValueTask<TweetsRetweetedByResponse> TweetsRetweetedByAsync(TweetsRetweetedByParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<TweetsRetweetedByParameter, TweetsRetweetedByResponse>(parameter, cancellationToken);
    }
}
