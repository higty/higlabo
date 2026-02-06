using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class UserByIdParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Id { get; set; } = "";
    public string User_Fields { get; set; } = "";
    public string Expansions { get; set; } = "";
    public string Tweet_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/users/{this.Id}";
    }
    Dictionary<string, string> IQueryParameterProperty.CreateQueryParameter()
    {
        var d = new Dictionary<string, string>();
        QueryParameterBuilder.Add(d, "user.fields", this.User_Fields);
        QueryParameterBuilder.Add(d, "expansions", this.Expansions);
        QueryParameterBuilder.Add(d, "tweet.fields", this.Tweet_Fields);
        return d;
    }
    public override object GetRequestBody()
    {
        return EmptyParameter;
    }
}
public partial class UserByIdResponse : XApiResult<XUser>
{
}
public partial class XClient
{
    public async ValueTask<UserByIdResponse> UserByIdAsync(string id)
    {
        var p = new UserByIdParameter();
        p.Id = id;
        return await this.SendJsonAsync<UserByIdParameter, UserByIdResponse>(p);
    }
    public async ValueTask<UserByIdResponse> UserByIdAsync(string id, CancellationToken cancellationToken)
    {
        var p = new UserByIdParameter();
        p.Id = id;
        return await this.SendJsonAsync<UserByIdParameter, UserByIdResponse>(p, cancellationToken);
    }
    public async ValueTask<UserByIdResponse> UserByIdAsync(UserByIdParameter parameter)
    {
        return await this.SendJsonAsync<UserByIdParameter, UserByIdResponse>(parameter);
    }
    public async ValueTask<UserByIdResponse> UserByIdAsync(UserByIdParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<UserByIdParameter, UserByIdResponse>(parameter, cancellationToken);
    }
}
