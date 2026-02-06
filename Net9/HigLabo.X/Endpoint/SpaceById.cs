using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class SpaceByIdParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Id { get; set; } = "";
    public string Space_Fields { get; set; } = "";
    public string Expansions { get; set; } = "";
    public string User_Fields { get; set; } = "";
    public string Topic_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/spaces/{this.Id}";
    }
    Dictionary<string, string> IQueryParameterProperty.CreateQueryParameter()
    {
        var d = new Dictionary<string, string>();
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
public partial class SpaceByIdResponse : XApiResult<XSpace>
{
}
public partial class XClient
{
    public async ValueTask<SpaceByIdResponse> SpaceByIdAsync(string id)
    {
        var p = new SpaceByIdParameter();
        p.Id = id;
        return await this.SendJsonAsync<SpaceByIdParameter, SpaceByIdResponse>(p);
    }
    public async ValueTask<SpaceByIdResponse> SpaceByIdAsync(string id, CancellationToken cancellationToken)
    {
        var p = new SpaceByIdParameter();
        p.Id = id;
        return await this.SendJsonAsync<SpaceByIdParameter, SpaceByIdResponse>(p, cancellationToken);
    }
    public async ValueTask<SpaceByIdResponse> SpaceByIdAsync(SpaceByIdParameter parameter)
    {
        return await this.SendJsonAsync<SpaceByIdParameter, SpaceByIdResponse>(parameter);
    }
    public async ValueTask<SpaceByIdResponse> SpaceByIdAsync(SpaceByIdParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<SpaceByIdParameter, SpaceByIdResponse>(parameter, cancellationToken);
    }
}
