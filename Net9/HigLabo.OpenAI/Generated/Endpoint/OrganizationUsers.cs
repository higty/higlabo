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
        public OrganizationUsersQueryParameter QueryParameter { get; set; } = new OrganizationUsersQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/users";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class OrganizationUsersQueryParameter : IQueryParameter
    {
        /// <summary>
        /// A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list.
        /// </summary>
        public string? After { get; set; }
        /// <summary>
        /// Filter by the email address of users.
        /// </summary>
        public List<string>? Emails { get; set; }
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
            if (this.Emails != null)
            {
                foreach (var item in this.Emails)
                {
                    sb.Append($"emails[]={item}&");
                }
            }
            if (this.Limit != null)
            {
                sb.Append($"limit={this.Limit}&");
            }
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class OrganizationUsersResponse : RestApiDataResponse<List<UserObject>>
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationUsersResponse> OrganizationUsersAsync()
        {
            return await this.SendJsonAsync<OrganizationUsersParameter, OrganizationUsersResponse>(OrganizationUsersParameter.Empty, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationUsersResponse> OrganizationUsersAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationUsersParameter, OrganizationUsersResponse>(OrganizationUsersParameter.Empty, cancellationToken);
        }
        public async ValueTask<OrganizationUsersResponse> OrganizationUsersAsync(OrganizationUsersParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationUsersParameter, OrganizationUsersResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationUsersResponse> OrganizationUsersAsync(OrganizationUsersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationUsersParameter, OrganizationUsersResponse>(parameter, cancellationToken);
        }
    }
}
