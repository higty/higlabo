using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Retrieves an invite.
    /// <seealso href="https://api.openai.com/v1/organization/invites/{invite_id}">https://api.openai.com/v1/organization/invites/{invite_id}</seealso>
    /// </summary>
    public partial class OrganizationInviteRetrieveParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the invite to retrieve.
        /// </summary>
        public string Invite_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/invites/{Invite_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationInviteRetrieveResponse : InviteObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationInviteRetrieveResponse> OrganizationInviteRetrieveAsync(string invite_Id)
        {
            var p = new OrganizationInviteRetrieveParameter();
            p.Invite_Id = invite_Id;
            return await this.SendJsonAsync<OrganizationInviteRetrieveParameter, OrganizationInviteRetrieveResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationInviteRetrieveResponse> OrganizationInviteRetrieveAsync(string invite_Id, CancellationToken cancellationToken)
        {
            var p = new OrganizationInviteRetrieveParameter();
            p.Invite_Id = invite_Id;
            return await this.SendJsonAsync<OrganizationInviteRetrieveParameter, OrganizationInviteRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationInviteRetrieveResponse> OrganizationInviteRetrieveAsync(OrganizationInviteRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationInviteRetrieveParameter, OrganizationInviteRetrieveResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationInviteRetrieveResponse> OrganizationInviteRetrieveAsync(OrganizationInviteRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationInviteRetrieveParameter, OrganizationInviteRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
