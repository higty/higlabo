using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public class ListMemberAddData
{
    public bool Is_Member { get; set; }
}
public partial class ListMemberAddParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "POST";

    public string Id { get; set; } = "";
    public string User_Id { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/lists/{this.Id}/members";
    }
    public override object GetRequestBody()
    {
        return new
        {
            user_id = this.User_Id,
        };
    }
}
public partial class ListMemberAddResponse : XApiResult<ListMemberAddData>
{
}
public partial class XClient
{
    public async ValueTask<ListMemberAddResponse> ListMemberAddAsync(string listId, string userId)
    {
        var p = new ListMemberAddParameter();
        p.Id = listId;
        p.User_Id = userId;
        return await this.SendJsonAsync<ListMemberAddParameter, ListMemberAddResponse>(p);
    }
    public async ValueTask<ListMemberAddResponse> ListMemberAddAsync(string listId, string userId, CancellationToken cancellationToken)
    {
        var p = new ListMemberAddParameter();
        p.Id = listId;
        p.User_Id = userId;
        return await this.SendJsonAsync<ListMemberAddParameter, ListMemberAddResponse>(p, cancellationToken);
    }
    public async ValueTask<ListMemberAddResponse> ListMemberAddAsync(ListMemberAddParameter parameter)
    {
        return await this.SendJsonAsync<ListMemberAddParameter, ListMemberAddResponse>(parameter);
    }
    public async ValueTask<ListMemberAddResponse> ListMemberAddAsync(ListMemberAddParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<ListMemberAddParameter, ListMemberAddResponse>(parameter, cancellationToken);
    }
}
