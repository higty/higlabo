using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

/// <summary>
/// Returns a list of users in the project.
/// <seealso href="https://api.openai.com/v1/organization/projects/{project_id}/users">https://api.openai.com/v1/organization/projects/{project_id}/users</seealso>
/// </summary>
public partial class OrganizationProjectUsersParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";
    /// <summary>
    /// The ID of the project.
    /// </summary>
    public string Project_Id { get; set; } = "";
    IQueryParameter IQueryParameterProperty.QueryParameter
    {
        get
        {
            return this.QueryParameter;
        }
    }
    public QueryParameter QueryParameter { get; set; } = new QueryParameter();

    string IRestApiParameter.GetApiPath()
    {
        return $"/organization/projects/{Project_Id}/users";
    }
    public override object GetRequestBody()
    {
        return EmptyParameter;
    }
}
public partial class OrganizationProjectUsersResponse : RestApiDataResponse<List<ProjectUserObject>>
{
    public string First_Id { get; set; } = "";
    public string Last_Id { get; set; } = "";
    public bool Has_More { get; set; }
}
public partial class OpenAIClient
{
    public async ValueTask<OrganizationProjectUsersResponse> OrganizationProjectUsersAsync(string project_Id)
    {
        var p = new OrganizationProjectUsersParameter();
        p.Project_Id = project_Id;
        return await this.SendJsonAsync<OrganizationProjectUsersParameter, OrganizationProjectUsersResponse>(p, CancellationToken.None);
    }
    public async ValueTask<OrganizationProjectUsersResponse> OrganizationProjectUsersAsync(string project_Id, CancellationToken cancellationToken)
    {
        var p = new OrganizationProjectUsersParameter();
        p.Project_Id = project_Id;
        return await this.SendJsonAsync<OrganizationProjectUsersParameter, OrganizationProjectUsersResponse>(p, cancellationToken);
    }
    public async ValueTask<OrganizationProjectUsersResponse> OrganizationProjectUsersAsync(OrganizationProjectUsersParameter parameter)
    {
        return await this.SendJsonAsync<OrganizationProjectUsersParameter, OrganizationProjectUsersResponse>(parameter, CancellationToken.None);
    }
    public async ValueTask<OrganizationProjectUsersResponse> OrganizationProjectUsersAsync(OrganizationProjectUsersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<OrganizationProjectUsersParameter, OrganizationProjectUsersResponse>(parameter, cancellationToken);
    }
}
