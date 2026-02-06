using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public class UsersRetweetCreateData
{
    public bool Retweeted { get; set; }
}
public partial class UsersRetweetCreateParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "POST";

    public string Id { get; set; } = "";
    public string Tweet_Id { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/users/{this.Id}/retweets";
    }
    public override object GetRequestBody()
    {
        return new
        {
            tweet_id = this.Tweet_Id,
        };
    }
}
public partial class UsersRetweetCreateResponse : XApiResult<UsersRetweetCreateData>
{
}
public partial class XClient
{
    public async ValueTask<UsersRetweetCreateResponse> UsersRetweetCreateAsync(string userId, string tweetId)
    {
        var p = new UsersRetweetCreateParameter();
        p.Id = userId;
        p.Tweet_Id = tweetId;
        return await this.SendJsonAsync<UsersRetweetCreateParameter, UsersRetweetCreateResponse>(p);
    }
    public async ValueTask<UsersRetweetCreateResponse> UsersRetweetCreateAsync(string userId, string tweetId, CancellationToken cancellationToken)
    {
        var p = new UsersRetweetCreateParameter();
        p.Id = userId;
        p.Tweet_Id = tweetId;
        return await this.SendJsonAsync<UsersRetweetCreateParameter, UsersRetweetCreateResponse>(p, cancellationToken);
    }
    public async ValueTask<UsersRetweetCreateResponse> UsersRetweetCreateAsync(UsersRetweetCreateParameter parameter)
    {
        return await this.SendJsonAsync<UsersRetweetCreateParameter, UsersRetweetCreateResponse>(parameter);
    }
    public async ValueTask<UsersRetweetCreateResponse> UsersRetweetCreateAsync(UsersRetweetCreateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<UsersRetweetCreateParameter, UsersRetweetCreateResponse>(parameter, cancellationToken);
    }
}
