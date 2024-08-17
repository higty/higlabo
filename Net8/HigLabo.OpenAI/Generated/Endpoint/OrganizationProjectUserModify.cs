using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Modifies a user's role in the project.
    /// <seealso href="https://api.openai.com/v1/organization/projects/{project_id}/users/{user_id}">https://api.openai.com/v1/organization/projects/{project_id}/users/{user_id}</seealso>
    /// </summary>
    public partial class OrganizationProjectUserModifyParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// owner or member
        /// </summary>
        public string Role { get; set; } = "";
        public string Project_Id { get; set; } = "";
        public string User_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/projects/{Project_Id}/users/{User_Id}";
        }
        public override object GetRequestBody()
        {
            return new {
            	role = this.Role,
            };
        }
    }
    public partial class OrganizationProjectUserModifyResponse : ProjectUserObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationProjectUserModifyResponse> OrganizationProjectUserModifyAsync(string role)
        {
            var p = new OrganizationProjectUserModifyParameter();
            p.Role = role;
            return await this.SendJsonAsync<OrganizationProjectUserModifyParameter, OrganizationProjectUserModifyResponse>(p, CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectUserModifyResponse> OrganizationProjectUserModifyAsync(string role, CancellationToken cancellationToken)
        {
            var p = new OrganizationProjectUserModifyParameter();
            p.Role = role;
            return await this.SendJsonAsync<OrganizationProjectUserModifyParameter, OrganizationProjectUserModifyResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationProjectUserModifyResponse> OrganizationProjectUserModifyAsync(OrganizationProjectUserModifyParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationProjectUserModifyParameter, OrganizationProjectUserModifyResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectUserModifyResponse> OrganizationProjectUserModifyAsync(OrganizationProjectUserModifyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationProjectUserModifyParameter, OrganizationProjectUserModifyResponse>(parameter, cancellationToken);
        }
    }
}
