using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Modifies a project in the organization.
    /// <seealso href="https://api.openai.com/v1/organization/projects/{project_id}">https://api.openai.com/v1/organization/projects/{project_id}</seealso>
    /// </summary>
    public partial class OrganizationProjectModifyParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the project.
        /// </summary>
        public string Project_Id { get; set; } = "";
        /// <summary>
        /// The updated name of the project, this name appears in reports.
        /// </summary>
        public string Name { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/projects/{Project_Id}";
        }
        public override object GetRequestBody()
        {
            return new {
            	name = this.Name,
            };
        }
    }
    public partial class OrganizationProjectModifyResponse : ProjectObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationProjectModifyResponse> OrganizationProjectModifyAsync(string project_Id, string name)
        {
            var p = new OrganizationProjectModifyParameter();
            p.Project_Id = project_Id;
            p.Name = name;
            return await this.SendJsonAsync<OrganizationProjectModifyParameter, OrganizationProjectModifyResponse>(p, CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectModifyResponse> OrganizationProjectModifyAsync(string project_Id, string name, CancellationToken cancellationToken)
        {
            var p = new OrganizationProjectModifyParameter();
            p.Project_Id = project_Id;
            p.Name = name;
            return await this.SendJsonAsync<OrganizationProjectModifyParameter, OrganizationProjectModifyResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationProjectModifyResponse> OrganizationProjectModifyAsync(OrganizationProjectModifyParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationProjectModifyParameter, OrganizationProjectModifyResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectModifyResponse> OrganizationProjectModifyAsync(OrganizationProjectModifyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationProjectModifyParameter, OrganizationProjectModifyResponse>(parameter, cancellationToken);
        }
    }
}
