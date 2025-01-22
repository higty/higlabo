using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Retrieves an API key in the project.
    /// <seealso href="https://api.openai.com/v1/organization/projects/{project_id}/api_keys/{key_id}">https://api.openai.com/v1/organization/projects/{project_id}/api_keys/{key_id}</seealso>
    /// </summary>
    public partial class OrganizationProjectApiKeyRetrieveParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the project.
        /// </summary>
        public string Project_Id { get; set; } = "";
        /// <summary>
        /// The ID of the API key.
        /// </summary>
        public string Key_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/projects/{Project_Id}/api_keys/{Key_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationProjectApiKeyRetrieveResponse : ProjectApiKeyObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationProjectApiKeyRetrieveResponse> OrganizationProjectApiKeyRetrieveAsync(string project_Id, string key_Id)
        {
            var p = new OrganizationProjectApiKeyRetrieveParameter();
            p.Project_Id = project_Id;
            p.Key_Id = key_Id;
            return await this.SendJsonAsync<OrganizationProjectApiKeyRetrieveParameter, OrganizationProjectApiKeyRetrieveResponse>(p, CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectApiKeyRetrieveResponse> OrganizationProjectApiKeyRetrieveAsync(string project_Id, string key_Id, CancellationToken cancellationToken)
        {
            var p = new OrganizationProjectApiKeyRetrieveParameter();
            p.Project_Id = project_Id;
            p.Key_Id = key_Id;
            return await this.SendJsonAsync<OrganizationProjectApiKeyRetrieveParameter, OrganizationProjectApiKeyRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationProjectApiKeyRetrieveResponse> OrganizationProjectApiKeyRetrieveAsync(OrganizationProjectApiKeyRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationProjectApiKeyRetrieveParameter, OrganizationProjectApiKeyRetrieveResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectApiKeyRetrieveResponse> OrganizationProjectApiKeyRetrieveAsync(OrganizationProjectApiKeyRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationProjectApiKeyRetrieveParameter, OrganizationProjectApiKeyRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
