using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public class TweetDeleteData
{
    public bool Deleted { get; set; }
}
public partial class TweetDeleteParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "DELETE";
    public string Id { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/tweets/{this.Id}";
    }
    public override object GetRequestBody()
    {
        return EmptyParameter;
    }
}
public partial class TweetDeleteResponse : XApiResult<TweetDeleteData>
{
}
public partial class XClient
{
    public async ValueTask<TweetDeleteResponse> TweetDeleteAsync(string id)
    {
        var p = new TweetDeleteParameter();
        p.Id = id;
        return await this.SendJsonAsync<TweetDeleteParameter, TweetDeleteResponse>(p);
    }
    public async ValueTask<TweetDeleteResponse> TweetDeleteAsync(string id, CancellationToken cancellationToken)
    {
        var p = new TweetDeleteParameter();
        p.Id = id;
        return await this.SendJsonAsync<TweetDeleteParameter, TweetDeleteResponse>(p, cancellationToken);
    }
    public async ValueTask<TweetDeleteResponse> TweetDeleteAsync(TweetDeleteParameter parameter)
    {
        return await this.SendJsonAsync<TweetDeleteParameter, TweetDeleteResponse>(parameter);
    }
    public async ValueTask<TweetDeleteResponse> TweetDeleteAsync(TweetDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<TweetDeleteParameter, TweetDeleteResponse>(parameter, cancellationToken);
    }
}
