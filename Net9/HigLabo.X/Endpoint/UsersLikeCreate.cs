using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public class UsersLikeCreateData
{
    public bool Liked { get; set; }
}
public partial class UsersLikeCreateParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "POST";

    public string Id { get; set; } = "";
    public string Tweet_Id { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/users/{this.Id}/likes";
    }
    public override object GetRequestBody()
    {
        return new
        {
            tweet_id = this.Tweet_Id,
        };
    }
}
public partial class UsersLikeCreateResponse : XApiResult<UsersLikeCreateData>
{
}
public partial class XClient
{
    public async ValueTask<UsersLikeCreateResponse> UsersLikeCreateAsync(string userId, string tweetId)
    {
        var p = new UsersLikeCreateParameter();
        p.Id = userId;
        p.Tweet_Id = tweetId;
        return await this.SendJsonAsync<UsersLikeCreateParameter, UsersLikeCreateResponse>(p);
    }
    public async ValueTask<UsersLikeCreateResponse> UsersLikeCreateAsync(string userId, string tweetId, CancellationToken cancellationToken)
    {
        var p = new UsersLikeCreateParameter();
        p.Id = userId;
        p.Tweet_Id = tweetId;
        return await this.SendJsonAsync<UsersLikeCreateParameter, UsersLikeCreateResponse>(p, cancellationToken);
    }
    public async ValueTask<UsersLikeCreateResponse> UsersLikeCreateAsync(UsersLikeCreateParameter parameter)
    {
        return await this.SendJsonAsync<UsersLikeCreateParameter, UsersLikeCreateResponse>(parameter);
    }
    public async ValueTask<UsersLikeCreateResponse> UsersLikeCreateAsync(UsersLikeCreateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<UsersLikeCreateParameter, UsersLikeCreateResponse>(parameter, cancellationToken);
    }
}
