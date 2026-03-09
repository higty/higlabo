using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class UsersFollowersParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Id { get; set; } = "";
    public int? Max_Results { get; set; }
    public string Pagination_Token { get; set; } = "";
    public List<UserField> UserFieldList { get; init; } = new();
    public string User_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/users/{this.Id}/followers";
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
public partial class UsersFollowersResponse : XApiResult<List<XUser>>
{
}
public partial class XClient
{
    public async ValueTask<UsersFollowersResponse> UsersFollowersAsync(string id)
    {
        var p = new UsersFollowersParameter();
        p.Id = id;
        return await this.SendJsonAsync<UsersFollowersParameter, UsersFollowersResponse>(p);
    }
    public async ValueTask<UsersFollowersResponse> UsersFollowersAsync(string id, CancellationToken cancellationToken)
    {
        var p = new UsersFollowersParameter();
        p.Id = id;
        return await this.SendJsonAsync<UsersFollowersParameter, UsersFollowersResponse>(p, cancellationToken);
    }
    public async ValueTask<UsersFollowersResponse> UsersFollowersAsync(UsersFollowersParameter parameter)
    {
        return await this.SendJsonAsync<UsersFollowersParameter, UsersFollowersResponse>(parameter);
    }
    public async ValueTask<UsersFollowersResponse> UsersFollowersAsync(UsersFollowersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<UsersFollowersParameter, UsersFollowersResponse>(parameter, cancellationToken);
    }
}
