using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public class TweetsSearchStreamRulesAdd
{
    public string Value { get; set; } = "";
    public string Tag { get; set; } = "";
}
public class TweetsSearchStreamRulesDelete
{
    public List<string> Ids { get; set; } = new();
}
public class TweetsSearchStreamRulesCreateDeleteSummary
{
    public int Created { get; set; }
    public int Not_Created { get; set; }
    public int Valid { get; set; }
    public int Invalid { get; set; }
}
public class TweetsSearchStreamRulesCreateDeleteMeta
{
    public TweetsSearchStreamRulesCreateDeleteSummary? Summary { get; set; }
}
public partial class TweetsSearchStreamRulesCreateDeleteParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "POST";

    public List<TweetsSearchStreamRulesAdd> Add { get; set; } = new();
    public TweetsSearchStreamRulesDelete? Delete { get; set; }
    public bool? Dry_Run { get; set; }

    string IRestApiParameter.GetApiPath()
    {
        return "/tweets/search/stream/rules";
    }
    public override object GetRequestBody()
    {
        return this;
    }
}
public partial class TweetsSearchStreamRulesCreateDeleteResponse : XApiResult<List<XRule>>
{
    public new TweetsSearchStreamRulesCreateDeleteMeta? Meta { get; set; }
}
public partial class XClient
{
    public async ValueTask<TweetsSearchStreamRulesCreateDeleteResponse> TweetsSearchStreamRulesCreateDeleteAsync(TweetsSearchStreamRulesCreateDeleteParameter parameter)
    {
        return await this.SendJsonAsync<TweetsSearchStreamRulesCreateDeleteParameter, TweetsSearchStreamRulesCreateDeleteResponse>(parameter);
    }
    public async ValueTask<TweetsSearchStreamRulesCreateDeleteResponse> TweetsSearchStreamRulesCreateDeleteAsync(TweetsSearchStreamRulesCreateDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<TweetsSearchStreamRulesCreateDeleteParameter, TweetsSearchStreamRulesCreateDeleteResponse>(parameter, cancellationToken);
    }
    public async ValueTask<TweetsSearchStreamRulesCreateDeleteResponse> TweetsSearchStreamRulesAddAsync(string ruleValue, string tag)
    {
        var p = new TweetsSearchStreamRulesCreateDeleteParameter();
        p.Add.Add(new TweetsSearchStreamRulesAdd() { Value = ruleValue, Tag = tag });
        return await this.SendJsonAsync<TweetsSearchStreamRulesCreateDeleteParameter, TweetsSearchStreamRulesCreateDeleteResponse>(p);
    }
    public async ValueTask<TweetsSearchStreamRulesCreateDeleteResponse> TweetsSearchStreamRulesAddAsync(string ruleValue, string tag, CancellationToken cancellationToken)
    {
        var p = new TweetsSearchStreamRulesCreateDeleteParameter();
        p.Add.Add(new TweetsSearchStreamRulesAdd() { Value = ruleValue, Tag = tag });
        return await this.SendJsonAsync<TweetsSearchStreamRulesCreateDeleteParameter, TweetsSearchStreamRulesCreateDeleteResponse>(p, cancellationToken);
    }
    public async ValueTask<TweetsSearchStreamRulesCreateDeleteResponse> TweetsSearchStreamRulesDeleteAsync(IEnumerable<string> ids)
    {
        var p = new TweetsSearchStreamRulesCreateDeleteParameter();
        p.Delete = new TweetsSearchStreamRulesDelete() { Ids = ids.ToList() };
        return await this.SendJsonAsync<TweetsSearchStreamRulesCreateDeleteParameter, TweetsSearchStreamRulesCreateDeleteResponse>(p);
    }
    public async ValueTask<TweetsSearchStreamRulesCreateDeleteResponse> TweetsSearchStreamRulesDeleteAsync(IEnumerable<string> ids, CancellationToken cancellationToken)
    {
        var p = new TweetsSearchStreamRulesCreateDeleteParameter();
        p.Delete = new TweetsSearchStreamRulesDelete() { Ids = ids.ToList() };
        return await this.SendJsonAsync<TweetsSearchStreamRulesCreateDeleteParameter, TweetsSearchStreamRulesCreateDeleteResponse>(p, cancellationToken);
    }
}
