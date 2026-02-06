using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public class UsersBookmarkDeleteData
{
    public bool Bookmarked { get; set; }
}
public partial class UsersBookmarkDeleteParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "DELETE";

    public string Id { get; set; } = "";
    public string Tweet_Id { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/users/{this.Id}/bookmarks/{this.Tweet_Id}";
    }
    public override object GetRequestBody()
    {
        return EmptyParameter;
    }
}
public partial class UsersBookmarkDeleteResponse : XApiResult<UsersBookmarkDeleteData>
{
}
public partial class XClient
{
    public async ValueTask<UsersBookmarkDeleteResponse> UsersBookmarkDeleteAsync(string userId, string tweetId)
    {
        var p = new UsersBookmarkDeleteParameter();
        p.Id = userId;
        p.Tweet_Id = tweetId;
        return await this.SendJsonAsync<UsersBookmarkDeleteParameter, UsersBookmarkDeleteResponse>(p);
    }
    public async ValueTask<UsersBookmarkDeleteResponse> UsersBookmarkDeleteAsync(string userId, string tweetId, CancellationToken cancellationToken)
    {
        var p = new UsersBookmarkDeleteParameter();
        p.Id = userId;
        p.Tweet_Id = tweetId;
        return await this.SendJsonAsync<UsersBookmarkDeleteParameter, UsersBookmarkDeleteResponse>(p, cancellationToken);
    }
    public async ValueTask<UsersBookmarkDeleteResponse> UsersBookmarkDeleteAsync(UsersBookmarkDeleteParameter parameter)
    {
        return await this.SendJsonAsync<UsersBookmarkDeleteParameter, UsersBookmarkDeleteResponse>(parameter);
    }
    public async ValueTask<UsersBookmarkDeleteResponse> UsersBookmarkDeleteAsync(UsersBookmarkDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<UsersBookmarkDeleteParameter, UsersBookmarkDeleteResponse>(parameter, cancellationToken);
    }
}
