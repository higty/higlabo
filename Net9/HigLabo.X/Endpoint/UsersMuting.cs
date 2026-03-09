using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class UsersMutingParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Id { get; set; } = "";
    public int? Max_Results { get; set; }
    public string Pagination_Token { get; set; } = "";
    public List<UserField> UserFieldList { get; init; } = new();
    public string User_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/users/{this.Id}/muting";
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
public partial class UsersMutingResponse : XApiResult<List<XUser>>
{
}
public partial class XClient
{
    public async ValueTask<UsersMutingResponse> UsersMutingAsync(string id)
    {
        var p = new UsersMutingParameter();
        p.Id = id;
        return await this.SendJsonAsync<UsersMutingParameter, UsersMutingResponse>(p);
    }
    public async ValueTask<UsersMutingResponse> UsersMutingAsync(string id, CancellationToken cancellationToken)
    {
        var p = new UsersMutingParameter();
        p.Id = id;
        return await this.SendJsonAsync<UsersMutingParameter, UsersMutingResponse>(p, cancellationToken);
    }
    public async ValueTask<UsersMutingResponse> UsersMutingAsync(UsersMutingParameter parameter)
    {
        return await this.SendJsonAsync<UsersMutingParameter, UsersMutingResponse>(parameter);
    }
    public async ValueTask<UsersMutingResponse> UsersMutingAsync(UsersMutingParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<UsersMutingParameter, UsersMutingResponse>(parameter, cancellationToken);
    }
}
