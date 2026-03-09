using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class UsersFollowedListsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Id { get; set; } = "";
    public int? Max_Results { get; set; }
    public string Pagination_Token { get; set; } = "";
    public List<ListField> ListFieldList { get; init; } = new();
    public string List_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/users/{this.Id}/followed_lists";
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
public partial class UsersFollowedListsResponse : XApiResult<List<XList>>
{
}
public partial class XClient
{
    public async ValueTask<UsersFollowedListsResponse> UsersFollowedListsAsync(string id)
    {
        var p = new UsersFollowedListsParameter();
        p.Id = id;
        return await this.SendJsonAsync<UsersFollowedListsParameter, UsersFollowedListsResponse>(p);
    }
    public async ValueTask<UsersFollowedListsResponse> UsersFollowedListsAsync(string id, CancellationToken cancellationToken)
    {
        var p = new UsersFollowedListsParameter();
        p.Id = id;
        return await this.SendJsonAsync<UsersFollowedListsParameter, UsersFollowedListsResponse>(p, cancellationToken);
    }
    public async ValueTask<UsersFollowedListsResponse> UsersFollowedListsAsync(UsersFollowedListsParameter parameter)
    {
        return await this.SendJsonAsync<UsersFollowedListsParameter, UsersFollowedListsResponse>(parameter);
    }
    public async ValueTask<UsersFollowedListsResponse> UsersFollowedListsAsync(UsersFollowedListsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<UsersFollowedListsParameter, UsersFollowedListsResponse>(parameter, cancellationToken);
    }
}
