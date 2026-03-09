using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class SpaceByIdParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Id { get; set; } = "";
    public List<SpaceField> SpaceFieldList { get; init; } = new();
    public string Space_Fields { get; set; } = "";
    public string Expansions { get; set; } = "";
    public List<UserField> UserFieldList { get; init; } = new();
    public string User_Fields { get; set; } = "";
    public List<TopicField> TopicFieldList { get; init; } = new();
    public string Topic_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/spaces/{this.Id}";
    }
    Dictionary<string, string> IQueryParameterProperty.CreateQueryParameter()
    {
        var d = new Dictionary<string, string>();
        QueryParameterBuilder.AddField(d, "space.fields", this.SpaceFieldList, this.Space_Fields);
        QueryParameterBuilder.Add(d, "expansions", this.Expansions);
        QueryParameterBuilder.AddField(d, "user.fields", this.UserFieldList, this.User_Fields);
        QueryParameterBuilder.AddField(d, "topic.fields", this.TopicFieldList, this.Topic_Fields);
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
