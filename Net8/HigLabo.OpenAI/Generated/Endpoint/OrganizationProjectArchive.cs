using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Archives a project in the organization. Archived projects cannot be used or updated.
    /// <seealso href="https://api.openai.com/v1/organization/projects/{project_id}/archive">https://api.openai.com/v1/organization/projects/{project_id}/archive</seealso>
    /// </summary>
    public partial class OrganizationProjectArchiveParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the project.
        /// </summary>
        public string Project_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/projects/{Project_Id}/archive";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationProjectArchiveResponse : ProjectObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationProjectArchiveResponse> OrganizationProjectArchiveAsync(string project_Id)
        {
            var p = new OrganizationProjectArchiveParameter();
            p.Project_Id = project_Id;
            return await this.SendJsonAsync<OrganizationProjectArchiveParameter, OrganizationProjectArchiveResponse>(p, CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectArchiveResponse> OrganizationProjectArchiveAsync(string project_Id, CancellationToken cancellationToken)
        {
            var p = new OrganizationProjectArchiveParameter();
            p.Project_Id = project_Id;
            return await this.SendJsonAsync<OrganizationProjectArchiveParameter, OrganizationProjectArchiveResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationProjectArchiveResponse> OrganizationProjectArchiveAsync(OrganizationProjectArchiveParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationProjectArchiveParameter, OrganizationProjectArchiveResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectArchiveResponse> OrganizationProjectArchiveAsync(OrganizationProjectArchiveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationProjectArchiveParameter, OrganizationProjectArchiveResponse>(parameter, cancellationToken);
        }
    }
}
