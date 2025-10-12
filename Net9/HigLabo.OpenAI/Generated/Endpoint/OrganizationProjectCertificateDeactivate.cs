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
    /// Deactivate certificates at the project level. You can atomically and idempotently deactivate up to 10 certificates at a time.
    /// <seealso href="https://api.openai.com/v1/organization/projects/{project_id}/certificates/deactivate">https://api.openai.com/v1/organization/projects/{project_id}/certificates/deactivate</seealso>
    /// </summary>
    public partial class OrganizationProjectCertificateDeactivateParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the project.
        /// </summary>
        public string Project_Id { get; set; } = "";
        public List<string>? Certificate_Ids { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/projects/{Project_Id}/certificates/deactivate";
        }
        public override object GetRequestBody()
        {
            return new {
            	certificate_ids = this.Certificate_Ids,
            };
        }
    }
    public partial class OrganizationProjectCertificateDeactivateResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationProjectCertificateDeactivateResponse> OrganizationProjectCertificateDeactivateAsync(string project_Id, List<string>? certificate_Ids)
        {
            var p = new OrganizationProjectCertificateDeactivateParameter();
            p.Project_Id = project_Id;
            p.Certificate_Ids = certificate_Ids;
            return await this.SendJsonAsync<OrganizationProjectCertificateDeactivateParameter, OrganizationProjectCertificateDeactivateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectCertificateDeactivateResponse> OrganizationProjectCertificateDeactivateAsync(string project_Id, List<string>? certificate_Ids, CancellationToken cancellationToken)
        {
            var p = new OrganizationProjectCertificateDeactivateParameter();
            p.Project_Id = project_Id;
            p.Certificate_Ids = certificate_Ids;
            return await this.SendJsonAsync<OrganizationProjectCertificateDeactivateParameter, OrganizationProjectCertificateDeactivateResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationProjectCertificateDeactivateResponse> OrganizationProjectCertificateDeactivateAsync(OrganizationProjectCertificateDeactivateParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationProjectCertificateDeactivateParameter, OrganizationProjectCertificateDeactivateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectCertificateDeactivateResponse> OrganizationProjectCertificateDeactivateAsync(OrganizationProjectCertificateDeactivateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationProjectCertificateDeactivateParameter, OrganizationProjectCertificateDeactivateResponse>(parameter, cancellationToken);
        }
    }
}
