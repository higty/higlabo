using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class UsersOwnedListsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Id { get; set; } = "";
    public int? Max_Results { get; set; }
    public string Pagination_Token { get; set; } = "";
    public List<ListField> ListFieldList { get; init; } = new();
    public string List_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/users/{this.Id}/owned_lists";
    }
    Dictionary<string, string> IQueryParameterProperty.CreateQueryParameter()
    {
        var d = new Dictionary<string, string>();
        QueryParameterBuilder.AddValue(d, "max_results", this.Max_Results);
        QueryParameterBuilder.Add(d, "pagination_token", this.Pagination_Token);
        QueryParameterBuilder.AddField(d, "list.fields", this.ListFieldList, this.List_Fields);
        return d;
    }
    public override object GetRequestBody()
    {
        return EmptyParameter;
    }
}
public partial class UsersOwnedListsResponse : XApiResult<List<XList>>
{
}
public partial class XClient
{
    public async ValueTask<UsersOwnedListsResponse> UsersOwnedListsAsync(string id)
    {
        var p = new UsersOwnedListsParameter();
        p.Id = id;
        return await this.SendJsonAsync<UsersOwnedListsParameter, UsersOwnedListsResponse>(p);
    }
    public async ValueTask<UsersOwnedListsResponse> UsersOwnedListsAsync(string id, CancellationToken cancellationToken)
    {
        var p = new UsersOwnedListsParameter();
        p.Id = id;
        return await this.SendJsonAsync<UsersOwnedListsParameter, UsersOwnedListsResponse>(p, cancellationToken);
    }
    public async ValueTask<UsersOwnedListsResponse> UsersOwnedListsAsync(UsersOwnedListsParameter parameter)
    {
        return await this.SendJsonAsync<UsersOwnedListsParameter, UsersOwnedListsResponse>(parameter);
    }
    public async ValueTask<UsersOwnedListsResponse> UsersOwnedListsAsync(UsersOwnedListsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<UsersOwnedListsParameter, UsersOwnedListsResponse>(parameter, cancellationToken);
    }
}
