using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public class ListDeleteData
{
    public bool Deleted { get; set; }
}
public partial class ListDeleteParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "DELETE";

    public string Id { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/lists/{this.Id}";
    }
    public override object GetRequestBody()
    {
        return EmptyParameter;
    }
}
public partial class ListDeleteResponse : XApiResult<ListDeleteData>
{
}
public partial class XClient
{
    public async ValueTask<ListDeleteResponse> ListDeleteAsync(string id)
    {
        var p = new ListDeleteParameter();
        p.Id = id;
        return await this.SendJsonAsync<ListDeleteParameter, ListDeleteResponse>(p);
    }
    public async ValueTask<ListDeleteResponse> ListDeleteAsync(string id, CancellationToken cancellationToken)
    {
        var p = new ListDeleteParameter();
        p.Id = id;
        return await this.SendJsonAsync<ListDeleteParameter, ListDeleteResponse>(p, cancellationToken);
    }
    public async ValueTask<ListDeleteResponse> ListDeleteAsync(ListDeleteParameter parameter)
    {
        return await this.SendJsonAsync<ListDeleteParameter, ListDeleteResponse>(parameter);
    }
    public async ValueTask<ListDeleteResponse> ListDeleteAsync(ListDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<ListDeleteParameter, ListDeleteResponse>(parameter, cancellationToken);
    }
}
