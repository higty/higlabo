using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class ListByIdParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Id { get; set; } = "";
    public List<ListField> ListFieldList { get; init; } = new();
    public string List_Fields { get; set; } = "";
    public string Expansions { get; set; } = "";
    public List<UserField> UserFieldList { get; init; } = new();
    public string User_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/lists/{this.Id}";
    }
    Dictionary<string, string> IQueryParameterProperty.CreateQueryParameter()
    {
        var d = new Dictionary<string, string>();
        QueryParameterBuilder.AddField(d, "list.fields", this.ListFieldList, this.List_Fields);
        QueryParameterBuilder.Add(d, "expansions", this.Expansions);
        QueryParameterBuilder.AddField(d, "user.fields", this.UserFieldList, this.User_Fields);
        return d;
    }
    public override object GetRequestBody()
    {
        return EmptyParameter;
    }
}
public partial class ListByIdResponse : XApiResult<XList>
{
}
public partial class XClient
{
    public async ValueTask<ListByIdResponse> ListByIdAsync(string id)
    {
        var p = new ListByIdParameter();
        p.Id = id;
        return await this.SendJsonAsync<ListByIdParameter, ListByIdResponse>(p);
    }
    public async ValueTask<ListByIdResponse> ListByIdAsync(string id, CancellationToken cancellationToken)
    {
        var p = new ListByIdParameter();
        p.Id = id;
        return await this.SendJsonAsync<ListByIdParameter, ListByIdResponse>(p, cancellationToken);
    }
    public async ValueTask<ListByIdResponse> ListByIdAsync(ListByIdParameter parameter)
    {
        return await this.SendJsonAsync<ListByIdParameter, ListByIdResponse>(parameter);
    }
    public async ValueTask<ListByIdResponse> ListByIdAsync(ListByIdParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<ListByIdParameter, ListByIdResponse>(parameter, cancellationToken);
    }
}
