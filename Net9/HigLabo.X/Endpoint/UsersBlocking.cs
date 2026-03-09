using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class UsersBlockingParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Id { get; set; } = "";
    public int? Max_Results { get; set; }
    public string Pagination_Token { get; set; } = "";
    public List<UserField> UserFieldList { get; init; } = new();
    public string User_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/users/{this.Id}/blocking";
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
public partial class UsersBlockingResponse : XApiResult<List<XUser>>
{
}
public partial class XClient
{
    public async ValueTask<UsersBlockingResponse> UsersBlockingAsync(string id)
    {
        var p = new UsersBlockingParameter();
        p.Id = id;
        return await this.SendJsonAsync<UsersBlockingParameter, UsersBlockingResponse>(p);
    }
    public async ValueTask<UsersBlockingResponse> UsersBlockingAsync(string id, CancellationToken cancellationToken)
    {
        var p = new UsersBlockingParameter();
        p.Id = id;
        return await this.SendJsonAsync<UsersBlockingParameter, UsersBlockingResponse>(p, cancellationToken);
    }
    public async ValueTask<UsersBlockingResponse> UsersBlockingAsync(UsersBlockingParameter parameter)
    {
        return await this.SendJsonAsync<UsersBlockingParameter, UsersBlockingResponse>(parameter);
    }
    public async ValueTask<UsersBlockingResponse> UsersBlockingAsync(UsersBlockingParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<UsersBlockingParameter, UsersBlockingResponse>(parameter, cancellationToken);
    }
}
