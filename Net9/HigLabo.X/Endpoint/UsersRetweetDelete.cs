using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public class UsersRetweetDeleteData
{
    public bool Retweeted { get; set; }
}
public partial class UsersRetweetDeleteParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "DELETE";

    public string Id { get; set; } = "";
    public string Source_Tweet_Id { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/users/{this.Id}/retweets/{this.Source_Tweet_Id}";
    }
    public override object GetRequestBody()
    {
        return EmptyParameter;
    }
}
public partial class UsersRetweetDeleteResponse : XApiResult<UsersRetweetDeleteData>
{
}
public partial class XClient
{
    public async ValueTask<UsersRetweetDeleteResponse> UsersRetweetDeleteAsync(string userId, string sourceTweetId)
    {
        var p = new UsersRetweetDeleteParameter();
        p.Id = userId;
        p.Source_Tweet_Id = sourceTweetId;
        return await this.SendJsonAsync<UsersRetweetDeleteParameter, UsersRetweetDeleteResponse>(p);
    }
    public async ValueTask<UsersRetweetDeleteResponse> UsersRetweetDeleteAsync(string userId, string sourceTweetId, CancellationToken cancellationToken)
    {
        var p = new UsersRetweetDeleteParameter();
        p.Id = userId;
        p.Source_Tweet_Id = sourceTweetId;
        return await this.SendJsonAsync<UsersRetweetDeleteParameter, UsersRetweetDeleteResponse>(p, cancellationToken);
    }
    public async ValueTask<UsersRetweetDeleteResponse> UsersRetweetDeleteAsync(UsersRetweetDeleteParameter parameter)
    {
        return await this.SendJsonAsync<UsersRetweetDeleteParameter, UsersRetweetDeleteResponse>(parameter);
    }
    public async ValueTask<UsersRetweetDeleteResponse> UsersRetweetDeleteAsync(UsersRetweetDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<UsersRetweetDeleteParameter, UsersRetweetDeleteResponse>(parameter, cancellationToken);
    }
}
