using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Creates a new service account in the project. This also returns an unredacted API key for the service account.
    /// <seealso href="https://api.openai.com/v1/organization/projects/{project_id}/service_accounts">https://api.openai.com/v1/organization/projects/{project_id}/service_accounts</seealso>
    /// </summary>
    public partial class OrganizationProjectServiceAccountCreateParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the project.
        /// </summary>
        public string Project_Id { get; set; } = "";
        /// <summary>
        /// The name of the service account being created.
        /// </summary>
        public string Name { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/projects/{Project_Id}/service_accounts";
        }
        public override object GetRequestBody()
        {
            return new {
            	name = this.Name,
            };
        }
    }
    public partial class OrganizationProjectServiceAccountCreateResponse : ProjectServiceAccountObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationProjectServiceAccountCreateResponse> OrganizationProjectServiceAccountCreateAsync(string project_Id, string name)
        {
            var p = new OrganizationProjectServiceAccountCreateParameter();
            p.Project_Id = project_Id;
            p.Name = name;
            return await this.SendJsonAsync<OrganizationProjectServiceAccountCreateParameter, OrganizationProjectServiceAccountCreateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectServiceAccountCreateResponse> OrganizationProjectServiceAccountCreateAsync(string project_Id, string name, CancellationToken cancellationToken)
        {
            var p = new OrganizationProjectServiceAccountCreateParameter();
            p.Project_Id = project_Id;
            p.Name = name;
            return await this.SendJsonAsync<OrganizationProjectServiceAccountCreateParameter, OrganizationProjectServiceAccountCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationProjectServiceAccountCreateResponse> OrganizationProjectServiceAccountCreateAsync(OrganizationProjectServiceAccountCreateParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationProjectServiceAccountCreateParameter, OrganizationProjectServiceAccountCreateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectServiceAccountCreateResponse> OrganizationProjectServiceAccountCreateAsync(OrganizationProjectServiceAccountCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationProjectServiceAccountCreateParameter, OrganizationProjectServiceAccountCreateResponse>(parameter, cancellationToken);
        }
    }
}
