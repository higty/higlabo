using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public class ListMemberRemoveData
{
    public bool Is_Member { get; set; }
}
public partial class ListMemberRemoveParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "DELETE";

    public string List_Id { get; set; } = "";
    public string User_Id { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/lists/{this.List_Id}/members/{this.User_Id}";
    }
    public override object GetRequestBody()
    {
        return EmptyParameter;
    }
}
public partial class ListMemberRemoveResponse : XApiResult<ListMemberRemoveData>
{
}
public partial class XClient
{
    public async ValueTask<ListMemberRemoveResponse> ListMemberRemoveAsync(string listId, string userId)
    {
        var p = new ListMemberRemoveParameter();
        p.List_Id = listId;
        p.User_Id = userId;
        return await this.SendJsonAsync<ListMemberRemoveParameter, ListMemberRemoveResponse>(p);
    }
    public async ValueTask<ListMemberRemoveResponse> ListMemberRemoveAsync(string listId, string userId, CancellationToken cancellationToken)
    {
        var p = new ListMemberRemoveParameter();
        p.List_Id = listId;
        p.User_Id = userId;
        return await this.SendJsonAsync<ListMemberRemoveParameter, ListMemberRemoveResponse>(p, cancellationToken);
    }
    public async ValueTask<ListMemberRemoveResponse> ListMemberRemoveAsync(ListMemberRemoveParameter parameter)
    {
        return await this.SendJsonAsync<ListMemberRemoveParameter, ListMemberRemoveResponse>(parameter);
    }
    public async ValueTask<ListMemberRemoveResponse> ListMemberRemoveAsync(ListMemberRemoveParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<ListMemberRemoveParameter, ListMemberRemoveResponse>(parameter, cancellationToken);
    }
}
