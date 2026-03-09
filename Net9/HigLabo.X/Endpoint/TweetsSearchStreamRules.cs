using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class TweetsSearchStreamRulesParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    internal static readonly TweetsSearchStreamRulesParameter Empty = new TweetsSearchStreamRulesParameter();
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Ids { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return "/tweets/search/stream/rules";
    }
    Dictionary<string, string> IQueryParameterProperty.CreateQueryParameter()
    {
        var d = new Dictionary<string, string>();
        QueryParameterBuilder.Add(d, "ids", this.Ids);
        return d;
    }
    public override object GetRequestBody()
    {
        return EmptyParameter;
    }
}
public partial class TweetsSearchStreamRulesResponse : XApiResult<List<XRule>>
{
}
public partial class XClient
{
    public async ValueTask<TweetsSearchStreamRulesResponse> TweetsSearchStreamRulesAsync()
    {
        return await this.SendJsonAsync<TweetsSearchStreamRulesParameter, TweetsSearchStreamRulesResponse>(TweetsSearchStreamRulesParameter.Empty);
    }
    public async ValueTask<TweetsSearchStreamRulesResponse> TweetsSearchStreamRulesAsync(CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<TweetsSearchStreamRulesParameter, TweetsSearchStreamRulesResponse>(TweetsSearchStreamRulesParameter.Empty, cancellationToken);
    }
    public async ValueTask<TweetsSearchStreamRulesResponse> TweetsSearchStreamRulesAsync(TweetsSearchStreamRulesParameter parameter)
    {
        return await this.SendJsonAsync<TweetsSearchStreamRulesParameter, TweetsSearchStreamRulesResponse>(parameter);
    }
    public async ValueTask<TweetsSearchStreamRulesResponse> TweetsSearchStreamRulesAsync(TweetsSearchStreamRulesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<TweetsSearchStreamRulesParameter, TweetsSearchStreamRulesResponse>(parameter, cancellationToken);
    }
}
