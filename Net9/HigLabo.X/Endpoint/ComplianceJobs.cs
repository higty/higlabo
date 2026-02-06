using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.X;

public partial class ComplianceJobsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Type { get; set; } = "";
    public string Status { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return "/compliance/jobs";
    }
    Dictionary<string, string> IQueryParameterProperty.CreateQueryParameter()
    {
        var d = new Dictionary<string, string>();
        QueryParameterBuilder.Add(d, "type", this.Type);
        QueryParameterBuilder.Add(d, "status", this.Status);
        return d;
    }
    public override object GetRequestBody()
    {
        return EmptyParameter;
    }
}
public partial class ComplianceJobsResponse : XApiResult<List<XComplianceJob>>
{
}
public partial class XClient
{
    public async ValueTask<ComplianceJobsResponse> ComplianceJobsAsync(string type)
    {
        var p = new ComplianceJobsParameter();
        p.Type = type;
        return await this.SendJsonAsync<ComplianceJobsParameter, ComplianceJobsResponse>(p);
    }
    public async ValueTask<ComplianceJobsResponse> ComplianceJobsAsync(string type, CancellationToken cancellationToken)
    {
        var p = new ComplianceJobsParameter();
        p.Type = type;
        return await this.SendJsonAsync<ComplianceJobsParameter, ComplianceJobsResponse>(p, cancellationToken);
    }
    public async ValueTask<ComplianceJobsResponse> ComplianceJobsAsync(ComplianceJobsParameter parameter)
    {
        return await this.SendJsonAsync<ComplianceJobsParameter, ComplianceJobsResponse>(parameter);
    }
    public async ValueTask<ComplianceJobsResponse> ComplianceJobsAsync(ComplianceJobsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<ComplianceJobsParameter, ComplianceJobsResponse>(parameter, cancellationToken);
    }
}
