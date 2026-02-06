using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public class UsersFollowCreateData
{
    public bool Following { get; set; }
    public bool Pending_Follow { get; set; }
}
public partial class UsersFollowCreateParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "POST";

    public string Id { get; set; } = "";
    public string Target_User_Id { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/users/{this.Id}/following";
    }
    public override object GetRequestBody()
    {
        return new
        {
            target_user_id = this.Target_User_Id,
        };
    }
}
public partial class UsersFollowCreateResponse : XApiResult<UsersFollowCreateData>
{
}
public partial class XClient
{
    public async ValueTask<UsersFollowCreateResponse> UsersFollowCreateAsync(string userId, string targetUserId)
    {
        var p = new UsersFollowCreateParameter();
        p.Id = userId;
        p.Target_User_Id = targetUserId;
        return await this.SendJsonAsync<UsersFollowCreateParameter, UsersFollowCreateResponse>(p);
    }
    public async ValueTask<UsersFollowCreateResponse> UsersFollowCreateAsync(string userId, string targetUserId, CancellationToken cancellationToken)
    {
        var p = new UsersFollowCreateParameter();
        p.Id = userId;
        p.Target_User_Id = targetUserId;
        return await this.SendJsonAsync<UsersFollowCreateParameter, UsersFollowCreateResponse>(p, cancellationToken);
    }
    public async ValueTask<UsersFollowCreateResponse> UsersFollowCreateAsync(UsersFollowCreateParameter parameter)
    {
        return await this.SendJsonAsync<UsersFollowCreateParameter, UsersFollowCreateResponse>(parameter);
    }
    public async ValueTask<UsersFollowCreateResponse> UsersFollowCreateAsync(UsersFollowCreateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<UsersFollowCreateParameter, UsersFollowCreateResponse>(parameter, cancellationToken);
    }
}
