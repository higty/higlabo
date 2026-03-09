using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public class ListFollowData
{
    public bool Following { get; set; }
}
public partial class ListFollowParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "POST";

    public string User_Id { get; set; } = "";
    public string List_Id { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/users/{this.User_Id}/followed_lists";
    }
    public override object GetRequestBody()
    {
        return new
        {
            list_id = this.List_Id,
        };
    }
}
public partial class ListFollowResponse : XApiResult<ListFollowData>
{
}
public partial class XClient
{
    public async ValueTask<ListFollowResponse> ListFollowAsync(string userId, string listId)
    {
        var p = new ListFollowParameter();
        p.User_Id = userId;
        p.List_Id = listId;
        return await this.SendJsonAsync<ListFollowParameter, ListFollowResponse>(p);
    }
    public async ValueTask<ListFollowResponse> ListFollowAsync(string userId, string listId, CancellationToken cancellationToken)
    {
        var p = new ListFollowParameter();
        p.User_Id = userId;
        p.List_Id = listId;
        return await this.SendJsonAsync<ListFollowParameter, ListFollowResponse>(p, cancellationToken);
    }
    public async ValueTask<ListFollowResponse> ListFollowAsync(ListFollowParameter parameter)
    {
        return await this.SendJsonAsync<ListFollowParameter, ListFollowResponse>(parameter);
    }
    public async ValueTask<ListFollowResponse> ListFollowAsync(ListFollowParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<ListFollowParameter, ListFollowResponse>(parameter, cancellationToken);
    }
}
