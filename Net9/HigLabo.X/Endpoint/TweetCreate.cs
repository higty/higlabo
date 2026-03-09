using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public class TweetCreateMedia
{
    public List<string> Media_Ids { get; set; } = new();
}
public class TweetCreateReply
{
    public string In_Reply_To_Tweet_Id { get; set; } = "";
}
public class TweetCreatePoll
{
    public int Duration_Minutes { get; set; }
    public List<string> Options { get; set; } = new();
}
public class TweetCreateData
{
    public string Id { get; set; } = "";
    public string Text { get; set; } = "";
    public List<string> Edit_History_Tweet_Ids { get; set; } = new();
}
public partial class TweetCreateParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "POST";

    public string Text { get; set; } = "";
    public string Quote_Tweet_Id { get; set; } = "";
    public string Reply_Settings { get; set; } = "";
    public bool? For_Super_Followers_Only { get; set; }
    public TweetCreateMedia? Media { get; set; }
    public TweetCreateReply? Reply { get; set; }
    public TweetCreatePoll? Poll { get; set; }

    string IRestApiParameter.GetApiPath()
    {
        return "/tweets";
    }
    public override object GetRequestBody()
    {
        return this;
    }
}
public partial class TweetCreateResponse : XApiResult<TweetCreateData>
{
}
public partial class XClient
{
    public async ValueTask<TweetCreateResponse> TweetCreateAsync(string text)
    {
        var p = new TweetCreateParameter();
        p.Text = text;
        return await this.SendJsonAsync<TweetCreateParameter, TweetCreateResponse>(p);
    }
    public async ValueTask<TweetCreateResponse> TweetCreateAsync(string text, CancellationToken cancellationToken)
    {
        var p = new TweetCreateParameter();
        p.Text = text;
        return await this.SendJsonAsync<TweetCreateParameter, TweetCreateResponse>(p, cancellationToken);
    }
    public async ValueTask<TweetCreateResponse> TweetCreateAsync(TweetCreateParameter parameter)
    {
        return await this.SendJsonAsync<TweetCreateParameter, TweetCreateResponse>(parameter);
    }
    public async ValueTask<TweetCreateResponse> TweetCreateAsync(TweetCreateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<TweetCreateParameter, TweetCreateResponse>(parameter, cancellationToken);
    }
}
