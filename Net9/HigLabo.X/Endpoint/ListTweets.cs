using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class ListTweetsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
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
        return $"/lists/{this.Id}/tweets";
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
public partial class ListTweetsResponse : XApiResult<List<XTweet>>
{
}
public partial class XClient
{
    public async ValueTask<ListTweetsResponse> ListTweetsAsync(string id)
    {
        var p = new ListTweetsParameter();
        p.Id = id;
        return await this.SendJsonAsync<ListTweetsParameter, ListTweetsResponse>(p);
    }
    public async ValueTask<ListTweetsResponse> ListTweetsAsync(string id, CancellationToken cancellationToken)
    {
        var p = new ListTweetsParameter();
        p.Id = id;
        return await this.SendJsonAsync<ListTweetsParameter, ListTweetsResponse>(p, cancellationToken);
    }
    public async ValueTask<ListTweetsResponse> ListTweetsAsync(ListTweetsParameter parameter)
    {
        return await this.SendJsonAsync<ListTweetsParameter, ListTweetsResponse>(parameter);
    }
    public async ValueTask<ListTweetsResponse> ListTweetsAsync(ListTweetsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<ListTweetsParameter, ListTweetsResponse>(parameter, cancellationToken);
    }
}
