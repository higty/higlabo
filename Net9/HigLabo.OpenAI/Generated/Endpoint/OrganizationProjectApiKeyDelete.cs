using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Deletes an API key from the project.
    /// <seealso href="https://api.openai.com/v1/organization/projects/{project_id}/api_keys/{key_id}">https://api.openai.com/v1/organization/projects/{project_id}/api_keys/{key_id}</seealso>
    /// </summary>
    public partial class OrganizationProjectApiKeyDeleteParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        /// <summary>
        /// The ID of the API key.
        /// </summary>
        public string Key_Id { get; set; } = "";
        /// <summary>
        /// The ID of the project.
        /// </summary>
        public string Project_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/projects/{Project_Id}/api_keys/{Key_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationProjectApiKeyDeleteResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationProjectApiKeyDeleteResponse> OrganizationProjectApiKeyDeleteAsync(string key_Id, string project_Id)
        {
            var p = new OrganizationProjectApiKeyDeleteParameter();
            p.Key_Id = key_Id;
            p.Project_Id = project_Id;
            return await this.SendJsonAsync<OrganizationProjectApiKeyDeleteParameter, OrganizationProjectApiKeyDeleteResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectApiKeyDeleteResponse> OrganizationProjectApiKeyDeleteAsync(string key_Id, string project_Id, CancellationToken cancellationToken)
        {
            var p = new OrganizationProjectApiKeyDeleteParameter();
            p.Key_Id = key_Id;
            p.Project_Id = project_Id;
            return await this.SendJsonAsync<OrganizationProjectApiKeyDeleteParameter, OrganizationProjectApiKeyDeleteResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationProjectApiKeyDeleteResponse> OrganizationProjectApiKeyDeleteAsync(OrganizationProjectApiKeyDeleteParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationProjectApiKeyDeleteParameter, OrganizationProjectApiKeyDeleteResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectApiKeyDeleteResponse> OrganizationProjectApiKeyDeleteAsync(OrganizationProjectApiKeyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationProjectApiKeyDeleteParameter, OrganizationProjectApiKeyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
