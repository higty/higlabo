using System.Collections.Generic;
using System.IO;
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
        /// The ID of the user.
        /// </summary>
        public string User_Id { get; set; } = "";
        /// <summary>
        /// owner or member
        /// </summary>
        public string Role { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/projects/{Project_Id}/users";
        }
        public override object GetRequestBody()
        {
            return new {
            	user_id = this.User_Id,
            	role = this.Role,
            };
        }
    }
    public partial class OrganizationProjectUserCreateResponse : ProjectUserObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationProjectUserCreateResponse> OrganizationProjectUserCreateAsync(string project_Id, string user_Id, string role)
        {
            var p = new OrganizationProjectUserCreateParameter();
            p.Project_Id = project_Id;
            p.User_Id = user_Id;
            p.Role = role;
            return await this.SendJsonAsync<OrganizationProjectUserCreateParameter, OrganizationProjectUserCreateResponse>(p, CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectUserCreateResponse> OrganizationProjectUserCreateAsync(string project_Id, string user_Id, string role, CancellationToken cancellationToken)
        {
            var p = new OrganizationProjectUserCreateParameter();
            p.Project_Id = project_Id;
            p.User_Id = user_Id;
            p.Role = role;
            return await this.SendJsonAsync<OrganizationProjectUserCreateParameter, OrganizationProjectUserCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationProjectUserCreateResponse> OrganizationProjectUserCreateAsync(OrganizationProjectUserCreateParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationProjectUserCreateParameter, OrganizationProjectUserCreateResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectUserCreateResponse> OrganizationProjectUserCreateAsync(OrganizationProjectUserCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationProjectUserCreateParameter, OrganizationProjectUserCreateResponse>(parameter, cancellationToken);
        }
    }
}
