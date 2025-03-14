using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Returns a list of API keys in the project.
    /// <seealso href="https://api.openai.com/v1/organization/projects/{project_id}/api_keys">https://api.openai.com/v1/organization/projects/{project_id}/api_keys</seealso>
    /// </summary>
    public partial class OrganizationProjectApiKeysParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
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
            return $"/organization/projects/{Project_Id}/api_keys";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationProjectApiKeysResponse : RestApiDataResponse<List<ProjectApiKeyObject>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationProjectApiKeysResponse> OrganizationProjectApiKeysAsync(string project_Id)
        {
            var p = new OrganizationProjectApiKeysParameter();
            p.Project_Id = project_Id;
            return await this.SendJsonAsync<OrganizationProjectApiKeysParameter, OrganizationProjectApiKeysResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectApiKeysResponse> OrganizationProjectApiKeysAsync(string project_Id, CancellationToken cancellationToken)
        {
            var p = new OrganizationProjectApiKeysParameter();
            p.Project_Id = project_Id;
            return await this.SendJsonAsync<OrganizationProjectApiKeysParameter, OrganizationProjectApiKeysResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationProjectApiKeysResponse> OrganizationProjectApiKeysAsync(OrganizationProjectApiKeysParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationProjectApiKeysParameter, OrganizationProjectApiKeysResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectApiKeysResponse> OrganizationProjectApiKeysAsync(OrganizationProjectApiKeysParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationProjectApiKeysParameter, OrganizationProjectApiKeysResponse>(parameter, cancellationToken);
        }
    }
}
