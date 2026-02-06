using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class ListFollowersParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Id { get; set; } = "";
    public int? Max_Results { get; set; }
    public string Pagination_Token { get; set; } = "";
    public string User_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/lists/{this.Id}/followers";
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
public partial class ListFollowersResponse : XApiResult<List<XUser>>
{
}
public partial class XClient
{
    public async ValueTask<ListFollowersResponse> ListFollowersAsync(string id)
    {
        var p = new ListFollowersParameter();
        p.Id = id;
        return await this.SendJsonAsync<ListFollowersParameter, ListFollowersResponse>(p);
    }
    public async ValueTask<ListFollowersResponse> ListFollowersAsync(string id, CancellationToken cancellationToken)
    {
        var p = new ListFollowersParameter();
        p.Id = id;
        return await this.SendJsonAsync<ListFollowersParameter, ListFollowersResponse>(p, cancellationToken);
    }
    public async ValueTask<ListFollowersResponse> ListFollowersAsync(ListFollowersParameter parameter)
    {
        return await this.SendJsonAsync<ListFollowersParameter, ListFollowersResponse>(parameter);
    }
    public async ValueTask<ListFollowersResponse> ListFollowersAsync(ListFollowersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<ListFollowersParameter, ListFollowersResponse>(parameter, cancellationToken);
    }
}
