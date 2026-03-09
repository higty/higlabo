using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class SpacesSearchParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Query { get; set; } = "";
    public string State { get; set; } = "";
    public int? Max_Results { get; set; }
    public List<SpaceField> SpaceFieldList { get; init; } = new();
    public string Space_Fields { get; set; } = "";
    public string Expansions { get; set; } = "";
    public List<UserField> UserFieldList { get; init; } = new();
    public string User_Fields { get; set; } = "";
    public List<TopicField> TopicFieldList { get; init; } = new();
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
