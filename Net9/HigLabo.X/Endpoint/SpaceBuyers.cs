using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class SpaceBuyersParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Id { get; set; } = "";
    public int? Max_Results { get; set; }
    public string Pagination_Token { get; set; } = "";
    public List<UserField> UserFieldList { get; init; } = new();
    public string User_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/spaces/{this.Id}/buyers";
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
public partial class SpaceBuyersResponse : XApiResult<List<XUser>>
{
}
public partial class XClient
{
    public async ValueTask<SpaceBuyersResponse> SpaceBuyersAsync(string id)
    {
        var p = new SpaceBuyersParameter();
        p.Id = id;
        return await this.SendJsonAsync<SpaceBuyersParameter, SpaceBuyersResponse>(p);
    }
    public async ValueTask<SpaceBuyersResponse> SpaceBuyersAsync(string id, CancellationToken cancellationToken)
    {
        var p = new SpaceBuyersParameter();
        p.Id = id;
        return await this.SendJsonAsync<SpaceBuyersParameter, SpaceBuyersResponse>(p, cancellationToken);
    }
    public async ValueTask<SpaceBuyersResponse> SpaceBuyersAsync(SpaceBuyersParameter parameter)
    {
        return await this.SendJsonAsync<SpaceBuyersParameter, SpaceBuyersResponse>(parameter);
    }
    public async ValueTask<SpaceBuyersResponse> SpaceBuyersAsync(SpaceBuyersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<SpaceBuyersParameter, SpaceBuyersResponse>(parameter, cancellationToken);
    }
}
