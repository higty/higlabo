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
        /// The ID of the project.
        /// </summary>
        public string Project_Id { get; set; } = "";
        /// <summary>
        /// The ID of the user.
        /// </summary>
        public string User_Id { get; set; } = "";
        /// <summary>
        /// owner or member
        /// </summary>
        public string Role { get; set; } = "";

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
        public async ValueTask<OrganizationProjectUserModifyResponse> OrganizationProjectUserModifyAsync(string project_Id, string user_Id, string role)
        {
            var p = new OrganizationProjectUserModifyParameter();
            p.Project_Id = project_Id;
            p.User_Id = user_Id;
            p.Role = role;
            return await this.SendJsonAsync<OrganizationProjectUserModifyParameter, OrganizationProjectUserModifyResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectUserModifyResponse> OrganizationProjectUserModifyAsync(string project_Id, string user_Id, string role, CancellationToken cancellationToken)
        {
            var p = new OrganizationProjectUserModifyParameter();
            p.Project_Id = project_Id;
            p.User_Id = user_Id;
            p.Role = role;
            return await this.SendJsonAsync<OrganizationProjectUserModifyParameter, OrganizationProjectUserModifyResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationProjectUserModifyResponse> OrganizationProjectUserModifyAsync(OrganizationProjectUserModifyParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationProjectUserModifyParameter, OrganizationProjectUserModifyResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectUserModifyResponse> OrganizationProjectUserModifyAsync(OrganizationProjectUserModifyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationProjectUserModifyParameter, OrganizationProjectUserModifyResponse>(parameter, cancellationToken);
        }
    }
}
