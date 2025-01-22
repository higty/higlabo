using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Deletes a service account from the project.
    /// <seealso href="https://api.openai.com/v1/organization/projects/{project_id}/service_accounts/{service_account_id}">https://api.openai.com/v1/organization/projects/{project_id}/service_accounts/{service_account_id}</seealso>
    /// </summary>
    public partial class OrganizationProjectServiceAccountDeleteParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        /// <summary>
        /// The ID of the project.
        /// </summary>
        public string Project_Id { get; set; } = "";
        /// <summary>
        /// The ID of the service account.
        /// </summary>
        public string Service_Account_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/projects/{Project_Id}/service_accounts/{Service_Account_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationProjectServiceAccountDeleteResponse : DeleteObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationProjectServiceAccountDeleteResponse> OrganizationProjectServiceAccountDeleteAsync(string project_Id, string service_Account_Id)
        {
            var p = new OrganizationProjectServiceAccountDeleteParameter();
            p.Project_Id = project_Id;
            p.Service_Account_Id = service_Account_Id;
            return await this.SendJsonAsync<OrganizationProjectServiceAccountDeleteParameter, OrganizationProjectServiceAccountDeleteResponse>(p, CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectServiceAccountDeleteResponse> OrganizationProjectServiceAccountDeleteAsync(string project_Id, string service_Account_Id, CancellationToken cancellationToken)
        {
            var p = new OrganizationProjectServiceAccountDeleteParameter();
            p.Project_Id = project_Id;
            p.Service_Account_Id = service_Account_Id;
            return await this.SendJsonAsync<OrganizationProjectServiceAccountDeleteParameter, OrganizationProjectServiceAccountDeleteResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationProjectServiceAccountDeleteResponse> OrganizationProjectServiceAccountDeleteAsync(OrganizationProjectServiceAccountDeleteParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationProjectServiceAccountDeleteParameter, OrganizationProjectServiceAccountDeleteResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectServiceAccountDeleteResponse> OrganizationProjectServiceAccountDeleteAsync(OrganizationProjectServiceAccountDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationProjectServiceAccountDeleteParameter, OrganizationProjectServiceAccountDeleteResponse>(parameter, cancellationToken);
        }
    }
}
