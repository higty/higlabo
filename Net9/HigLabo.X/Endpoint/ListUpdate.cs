using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public class ListUpdateData
{
    public bool Updated { get; set; }
}
public partial class ListUpdateParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "PUT";

    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public bool? Private { get; set; }

    string IRestApiParameter.GetApiPath()
    {
        return $"/lists/{this.Id}";
    }
    public override object GetRequestBody()
    {
        return this;
    }
}
public partial class ListUpdateResponse : XApiResult<ListUpdateData>
{
}
public partial class XClient
{
    public async ValueTask<ListUpdateResponse> ListUpdateAsync(ListUpdateParameter parameter)
    {
        return await this.SendJsonAsync<ListUpdateParameter, ListUpdateResponse>(parameter);
    }
    public async ValueTask<ListUpdateResponse> ListUpdateAsync(ListUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<ListUpdateParameter, ListUpdateResponse>(parameter, cancellationToken);
    }
}
