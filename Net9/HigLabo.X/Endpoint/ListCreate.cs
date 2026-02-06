using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public class ListCreateData
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
}
public partial class ListCreateParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "POST";

    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public bool Private { get; set; }

    string IRestApiParameter.GetApiPath()
    {
        return "/lists";
    }
    public override object GetRequestBody()
    {
        return this;
    }
}
public partial class ListCreateResponse : XApiResult<ListCreateData>
{
}
public partial class XClient
{
    public async ValueTask<ListCreateResponse> ListCreateAsync(string name)
    {
        var p = new ListCreateParameter();
        p.Name = name;
        return await this.SendJsonAsync<ListCreateParameter, ListCreateResponse>(p);
    }
    public async ValueTask<ListCreateResponse> ListCreateAsync(string name, CancellationToken cancellationToken)
    {
        var p = new ListCreateParameter();
        p.Name = name;
        return await this.SendJsonAsync<ListCreateParameter, ListCreateResponse>(p, cancellationToken);
    }
    public async ValueTask<ListCreateResponse> ListCreateAsync(ListCreateParameter parameter)
    {
        return await this.SendJsonAsync<ListCreateParameter, ListCreateResponse>(parameter);
    }
    public async ValueTask<ListCreateResponse> ListCreateAsync(ListCreateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<ListCreateParameter, ListCreateResponse>(parameter, cancellationToken);
    }
}
