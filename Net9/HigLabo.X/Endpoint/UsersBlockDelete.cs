using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public class UsersBlockDeleteData
{
    public bool Blocking { get; set; }
}
public partial class UsersBlockDeleteParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "DELETE";

    public string Source_User_Id { get; set; } = "";
    public string Target_User_Id { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/users/{this.Source_User_Id}/blocking/{this.Target_User_Id}";
    }
    public override object GetRequestBody()
    {
        return EmptyParameter;
    }
}
public partial class UsersBlockDeleteResponse : XApiResult<UsersBlockDeleteData>
{
}
public partial class XClient
{
    public async ValueTask<UsersBlockDeleteResponse> UsersBlockDeleteAsync(string sourceUserId, string targetUserId)
    {
        var p = new UsersBlockDeleteParameter();
        p.Source_User_Id = sourceUserId;
        p.Target_User_Id = targetUserId;
        return await this.SendJsonAsync<UsersBlockDeleteParameter, UsersBlockDeleteResponse>(p);
    }
    public async ValueTask<UsersBlockDeleteResponse> UsersBlockDeleteAsync(string sourceUserId, string targetUserId, CancellationToken cancellationToken)
    {
        var p = new UsersBlockDeleteParameter();
        p.Source_User_Id = sourceUserId;
        p.Target_User_Id = targetUserId;
        return await this.SendJsonAsync<UsersBlockDeleteParameter, UsersBlockDeleteResponse>(p, cancellationToken);
    }
    public async ValueTask<UsersBlockDeleteResponse> UsersBlockDeleteAsync(UsersBlockDeleteParameter parameter)
    {
        return await this.SendJsonAsync<UsersBlockDeleteParameter, UsersBlockDeleteResponse>(parameter);
    }
    public async ValueTask<UsersBlockDeleteResponse> UsersBlockDeleteAsync(UsersBlockDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<UsersBlockDeleteParameter, UsersBlockDeleteResponse>(parameter, cancellationToken);
    }
}
