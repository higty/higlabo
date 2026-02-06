using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class UsersReverseChronologicalTimelineParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Id { get; set; } = "";
    public int? Max_Results { get; set; }
    public string Pagination_Token { get; set; } = "";
    public string Since_Id { get; set; } = "";
    public string Until_Id { get; set; } = "";
    public string Exclude { get; set; } = "";
    public string Expansions { get; set; } = "";
    public string Tweet_Fields { get; set; } = "";
    public string User_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/users/{this.Id}/timelines/reverse_chronological";
    }
    Dictionary<string, string> IQueryParameterProperty.CreateQueryParameter()
    {
        var d = new Dictionary<string, string>();
        QueryParameterBuilder.AddValue(d, "max_results", this.Max_Results);
        QueryParameterBuilder.Add(d, "pagination_token", this.Pagination_Token);
        QueryParameterBuilder.Add(d, "since_id", this.Since_Id);
        QueryParameterBuilder.Add(d, "until_id", this.Until_Id);
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
public partial class UsersReverseChronologicalTimelineResponse : XApiResult<List<XTweet>>
{
}
public partial class XClient
{
    public async ValueTask<UsersReverseChronologicalTimelineResponse> UsersReverseChronologicalTimelineAsync(string id)
    {
        var p = new UsersReverseChronologicalTimelineParameter();
        p.Id = id;
        return await this.SendJsonAsync<UsersReverseChronologicalTimelineParameter, UsersReverseChronologicalTimelineResponse>(p);
    }
    public async ValueTask<UsersReverseChronologicalTimelineResponse> UsersReverseChronologicalTimelineAsync(string id, CancellationToken cancellationToken)
    {
        var p = new UsersReverseChronologicalTimelineParameter();
        p.Id = id;
        return await this.SendJsonAsync<UsersReverseChronologicalTimelineParameter, UsersReverseChronologicalTimelineResponse>(p, cancellationToken);
    }
    public async ValueTask<UsersReverseChronologicalTimelineResponse> UsersReverseChronologicalTimelineAsync(UsersReverseChronologicalTimelineParameter parameter)
    {
        return await this.SendJsonAsync<UsersReverseChronologicalTimelineParameter, UsersReverseChronologicalTimelineResponse>(parameter);
    }
    public async ValueTask<UsersReverseChronologicalTimelineResponse> UsersReverseChronologicalTimelineAsync(UsersReverseChronologicalTimelineParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<UsersReverseChronologicalTimelineParameter, UsersReverseChronologicalTimelineResponse>(parameter, cancellationToken);
    }
}
