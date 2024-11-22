using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

/// <summary>
/// Lists all of the users in the organization.
/// <seealso href="https://api.openai.com/v1/organization/users">https://api.openai.com/v1/organization/users</seealso>
/// </summary>
public partial class OrganizationUsersParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
{
    internal static readonly OrganizationUsersParameter Empty = new OrganizationUsersParameter();

    string IRestApiParameter.HttpMethod { get; } = "GET";
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
        return $"/organization/users";
    }
    public override object GetRequestBody()
    {
        return EmptyParameter;
    }
}
public partial class OrganizationUsersResponse : RestApiDataResponse<List<UserObject>>
{
    public string First_Id { get; set; } = "";
    public string Last_Id { get; set; } = "";
    public bool Has_More { get; set; }
}
public partial class OpenAIClient
{
    public async ValueTask<OrganizationUsersResponse> OrganizationUsersAsync()
    {
        return await this.SendJsonAsync<OrganizationUsersParameter, OrganizationUsersResponse>(OrganizationUsersParameter.Empty, CancellationToken.None);
    }
    public async ValueTask<OrganizationUsersResponse> OrganizationUsersAsync(CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<OrganizationUsersParameter, OrganizationUsersResponse>(OrganizationUsersParameter.Empty, cancellationToken);
    }
    public async ValueTask<OrganizationUsersResponse> OrganizationUsersAsync(OrganizationUsersParameter parameter)
    {
        return await this.SendJsonAsync<OrganizationUsersParameter, OrganizationUsersResponse>(parameter, CancellationToken.None);
    }
    public async ValueTask<OrganizationUsersResponse> OrganizationUsersAsync(OrganizationUsersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<OrganizationUsersParameter, OrganizationUsersResponse>(parameter, cancellationToken);
    }
}
