using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Returns a list of invites in the organization.
    /// <seealso href="https://api.openai.com/v1/organization/invites">https://api.openai.com/v1/organization/invites</seealso>
    /// </summary>
    public partial class OrganizationInvitesParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly OrganizationInvitesParameter Empty = new OrganizationInvitesParameter();

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
            return $"/organization/invites";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationInvitesResponse : RestApiDataResponse<List<InviteObject>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationInvitesResponse> OrganizationInvitesAsync()
        {
            return await this.SendJsonAsync<OrganizationInvitesParameter, OrganizationInvitesResponse>(OrganizationInvitesParameter.Empty, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationInvitesResponse> OrganizationInvitesAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationInvitesParameter, OrganizationInvitesResponse>(OrganizationInvitesParameter.Empty, cancellationToken);
        }
        public async ValueTask<OrganizationInvitesResponse> OrganizationInvitesAsync(OrganizationInvitesParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationInvitesParameter, OrganizationInvitesResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationInvitesResponse> OrganizationInvitesAsync(OrganizationInvitesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationInvitesParameter, OrganizationInvitesResponse>(parameter, cancellationToken);
        }
    }
}
