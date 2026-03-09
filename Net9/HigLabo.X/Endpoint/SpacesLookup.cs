using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class SpacesLookupParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Ids { get; set; } = "";
    public List<SpaceField> SpaceFieldList { get; init; } = new();
    public string Space_Fields { get; set; } = "";
    public string Expansions { get; set; } = "";
    public List<UserField> UserFieldList { get; init; } = new();
    public string User_Fields { get; set; } = "";
    public List<TopicField> TopicFieldList { get; init; } = new();
    public string Topic_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return "/spaces";
    }
    Dictionary<string, string> IQueryParameterProperty.CreateQueryParameter()
    {
        var d = new Dictionary<string, string>();
        QueryParameterBuilder.Add(d, "ids", this.Ids);
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
