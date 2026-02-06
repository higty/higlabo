using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class UserByUsernameParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Username { get; set; } = "";
    public string User_Fields { get; set; } = "";
    public string Expansions { get; set; } = "";
    public string Tweet_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/users/by/username/{this.Username}";
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
public partial class UserByUsernameResponse : XApiResult<XUser>
{
}
public partial class XClient
{
    public async ValueTask<UserByUsernameResponse> UserByUsernameAsync(string username)
    {
        var p = new UserByUsernameParameter();
        p.Username = username;
        return await this.SendJsonAsync<UserByUsernameParameter, UserByUsernameResponse>(p);
    }
    public async ValueTask<UserByUsernameResponse> UserByUsernameAsync(string username, CancellationToken cancellationToken)
    {
        var p = new UserByUsernameParameter();
        p.Username = username;
        return await this.SendJsonAsync<UserByUsernameParameter, UserByUsernameResponse>(p, cancellationToken);
    }
    public async ValueTask<UserByUsernameResponse> UserByUsernameAsync(UserByUsernameParameter parameter)
    {
        return await this.SendJsonAsync<UserByUsernameParameter, UserByUsernameResponse>(parameter);
    }
    public async ValueTask<UserByUsernameResponse> UserByUsernameAsync(UserByUsernameParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<UserByUsernameParameter, UserByUsernameResponse>(parameter, cancellationToken);
    }
}
