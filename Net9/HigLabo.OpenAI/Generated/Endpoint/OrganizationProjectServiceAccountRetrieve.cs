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
    /// Retrieves a service account in the project.
    /// <seealso href="https://api.openai.com/v1/organization/projects/{project_id}/service_accounts/{service_account_id}">https://api.openai.com/v1/organization/projects/{project_id}/service_accounts/{service_account_id}</seealso>
    /// </summary>
    public partial class OrganizationProjectServiceAccountRetrieveParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
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
    public partial class OrganizationProjectServiceAccountRetrieveResponse : ProjectServiceAccountObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationProjectServiceAccountRetrieveResponse> OrganizationProjectServiceAccountRetrieveAsync(string project_Id, string service_Account_Id)
        {
            var p = new OrganizationProjectServiceAccountRetrieveParameter();
            p.Project_Id = project_Id;
            p.Service_Account_Id = service_Account_Id;
            return await this.SendJsonAsync<OrganizationProjectServiceAccountRetrieveParameter, OrganizationProjectServiceAccountRetrieveResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectServiceAccountRetrieveResponse> OrganizationProjectServiceAccountRetrieveAsync(string project_Id, string service_Account_Id, CancellationToken cancellationToken)
        {
            var p = new OrganizationProjectServiceAccountRetrieveParameter();
            p.Project_Id = project_Id;
            p.Service_Account_Id = service_Account_Id;
            return await this.SendJsonAsync<OrganizationProjectServiceAccountRetrieveParameter, OrganizationProjectServiceAccountRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationProjectServiceAccountRetrieveResponse> OrganizationProjectServiceAccountRetrieveAsync(OrganizationProjectServiceAccountRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationProjectServiceAccountRetrieveParameter, OrganizationProjectServiceAccountRetrieveResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectServiceAccountRetrieveResponse> OrganizationProjectServiceAccountRetrieveAsync(OrganizationProjectServiceAccountRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationProjectServiceAccountRetrieveParameter, OrganizationProjectServiceAccountRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
