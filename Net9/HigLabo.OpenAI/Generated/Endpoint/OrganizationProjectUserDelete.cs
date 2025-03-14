using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Deletes a user from the project.
    /// <seealso href="https://api.openai.com/v1/organization/projects/{project_id}/users/{user_id}">https://api.openai.com/v1/organization/projects/{project_id}/users/{user_id}</seealso>
    /// </summary>
    public partial class OrganizationProjectUserDeleteParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        /// <summary>
        /// The ID of the project.
        /// </summary>
        public string Project_Id { get; set; } = "";
        /// <summary>
        /// The ID of the user.
        /// </summary>
        public string User_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/projects/{Project_Id}/users/{User_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationProjectUserDeleteResponse : DeleteObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationProjectUserDeleteResponse> OrganizationProjectUserDeleteAsync(string project_Id, string user_Id)
        {
            var p = new OrganizationProjectUserDeleteParameter();
            p.Project_Id = project_Id;
            p.User_Id = user_Id;
            return await this.SendJsonAsync<OrganizationProjectUserDeleteParameter, OrganizationProjectUserDeleteResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectUserDeleteResponse> OrganizationProjectUserDeleteAsync(string project_Id, string user_Id, CancellationToken cancellationToken)
        {
            var p = new OrganizationProjectUserDeleteParameter();
            p.Project_Id = project_Id;
            p.User_Id = user_Id;
            return await this.SendJsonAsync<OrganizationProjectUserDeleteParameter, OrganizationProjectUserDeleteResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationProjectUserDeleteResponse> OrganizationProjectUserDeleteAsync(OrganizationProjectUserDeleteParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationProjectUserDeleteParameter, OrganizationProjectUserDeleteResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectUserDeleteResponse> OrganizationProjectUserDeleteAsync(OrganizationProjectUserDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationProjectUserDeleteParameter, OrganizationProjectUserDeleteResponse>(parameter, cancellationToken);
        }
    }
}
