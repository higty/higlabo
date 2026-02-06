using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public class ListUnfollowData
{
    public bool Following { get; set; }
}
public partial class ListUnfollowParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "DELETE";

    public string User_Id { get; set; } = "";
    public string List_Id { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/users/{this.User_Id}/followed_lists/{this.List_Id}";
    }
    public override object GetRequestBody()
    {
        return EmptyParameter;
    }
}
public partial class ListUnfollowResponse : XApiResult<ListUnfollowData>
{
}
public partial class XClient
{
    public async ValueTask<ListUnfollowResponse> ListUnfollowAsync(string userId, string listId)
    {
        var p = new ListUnfollowParameter();
        p.User_Id = userId;
        p.List_Id = listId;
        return await this.SendJsonAsync<ListUnfollowParameter, ListUnfollowResponse>(p);
    }
    public async ValueTask<ListUnfollowResponse> ListUnfollowAsync(string userId, string listId, CancellationToken cancellationToken)
    {
        var p = new ListUnfollowParameter();
        p.User_Id = userId;
        p.List_Id = listId;
        return await this.SendJsonAsync<ListUnfollowParameter, ListUnfollowResponse>(p, cancellationToken);
    }
    public async ValueTask<ListUnfollowResponse> ListUnfollowAsync(ListUnfollowParameter parameter)
    {
        return await this.SendJsonAsync<ListUnfollowParameter, ListUnfollowResponse>(parameter);
    }
    public async ValueTask<ListUnfollowResponse> ListUnfollowAsync(ListUnfollowParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<ListUnfollowParameter, ListUnfollowResponse>(parameter, cancellationToken);
    }
}
