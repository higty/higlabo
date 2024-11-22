using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

/// <summary>
/// Create an invite for a user to the organization. The invite must be accepted by the user before they have access to the organization.
/// <seealso href="https://api.openai.com/v1/organization/invites">https://api.openai.com/v1/organization/invites</seealso>
/// </summary>
public partial class OrganizationInviteCreateParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "POST";
    /// <summary>
    /// Send an email to this address
    /// </summary>
    public string Email { get; set; } = "";
    /// <summary>
    /// owner or reader
    /// </summary>
    public string Role { get; set; } = "";

    string IRestApiParameter.GetApiPath()
    {
        return $"/organization/invites";
    }
    public override object GetRequestBody()
    {
        return new {
        	email = this.Email,
        	role = this.Role,
        };
    }
}
public partial class OrganizationInviteCreateResponse : InviteObjectResponse
{
}
public partial class OpenAIClient
{
    public async ValueTask<OrganizationInviteCreateResponse> OrganizationInviteCreateAsync(string email, string role)
    {
        var p = new OrganizationInviteCreateParameter();
        p.Email = email;
        p.Role = role;
        return await this.SendJsonAsync<OrganizationInviteCreateParameter, OrganizationInviteCreateResponse>(p, CancellationToken.None);
    }
    public async ValueTask<OrganizationInviteCreateResponse> OrganizationInviteCreateAsync(string email, string role, CancellationToken cancellationToken)
    {
        var p = new OrganizationInviteCreateParameter();
        p.Email = email;
        p.Role = role;
        return await this.SendJsonAsync<OrganizationInviteCreateParameter, OrganizationInviteCreateResponse>(p, cancellationToken);
    }
    public async ValueTask<OrganizationInviteCreateResponse> OrganizationInviteCreateAsync(OrganizationInviteCreateParameter parameter)
    {
        return await this.SendJsonAsync<OrganizationInviteCreateParameter, OrganizationInviteCreateResponse>(parameter, CancellationToken.None);
    }
    public async ValueTask<OrganizationInviteCreateResponse> OrganizationInviteCreateAsync(OrganizationInviteCreateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<OrganizationInviteCreateParameter, OrganizationInviteCreateResponse>(parameter, cancellationToken);
    }
}
