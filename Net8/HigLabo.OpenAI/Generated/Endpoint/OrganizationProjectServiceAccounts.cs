using System.Collections.Generic;
using System.IO;
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
        public QueryParameter QueryParameter { get; set; } = new QueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/projects/{Project_Id}/service_accounts";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationProjectServiceAccountsResponse : RestApiDataResponse<List<ProjectServiceAccountObject>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationProjectServiceAccountsResponse> OrganizationProjectServiceAccountsAsync(string project_Id)
        {
            var p = new OrganizationProjectServiceAccountsParameter();
            p.Project_Id = project_Id;
            return await this.SendJsonAsync<OrganizationProjectServiceAccountsParameter, OrganizationProjectServiceAccountsResponse>(p, CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectServiceAccountsResponse> OrganizationProjectServiceAccountsAsync(string project_Id, CancellationToken cancellationToken)
        {
            var p = new OrganizationProjectServiceAccountsParameter();
            p.Project_Id = project_Id;
            return await this.SendJsonAsync<OrganizationProjectServiceAccountsParameter, OrganizationProjectServiceAccountsResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationProjectServiceAccountsResponse> OrganizationProjectServiceAccountsAsync(OrganizationProjectServiceAccountsParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationProjectServiceAccountsParameter, OrganizationProjectServiceAccountsResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectServiceAccountsResponse> OrganizationProjectServiceAccountsAsync(OrganizationProjectServiceAccountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationProjectServiceAccountsParameter, OrganizationProjectServiceAccountsResponse>(parameter, cancellationToken);
        }
    }
}
