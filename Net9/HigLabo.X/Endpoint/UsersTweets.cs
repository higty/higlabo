using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class UsersTweetsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Id { get; set; } = "";
    public int? Max_Results { get; set; }
    public string Pagination_Token { get; set; } = "";
    public string Start_Time { get; set; } = "";
    public string End_Time { get; set; } = "";
    public string Exclude { get; set; } = "";
    public string Expansions { get; set; } = "";
    public string Tweet_Fields { get; set; } = "";
    public string User_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/users/{this.Id}/tweets";
    }
    Dictionary<string, string> IQueryParameterProperty.CreateQueryParameter()
    {
        var d = new Dictionary<string, string>();
        QueryParameterBuilder.AddValue(d, "max_results", this.Max_Results);
        QueryParameterBuilder.Add(d, "pagination_token", this.Pagination_Token);
        QueryParameterBuilder.Add(d, "start_time", this.Start_Time);
        QueryParameterBuilder.Add(d, "end_time", this.End_Time);
        QueryParameterBuilder.Add(d, "exclude", this.Exclude);
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
public partial class UsersTweetsResponse : XApiResult<List<XTweet>>
{
}
public partial class XClient
{
    public async ValueTask<UsersTweetsResponse> UsersTweetsAsync(string id)
    {
        var p = new UsersTweetsParameter();
        p.Id = id;
        return await this.SendJsonAsync<UsersTweetsParameter, UsersTweetsResponse>(p);
    }
    public async ValueTask<UsersTweetsResponse> UsersTweetsAsync(string id, CancellationToken cancellationToken)
    {
        var p = new UsersTweetsParameter();
        p.Id = id;
        return await this.SendJsonAsync<UsersTweetsParameter, UsersTweetsResponse>(p, cancellationToken);
    }
    public async ValueTask<UsersTweetsResponse> UsersTweetsAsync(UsersTweetsParameter parameter)
    {
        return await this.SendJsonAsync<UsersTweetsParameter, UsersTweetsResponse>(parameter);
    }
    public async ValueTask<UsersTweetsResponse> UsersTweetsAsync(UsersTweetsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<UsersTweetsParameter, UsersTweetsResponse>(parameter, cancellationToken);
    }
}
