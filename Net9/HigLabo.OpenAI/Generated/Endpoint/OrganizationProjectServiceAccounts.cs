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
    /// Returns a list of service accounts in the project.
    /// <seealso href="https://api.openai.com/v1/organization/projects/{project_id}/service_accounts">https://api.openai.com/v1/organization/projects/{project_id}/service_accounts</seealso>
    /// </summary>
    public partial class OrganizationProjectServiceAccountsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
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
        public OrganizationProjectServiceAccountsQueryParameter QueryParameter { get; set; } = new OrganizationProjectServiceAccountsQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/projects/{Project_Id}/service_accounts";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class OrganizationProjectServiceAccountsQueryParameter : IQueryParameter
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
    public partial class OrganizationProjectServiceAccountsResponse : RestApiDataResponse<List<ProjectServiceAccountObject>>
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationProjectServiceAccountsResponse> OrganizationProjectServiceAccountsAsync(string project_Id)
        {
            var p = new OrganizationProjectServiceAccountsParameter();
            p.Project_Id = project_Id;
            return await this.SendJsonAsync<OrganizationProjectServiceAccountsParameter, OrganizationProjectServiceAccountsResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectServiceAccountsResponse> OrganizationProjectServiceAccountsAsync(string project_Id, CancellationToken cancellationToken)
        {
            var p = new OrganizationProjectServiceAccountsParameter();
            p.Project_Id = project_Id;
            return await this.SendJsonAsync<OrganizationProjectServiceAccountsParameter, OrganizationProjectServiceAccountsResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationProjectServiceAccountsResponse> OrganizationProjectServiceAccountsAsync(OrganizationProjectServiceAccountsParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationProjectServiceAccountsParameter, OrganizationProjectServiceAccountsResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectServiceAccountsResponse> OrganizationProjectServiceAccountsAsync(OrganizationProjectServiceAccountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationProjectServiceAccountsParameter, OrganizationProjectServiceAccountsResponse>(parameter, cancellationToken);
        }
    }
}
