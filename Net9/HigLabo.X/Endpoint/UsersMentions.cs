using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class UsersMentionsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Id { get; set; } = "";
    public int? Max_Results { get; set; }
    public string Pagination_Token { get; set; } = "";
    public string Start_Time { get; set; } = "";
    public string End_Time { get; set; } = "";
    public string Expansions { get; set; } = "";
    public List<TweetField> TweetFieldList { get; init; } = new();
    public string Tweet_Fields { get; set; } = "";
    public List<UserField> UserFieldList { get; init; } = new();
    public string User_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/users/{this.Id}/mentions";
    }
    Dictionary<string, string> IQueryParameterProperty.CreateQueryParameter()
    {
        var d = new Dictionary<string, string>();
        QueryParameterBuilder.AddValue(d, "max_results", this.Max_Results);
        QueryParameterBuilder.Add(d, "pagination_token", this.Pagination_Token);
        QueryParameterBuilder.Add(d, "start_time", this.Start_Time);
        QueryParameterBuilder.Add(d, "end_time", this.End_Time);
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
public partial class UsersMentionsResponse : XApiResult<List<XTweet>>
{
}
public partial class XClient
{
    public async ValueTask<UsersMentionsResponse> UsersMentionsAsync(string id)
    {
        var p = new UsersMentionsParameter();
        p.Id = id;
        return await this.SendJsonAsync<UsersMentionsParameter, UsersMentionsResponse>(p);
    }
    public async ValueTask<UsersMentionsResponse> UsersMentionsAsync(string id, CancellationToken cancellationToken)
    {
        var p = new UsersMentionsParameter();
        p.Id = id;
        return await this.SendJsonAsync<UsersMentionsParameter, UsersMentionsResponse>(p, cancellationToken);
    }
    public async ValueTask<UsersMentionsResponse> UsersMentionsAsync(UsersMentionsParameter parameter)
    {
        return await this.SendJsonAsync<UsersMentionsParameter, UsersMentionsResponse>(parameter);
    }
    public async ValueTask<UsersMentionsResponse> UsersMentionsAsync(UsersMentionsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<UsersMentionsParameter, UsersMentionsResponse>(parameter, cancellationToken);
    }
}
