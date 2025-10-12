using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Adds a user to the project. Users must already be members of the organization to be added to a project.
    /// <seealso href="https://api.openai.com/v1/organization/projects/{project_id}/users">https://api.openai.com/v1/organization/projects/{project_id}/users</seealso>
    /// </summary>
    public partial class OrganizationProjectUserCreateParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the project.
        /// </summary>
        public string Project_Id { get; set; } = "";
        /// <summary>
        /// owner or member
        /// </summary>
        public string Role { get; set; } = "";
        /// <summary>
        /// The ID of the user.
        /// </summary>
        public string User_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/projects/{Project_Id}/users";
        }
        public override object GetRequestBody()
        {
            return new {
            	role = this.Role,
            	user_id = this.User_Id,
            };
        }
    }
    public partial class OrganizationProjectUserCreateResponse : ProjectUserObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationProjectUserCreateResponse> OrganizationProjectUserCreateAsync(string project_Id, string role, string user_Id)
        {
            var p = new OrganizationProjectUserCreateParameter();
            p.Project_Id = project_Id;
            p.Role = role;
            p.User_Id = user_Id;
            return await this.SendJsonAsync<OrganizationProjectUserCreateParameter, OrganizationProjectUserCreateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectUserCreateResponse> OrganizationProjectUserCreateAsync(string project_Id, string role, string user_Id, CancellationToken cancellationToken)
        {
            var p = new OrganizationProjectUserCreateParameter();
            p.Project_Id = project_Id;
            p.Role = role;
            p.User_Id = user_Id;
            return await this.SendJsonAsync<OrganizationProjectUserCreateParameter, OrganizationProjectUserCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationProjectUserCreateResponse> OrganizationProjectUserCreateAsync(OrganizationProjectUserCreateParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationProjectUserCreateParameter, OrganizationProjectUserCreateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectUserCreateResponse> OrganizationProjectUserCreateAsync(OrganizationProjectUserCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationProjectUserCreateParameter, OrganizationProjectUserCreateResponse>(parameter, cancellationToken);
        }
    }
}
