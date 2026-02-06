using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class ComplianceJobCreateParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "POST";

    public string Type { get; set; } = "tweets";
    public string Name { get; set; } = "";
    public bool Resumable { get; set; } = false;

    string IRestApiParameter.GetApiPath()
    {
        return "/compliance/jobs";
    }
    public override object GetRequestBody()
    {
        return this;
    }
}
public partial class ComplianceJobCreateResponse : XApiResult<XComplianceJob>
{
}
public partial class XClient
{
    public async ValueTask<ComplianceJobCreateResponse> ComplianceJobCreateAsync(string type, string name)
    {
        var p = new ComplianceJobCreateParameter();
        p.Type = type;
        p.Name = name;
        return await this.SendJsonAsync<ComplianceJobCreateParameter, ComplianceJobCreateResponse>(p);
    }
    public async ValueTask<ComplianceJobCreateResponse> ComplianceJobCreateAsync(string type, string name, CancellationToken cancellationToken)
    {
        var p = new ComplianceJobCreateParameter();
        p.Type = type;
        p.Name = name;
        return await this.SendJsonAsync<ComplianceJobCreateParameter, ComplianceJobCreateResponse>(p, cancellationToken);
    }
    public async ValueTask<ComplianceJobCreateResponse> ComplianceJobCreateAsync(ComplianceJobCreateParameter parameter)
    {
        return await this.SendJsonAsync<ComplianceJobCreateParameter, ComplianceJobCreateResponse>(parameter);
    }
    public async ValueTask<ComplianceJobCreateResponse> ComplianceJobCreateAsync(ComplianceJobCreateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<ComplianceJobCreateParameter, ComplianceJobCreateResponse>(parameter, cancellationToken);
    }
}
