using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public class UsersBlockCreateData
{
    public bool Blocking { get; set; }
}
public partial class UsersBlockCreateParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "POST";

    public string Id { get; set; } = "";
    public string Target_User_Id { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/users/{this.Id}/blocking";
    }
    public override object GetRequestBody()
    {
        return new
        {
            target_user_id = this.Target_User_Id,
        };
    }
}
public partial class UsersBlockCreateResponse : XApiResult<UsersBlockCreateData>
{
}
public partial class XClient
{
    public async ValueTask<UsersBlockCreateResponse> UsersBlockCreateAsync(string userId, string targetUserId)
    {
        var p = new UsersBlockCreateParameter();
        p.Id = userId;
        p.Target_User_Id = targetUserId;
        return await this.SendJsonAsync<UsersBlockCreateParameter, UsersBlockCreateResponse>(p);
    }
    public async ValueTask<UsersBlockCreateResponse> UsersBlockCreateAsync(string userId, string targetUserId, CancellationToken cancellationToken)
    {
        var p = new UsersBlockCreateParameter();
        p.Id = userId;
        p.Target_User_Id = targetUserId;
        return await this.SendJsonAsync<UsersBlockCreateParameter, UsersBlockCreateResponse>(p, cancellationToken);
    }
    public async ValueTask<UsersBlockCreateResponse> UsersBlockCreateAsync(UsersBlockCreateParameter parameter)
    {
        return await this.SendJsonAsync<UsersBlockCreateParameter, UsersBlockCreateResponse>(parameter);
    }
    public async ValueTask<UsersBlockCreateResponse> UsersBlockCreateAsync(UsersBlockCreateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<UsersBlockCreateParameter, UsersBlockCreateResponse>(parameter, cancellationToken);
    }
}
