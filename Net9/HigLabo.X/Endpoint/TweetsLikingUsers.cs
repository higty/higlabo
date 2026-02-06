using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class TweetsLikingUsersParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Id { get; set; } = "";
    public int? Max_Results { get; set; }
    public string Pagination_Token { get; set; } = "";
    public string User_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/tweets/{this.Id}/liking_users";
    }
    Dictionary<string, string> IQueryParameterProperty.CreateQueryParameter()
    {
        var d = new Dictionary<string, string>();
        QueryParameterBuilder.AddValue(d, "max_results", this.Max_Results);
        QueryParameterBuilder.Add(d, "pagination_token", this.Pagination_Token);
        QueryParameterBuilder.Add(d, "user.fields", this.User_Fields);
        return d;
    }
    public override object GetRequestBody()
    {
        return EmptyParameter;
    }
}
public partial class TweetsLikingUsersResponse : XApiResult<List<XUser>>
{
}
public partial class XClient
{
    public async ValueTask<TweetsLikingUsersResponse> TweetsLikingUsersAsync(string id)
    {
        var p = new TweetsLikingUsersParameter();
        p.Id = id;
        return await this.SendJsonAsync<TweetsLikingUsersParameter, TweetsLikingUsersResponse>(p);
    }
    public async ValueTask<TweetsLikingUsersResponse> TweetsLikingUsersAsync(string id, CancellationToken cancellationToken)
    {
        var p = new TweetsLikingUsersParameter();
        p.Id = id;
        return await this.SendJsonAsync<TweetsLikingUsersParameter, TweetsLikingUsersResponse>(p, cancellationToken);
    }
    public async ValueTask<TweetsLikingUsersResponse> TweetsLikingUsersAsync(TweetsLikingUsersParameter parameter)
    {
        return await this.SendJsonAsync<TweetsLikingUsersParameter, TweetsLikingUsersResponse>(parameter);
    }
    public async ValueTask<TweetsLikingUsersResponse> TweetsLikingUsersAsync(TweetsLikingUsersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<TweetsLikingUsersParameter, TweetsLikingUsersResponse>(parameter, cancellationToken);
    }
}
