using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class TweetsSearchStreamParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    internal static readonly TweetsSearchStreamParameter Empty = new TweetsSearchStreamParameter();
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public int? Backfill_Minutes { get; set; }
    public string Expansions { get; set; } = "";
    public List<TweetField> TweetFieldList { get; init; } = new();
    public string Tweet_Fields { get; set; } = "";
    public List<UserField> UserFieldList { get; init; } = new();
    public string User_Fields { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return "/tweets/search/stream";
    }
    Dictionary<string, string> IQueryParameterProperty.CreateQueryParameter()
    {
        var d = new Dictionary<string, string>();
        QueryParameterBuilder.AddValue(d, "backfill_minutes", this.Backfill_Minutes);
        QueryParameterBuilder.Add(d, "expansions", this.Expansions);
        QueryParameterBuilder.AddField(d, "tweet.fields", this.TweetFieldList, this.Tweet_Fields);
        QueryParameterBuilder.AddField(d, "user.fields", this.UserFieldList, this.User_Fields);
        return d;
    }
    public override object GetRequestBody()
    {
        return EmptyParameter;
    }
}
public partial class XClient
{
    public async IAsyncEnumerable<XFilteredStreamResponse> TweetsSearchStreamAsync([System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await foreach (var item in this.GetFilteredStreamAsync(TweetsSearchStreamParameter.Empty, cancellationToken))
        {
            yield return item;
        }
    }
    public async IAsyncEnumerable<XFilteredStreamResponse> TweetsSearchStreamAsync(TweetsSearchStreamParameter parameter, [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await foreach (var item in this.GetFilteredStreamAsync(parameter, cancellationToken))
        {
            yield return item;
        }
    }
}
