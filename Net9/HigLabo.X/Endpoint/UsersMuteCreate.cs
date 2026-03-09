using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public class UsersMuteCreateData
{
    public bool Muting { get; set; }
}
public partial class UsersMuteCreateParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "POST";

    public string Id { get; set; } = "";
    public string Target_User_Id { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/users/{this.Id}/muting";
    }
    public override object GetRequestBody()
    {
        return new
        {
            target_user_id = this.Target_User_Id,
        };
    }
}
public partial class UsersMuteCreateResponse : XApiResult<UsersMuteCreateData>
{
}
public partial class XClient
{
    public async ValueTask<UsersMuteCreateResponse> UsersMuteCreateAsync(string userId, string targetUserId)
    {
        var p = new UsersMuteCreateParameter();
        p.Id = userId;
        p.Target_User_Id = targetUserId;
        return await this.SendJsonAsync<UsersMuteCreateParameter, UsersMuteCreateResponse>(p);
    }
    public async ValueTask<UsersMuteCreateResponse> UsersMuteCreateAsync(string userId, string targetUserId, CancellationToken cancellationToken)
    {
        var p = new UsersMuteCreateParameter();
        p.Id = userId;
        p.Target_User_Id = targetUserId;
        return await this.SendJsonAsync<UsersMuteCreateParameter, UsersMuteCreateResponse>(p, cancellationToken);
    }
    public async ValueTask<UsersMuteCreateResponse> UsersMuteCreateAsync(UsersMuteCreateParameter parameter)
    {
        return await this.SendJsonAsync<UsersMuteCreateParameter, UsersMuteCreateResponse>(parameter);
    }
    public async ValueTask<UsersMuteCreateResponse> UsersMuteCreateAsync(UsersMuteCreateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<UsersMuteCreateParameter, UsersMuteCreateResponse>(parameter, cancellationToken);
    }
}
