using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Delete an invite. If the invite has already been accepted, it cannot be deleted.
    /// <seealso href="https://api.openai.com/v1/organization/invites/{invite_id}">https://api.openai.com/v1/organization/invites/{invite_id}</seealso>
    /// </summary>
    public partial class OrganizationInviteDeleteParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        /// <summary>
        /// The ID of the invite to delete.
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
    public partial class OrganizationInviteDeleteResponse : DeleteObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationInviteDeleteResponse> OrganizationInviteDeleteAsync(string invite_Id)
        {
            var p = new OrganizationInviteDeleteParameter();
            p.Invite_Id = invite_Id;
            return await this.SendJsonAsync<OrganizationInviteDeleteParameter, OrganizationInviteDeleteResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationInviteDeleteResponse> OrganizationInviteDeleteAsync(string invite_Id, CancellationToken cancellationToken)
        {
            var p = new OrganizationInviteDeleteParameter();
            p.Invite_Id = invite_Id;
            return await this.SendJsonAsync<OrganizationInviteDeleteParameter, OrganizationInviteDeleteResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationInviteDeleteResponse> OrganizationInviteDeleteAsync(OrganizationInviteDeleteParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationInviteDeleteParameter, OrganizationInviteDeleteResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationInviteDeleteResponse> OrganizationInviteDeleteAsync(OrganizationInviteDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationInviteDeleteParameter, OrganizationInviteDeleteResponse>(parameter, cancellationToken);
        }
    }
}
