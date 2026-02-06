using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class ListMembersParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Id { get; set; } = "";
    public int? Max_Results { get; set; }
    public string Pagination_Token { get; set; } = "";
    public string User_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/lists/{this.Id}/members";
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
public partial class ListMembersResponse : XApiResult<List<XUser>>
{
}
public partial class XClient
{
    public async ValueTask<ListMembersResponse> ListMembersAsync(string id)
    {
        var p = new ListMembersParameter();
        p.Id = id;
        return await this.SendJsonAsync<ListMembersParameter, ListMembersResponse>(p);
    }
    public async ValueTask<ListMembersResponse> ListMembersAsync(string id, CancellationToken cancellationToken)
    {
        var p = new ListMembersParameter();
        p.Id = id;
        return await this.SendJsonAsync<ListMembersParameter, ListMembersResponse>(p, cancellationToken);
    }
    public async ValueTask<ListMembersResponse> ListMembersAsync(ListMembersParameter parameter)
    {
        return await this.SendJsonAsync<ListMembersParameter, ListMembersResponse>(parameter);
    }
    public async ValueTask<ListMembersResponse> ListMembersAsync(ListMembersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<ListMembersParameter, ListMembersResponse>(parameter, cancellationToken);
    }
}
