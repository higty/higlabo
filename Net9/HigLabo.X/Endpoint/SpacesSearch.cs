using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class SpacesSearchParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Query { get; set; } = "";
    public string State { get; set; } = "";
    public int? Max_Results { get; set; }
    public string Space_Fields { get; set; } = "";
    public string Expansions { get; set; } = "";
    public string User_Fields { get; set; } = "";
    public string Topic_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return "/spaces/search";
    }
    Dictionary<string, string> IQueryParameterProperty.CreateQueryParameter()
    {
        var d = new Dictionary<string, string>();
        QueryParameterBuilder.Add(d, "query", this.Query);
        QueryParameterBuilder.Add(d, "state", this.State);
        QueryParameterBuilder.AddValue(d, "max_results", this.Max_Results);
        QueryParameterBuilder.Add(d, "space.fields", this.Space_Fields);
        QueryParameterBuilder.Add(d, "expansions", this.Expansions);
        QueryParameterBuilder.Add(d, "user.fields", this.User_Fields);
        QueryParameterBuilder.Add(d, "topic.fields", this.Topic_Fields);
        return d;
    }
    public override object GetRequestBody()
    {
        return EmptyParameter;
    }
}
public partial class SpacesSearchResponse : XApiResult<List<XSpace>>
{
}
public partial class XClient
{
    public async ValueTask<SpacesSearchResponse> SpacesSearchAsync(string query)
    {
        var p = new SpacesSearchParameter();
        p.Query = query;
        return await this.SendJsonAsync<SpacesSearchParameter, SpacesSearchResponse>(p);
    }
    public async ValueTask<SpacesSearchResponse> SpacesSearchAsync(string query, CancellationToken cancellationToken)
    {
        var p = new SpacesSearchParameter();
        p.Query = query;
        return await this.SendJsonAsync<SpacesSearchParameter, SpacesSearchResponse>(p, cancellationToken);
    }
    public async ValueTask<SpacesSearchResponse> SpacesSearchAsync(SpacesSearchParameter parameter)
    {
        return await this.SendJsonAsync<SpacesSearchParameter, SpacesSearchResponse>(parameter);
    }
    public async ValueTask<SpacesSearchResponse> SpacesSearchAsync(SpacesSearchParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<SpacesSearchParameter, SpacesSearchResponse>(parameter, cancellationToken);
    }
}
