using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class SpacesLookupParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Ids { get; set; } = "";
    public string Space_Fields { get; set; } = "";
    public string Expansions { get; set; } = "";
    public string User_Fields { get; set; } = "";
    public string Topic_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return "/spaces";
    }
    Dictionary<string, string> IQueryParameterProperty.CreateQueryParameter()
    {
        var d = new Dictionary<string, string>();
        QueryParameterBuilder.Add(d, "ids", this.Ids);
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
public partial class SpacesLookupResponse : XApiResult<List<XSpace>>
{
}
public partial class XClient
{
    public async ValueTask<SpacesLookupResponse> SpacesLookupAsync(string ids)
    {
        var p = new SpacesLookupParameter();
        p.Ids = ids;
        return await this.SendJsonAsync<SpacesLookupParameter, SpacesLookupResponse>(p);
    }
    public async ValueTask<SpacesLookupResponse> SpacesLookupAsync(string ids, CancellationToken cancellationToken)
    {
        var p = new SpacesLookupParameter();
        p.Ids = ids;
        return await this.SendJsonAsync<SpacesLookupParameter, SpacesLookupResponse>(p, cancellationToken);
    }
    public async ValueTask<SpacesLookupResponse> SpacesLookupAsync(SpacesLookupParameter parameter)
    {
        return await this.SendJsonAsync<SpacesLookupParameter, SpacesLookupResponse>(parameter);
    }
    public async ValueTask<SpacesLookupResponse> SpacesLookupAsync(SpacesLookupParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<SpacesLookupParameter, SpacesLookupResponse>(parameter, cancellationToken);
    }
}
