using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

/// <summary>
/// Create a new project in the organization. Projects can be created and archived, but cannot be deleted.
/// <seealso href="https://api.openai.com/v1/organization/projects">https://api.openai.com/v1/organization/projects</seealso>
/// </summary>
public partial class OrganizationProjectCreateParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "POST";
    /// <summary>
    /// The friendly name of the project, this name appears in reports.
    /// </summary>
    public string Name { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/organization/projects";
    }
    public override object GetRequestBody()
    {
        return new {
        	name = this.Name,
        };
    }
}
public partial class OrganizationProjectCreateResponse : ProjectObjectResponse
{
}
public partial class OpenAIClient
{
    public async ValueTask<OrganizationProjectCreateResponse> OrganizationProjectCreateAsync(string name)
    {
        var p = new OrganizationProjectCreateParameter();
        p.Name = name;
        return await this.SendJsonAsync<OrganizationProjectCreateParameter, OrganizationProjectCreateResponse>(p, CancellationToken.None);
    }
    public async ValueTask<OrganizationProjectCreateResponse> OrganizationProjectCreateAsync(string name, CancellationToken cancellationToken)
    {
        var p = new OrganizationProjectCreateParameter();
        p.Name = name;
        return await this.SendJsonAsync<OrganizationProjectCreateParameter, OrganizationProjectCreateResponse>(p, cancellationToken);
    }
    public async ValueTask<OrganizationProjectCreateResponse> OrganizationProjectCreateAsync(OrganizationProjectCreateParameter parameter)
    {
        return await this.SendJsonAsync<OrganizationProjectCreateParameter, OrganizationProjectCreateResponse>(parameter, CancellationToken.None);
    }
    public async ValueTask<OrganizationProjectCreateResponse> OrganizationProjectCreateAsync(OrganizationProjectCreateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<OrganizationProjectCreateParameter, OrganizationProjectCreateResponse>(parameter, cancellationToken);
    }
}
