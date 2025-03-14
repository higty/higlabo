using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Retrieves a user in the project.
    /// <seealso href="https://api.openai.com/v1/organization/projects/{project_id}/users/{user_id}">https://api.openai.com/v1/organization/projects/{project_id}/users/{user_id}</seealso>
    /// </summary>
    public partial class OrganizationProjectUserRetrieveParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
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
    public partial class OrganizationProjectUserRetrieveResponse : ProjectUserObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationProjectUserRetrieveResponse> OrganizationProjectUserRetrieveAsync(string project_Id, string user_Id)
        {
            var p = new OrganizationProjectUserRetrieveParameter();
            p.Project_Id = project_Id;
            p.User_Id = user_Id;
            return await this.SendJsonAsync<OrganizationProjectUserRetrieveParameter, OrganizationProjectUserRetrieveResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectUserRetrieveResponse> OrganizationProjectUserRetrieveAsync(string project_Id, string user_Id, CancellationToken cancellationToken)
        {
            var p = new OrganizationProjectUserRetrieveParameter();
            p.Project_Id = project_Id;
            p.User_Id = user_Id;
            return await this.SendJsonAsync<OrganizationProjectUserRetrieveParameter, OrganizationProjectUserRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationProjectUserRetrieveResponse> OrganizationProjectUserRetrieveAsync(OrganizationProjectUserRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationProjectUserRetrieveParameter, OrganizationProjectUserRetrieveResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectUserRetrieveResponse> OrganizationProjectUserRetrieveAsync(OrganizationProjectUserRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationProjectUserRetrieveParameter, OrganizationProjectUserRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
