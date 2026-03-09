using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public class UsersMuteDeleteData
{
    public bool Muting { get; set; }
}
public partial class UsersMuteDeleteParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "DELETE";

    public string Source_User_Id { get; set; } = "";
    public string Target_User_Id { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/users/{this.Source_User_Id}/muting/{this.Target_User_Id}";
    }
    public override object GetRequestBody()
    {
        return EmptyParameter;
    }
}
public partial class UsersMuteDeleteResponse : XApiResult<UsersMuteDeleteData>
{
}
public partial class XClient
{
    public async ValueTask<UsersMuteDeleteResponse> UsersMuteDeleteAsync(string sourceUserId, string targetUserId)
    {
        var p = new UsersMuteDeleteParameter();
        p.Source_User_Id = sourceUserId;
        p.Target_User_Id = targetUserId;
        return await this.SendJsonAsync<UsersMuteDeleteParameter, UsersMuteDeleteResponse>(p);
    }
    public async ValueTask<UsersMuteDeleteResponse> UsersMuteDeleteAsync(string sourceUserId, string targetUserId, CancellationToken cancellationToken)
    {
        var p = new UsersMuteDeleteParameter();
        p.Source_User_Id = sourceUserId;
        p.Target_User_Id = targetUserId;
        return await this.SendJsonAsync<UsersMuteDeleteParameter, UsersMuteDeleteResponse>(p, cancellationToken);
    }
    public async ValueTask<UsersMuteDeleteResponse> UsersMuteDeleteAsync(UsersMuteDeleteParameter parameter)
    {
        return await this.SendJsonAsync<UsersMuteDeleteParameter, UsersMuteDeleteResponse>(parameter);
    }
    public async ValueTask<UsersMuteDeleteResponse> UsersMuteDeleteAsync(UsersMuteDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<UsersMuteDeleteParameter, UsersMuteDeleteResponse>(parameter, cancellationToken);
    }
}
