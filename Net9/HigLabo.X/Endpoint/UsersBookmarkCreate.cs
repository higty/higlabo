using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public class UsersBookmarkCreateData
{
    public bool Bookmarked { get; set; }
}
public partial class UsersBookmarkCreateParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "POST";

    public string Id { get; set; } = "";
    public string Tweet_Id { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/users/{this.Id}/bookmarks";
    }
    public override object GetRequestBody()
    {
        return new
        {
            tweet_id = this.Tweet_Id,
        };
    }
}
public partial class UsersBookmarkCreateResponse : XApiResult<UsersBookmarkCreateData>
{
}
public partial class XClient
{
    public async ValueTask<UsersBookmarkCreateResponse> UsersBookmarkCreateAsync(string userId, string tweetId)
    {
        var p = new UsersBookmarkCreateParameter();
        p.Id = userId;
        p.Tweet_Id = tweetId;
        return await this.SendJsonAsync<UsersBookmarkCreateParameter, UsersBookmarkCreateResponse>(p);
    }
    public async ValueTask<UsersBookmarkCreateResponse> UsersBookmarkCreateAsync(string userId, string tweetId, CancellationToken cancellationToken)
    {
        var p = new UsersBookmarkCreateParameter();
        p.Id = userId;
        p.Tweet_Id = tweetId;
        return await this.SendJsonAsync<UsersBookmarkCreateParameter, UsersBookmarkCreateResponse>(p, cancellationToken);
    }
    public async ValueTask<UsersBookmarkCreateResponse> UsersBookmarkCreateAsync(UsersBookmarkCreateParameter parameter)
    {
        return await this.SendJsonAsync<UsersBookmarkCreateParameter, UsersBookmarkCreateResponse>(parameter);
    }
    public async ValueTask<UsersBookmarkCreateResponse> UsersBookmarkCreateAsync(UsersBookmarkCreateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<UsersBookmarkCreateParameter, UsersBookmarkCreateResponse>(parameter, cancellationToken);
    }
}
