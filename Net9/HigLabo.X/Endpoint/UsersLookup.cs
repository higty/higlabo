using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class UsersLookupParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Ids { get; set; } = "";
    public string Usernames { get; set; } = "";
    public string User_Fields { get; set; } = "";
    public string Expansions { get; set; } = "";
    public string Tweet_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return "/users";
    }
    Dictionary<string, string> IQueryParameterProperty.CreateQueryParameter()
    {
        var d = new Dictionary<string, string>();
        QueryParameterBuilder.Add(d, "ids", this.Ids);
        QueryParameterBuilder.Add(d, "usernames", this.Usernames);
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
public partial class UsersLookupResponse : XApiResult<List<XUser>>
{
}
public partial class XClient
{
    public async ValueTask<UsersLookupResponse> UsersLookupAsync(string ids)
    {
        var p = new UsersLookupParameter();
        p.Ids = ids;
        return await this.SendJsonAsync<UsersLookupParameter, UsersLookupResponse>(p);
    }
    public async ValueTask<UsersLookupResponse> UsersLookupAsync(string ids, CancellationToken cancellationToken)
    {
        var p = new UsersLookupParameter();
        p.Ids = ids;
        return await this.SendJsonAsync<UsersLookupParameter, UsersLookupResponse>(p, cancellationToken);
    }
    public async ValueTask<UsersLookupResponse> UsersLookupAsync(UsersLookupParameter parameter)
    {
        return await this.SendJsonAsync<UsersLookupParameter, UsersLookupResponse>(parameter);
    }
    public async ValueTask<UsersLookupResponse> UsersLookupAsync(UsersLookupParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<UsersLookupParameter, UsersLookupResponse>(parameter, cancellationToken);
    }
}
