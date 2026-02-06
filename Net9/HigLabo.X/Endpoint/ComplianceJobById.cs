using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class ComplianceJobByIdParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Id { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/compliance/jobs/{this.Id}";
    }
    public override object GetRequestBody()
    {
        return EmptyParameter;
    }
}
public partial class ComplianceJobByIdResponse : XApiResult<XComplianceJob>
{
}
public partial class XClient
{
    public async ValueTask<ComplianceJobByIdResponse> ComplianceJobByIdAsync(string id)
    {
        var p = new ComplianceJobByIdParameter();
        p.Id = id;
        return await this.SendJsonAsync<ComplianceJobByIdParameter, ComplianceJobByIdResponse>(p);
    }
    public async ValueTask<ComplianceJobByIdResponse> ComplianceJobByIdAsync(string id, CancellationToken cancellationToken)
    {
        var p = new ComplianceJobByIdParameter();
        p.Id = id;
        return await this.SendJsonAsync<ComplianceJobByIdParameter, ComplianceJobByIdResponse>(p, cancellationToken);
    }
    public async ValueTask<ComplianceJobByIdResponse> ComplianceJobByIdAsync(ComplianceJobByIdParameter parameter)
    {
        return await this.SendJsonAsync<ComplianceJobByIdParameter, ComplianceJobByIdResponse>(parameter);
    }
    public async ValueTask<ComplianceJobByIdResponse> ComplianceJobByIdAsync(ComplianceJobByIdParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<ComplianceJobByIdParameter, ComplianceJobByIdResponse>(parameter, cancellationToken);
    }
}
