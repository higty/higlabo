using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public class UsersLikeDeleteData
{
    public bool Liked { get; set; }
}
public partial class UsersLikeDeleteParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "DELETE";

    public string Id { get; set; } = "";
    public string Tweet_Id { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/users/{this.Id}/likes/{this.Tweet_Id}";
    }
    public override object GetRequestBody()
    {
        return EmptyParameter;
    }
}
public partial class UsersLikeDeleteResponse : XApiResult<UsersLikeDeleteData>
{
}
public partial class XClient
{
    public async ValueTask<UsersLikeDeleteResponse> UsersLikeDeleteAsync(string userId, string tweetId)
    {
        var p = new UsersLikeDeleteParameter();
        p.Id = userId;
        p.Tweet_Id = tweetId;
        return await this.SendJsonAsync<UsersLikeDeleteParameter, UsersLikeDeleteResponse>(p);
    }
    public async ValueTask<UsersLikeDeleteResponse> UsersLikeDeleteAsync(string userId, string tweetId, CancellationToken cancellationToken)
    {
        var p = new UsersLikeDeleteParameter();
        p.Id = userId;
        p.Tweet_Id = tweetId;
        return await this.SendJsonAsync<UsersLikeDeleteParameter, UsersLikeDeleteResponse>(p, cancellationToken);
    }
    public async ValueTask<UsersLikeDeleteResponse> UsersLikeDeleteAsync(UsersLikeDeleteParameter parameter)
    {
        return await this.SendJsonAsync<UsersLikeDeleteParameter, UsersLikeDeleteResponse>(parameter);
    }
    public async ValueTask<UsersLikeDeleteResponse> UsersLikeDeleteAsync(UsersLikeDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<UsersLikeDeleteParameter, UsersLikeDeleteResponse>(parameter, cancellationToken);
    }
}
