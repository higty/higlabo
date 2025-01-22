using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Retrieves a project.
    /// <seealso href="https://api.openai.com/v1/organization/projects/{project_id}">https://api.openai.com/v1/organization/projects/{project_id}</seealso>
    /// </summary>
    public partial class OrganizationProjectRetrieveParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the project.
        /// </summary>
        public string Project_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/projects/{Project_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationProjectRetrieveResponse : ProjectObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationProjectRetrieveResponse> OrganizationProjectRetrieveAsync(string project_Id)
        {
            var p = new OrganizationProjectRetrieveParameter();
            p.Project_Id = project_Id;
            return await this.SendJsonAsync<OrganizationProjectRetrieveParameter, OrganizationProjectRetrieveResponse>(p, CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectRetrieveResponse> OrganizationProjectRetrieveAsync(string project_Id, CancellationToken cancellationToken)
        {
            var p = new OrganizationProjectRetrieveParameter();
            p.Project_Id = project_Id;
            return await this.SendJsonAsync<OrganizationProjectRetrieveParameter, OrganizationProjectRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationProjectRetrieveResponse> OrganizationProjectRetrieveAsync(OrganizationProjectRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationProjectRetrieveParameter, OrganizationProjectRetrieveResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectRetrieveResponse> OrganizationProjectRetrieveAsync(OrganizationProjectRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationProjectRetrieveParameter, OrganizationProjectRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
