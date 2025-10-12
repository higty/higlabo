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
        public OrganizationInvitesQueryParameter QueryParameter { get; set; } = new OrganizationInvitesQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/invites";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class OrganizationInvitesQueryParameter : IQueryParameter
    {
        /// <summary>
        /// A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list.
        /// </summary>
        public string? After { get; set; }
        /// <summary>
        /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20.
        /// </summary>
        public int? Limit { get; set; }

        string IQueryParameter.GetQueryString()
        {
            var sb = new StringBuilder();
            if (this.After != null)
            {
                sb.Append($"after={WebUtility.UrlEncode(this.After)}&");
            }
            if (this.Limit != null)
            {
                sb.Append($"limit={this.Limit}&");
            }
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class OrganizationInvitesResponse : RestApiDataResponse<List<InviteObject>>
    {
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
