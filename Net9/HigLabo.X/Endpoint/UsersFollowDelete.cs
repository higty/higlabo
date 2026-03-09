using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public class UsersFollowDeleteData
{
    public bool Following { get; set; }
}
public partial class UsersFollowDeleteParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "DELETE";

    public string Source_User_Id { get; set; } = "";
    public string Target_User_Id { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/users/{this.Source_User_Id}/following/{this.Target_User_Id}";
    }
    public override object GetRequestBody()
    {
        return EmptyParameter;
    }
}
public partial class UsersFollowDeleteResponse : XApiResult<UsersFollowDeleteData>
{
}
public partial class XClient
{
    public async ValueTask<UsersFollowDeleteResponse> UsersFollowDeleteAsync(string sourceUserId, string targetUserId)
    {
        var p = new UsersFollowDeleteParameter();
        p.Source_User_Id = sourceUserId;
        p.Target_User_Id = targetUserId;
        return await this.SendJsonAsync<UsersFollowDeleteParameter, UsersFollowDeleteResponse>(p);
    }
    public async ValueTask<UsersFollowDeleteResponse> UsersFollowDeleteAsync(string sourceUserId, string targetUserId, CancellationToken cancellationToken)
    {
        var p = new UsersFollowDeleteParameter();
        p.Source_User_Id = sourceUserId;
        p.Target_User_Id = targetUserId;
        return await this.SendJsonAsync<UsersFollowDeleteParameter, UsersFollowDeleteResponse>(p, cancellationToken);
    }
    public async ValueTask<UsersFollowDeleteResponse> UsersFollowDeleteAsync(UsersFollowDeleteParameter parameter)
    {
        return await this.SendJsonAsync<UsersFollowDeleteParameter, UsersFollowDeleteResponse>(parameter);
    }
    public async ValueTask<UsersFollowDeleteResponse> UsersFollowDeleteAsync(UsersFollowDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<UsersFollowDeleteParameter, UsersFollowDeleteResponse>(parameter, cancellationToken);
    }
}
