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
    /// Activate certificates at the project level.
    /// You can atomically and idempotently activate up to 10 certificates at a time.
    /// <seealso href="https://api.openai.com/v1/organization/projects/{project_id}/certificates/activate">https://api.openai.com/v1/organization/projects/{project_id}/certificates/activate</seealso>
    /// </summary>
    public partial class OrganizationProjectCertificateActivateParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the project.
        /// </summary>
        public string Project_Id { get; set; } = "";
        public List<string>? Certificate_Ids { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/projects/{Project_Id}/certificates/activate";
        }
        public override object GetRequestBody()
        {
            return new {
            	certificate_ids = this.Certificate_Ids,
            };
        }
    }
    public partial class OrganizationProjectCertificateActivateResponse : CertificateObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationProjectCertificateActivateResponse> OrganizationProjectCertificateActivateAsync(string project_Id, List<string>? certificate_Ids)
        {
            var p = new OrganizationProjectCertificateActivateParameter();
            p.Project_Id = project_Id;
            p.Certificate_Ids = certificate_Ids;
            return await this.SendJsonAsync<OrganizationProjectCertificateActivateParameter, OrganizationProjectCertificateActivateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectCertificateActivateResponse> OrganizationProjectCertificateActivateAsync(string project_Id, List<string>? certificate_Ids, CancellationToken cancellationToken)
        {
            var p = new OrganizationProjectCertificateActivateParameter();
            p.Project_Id = project_Id;
            p.Certificate_Ids = certificate_Ids;
            return await this.SendJsonAsync<OrganizationProjectCertificateActivateParameter, OrganizationProjectCertificateActivateResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationProjectCertificateActivateResponse> OrganizationProjectCertificateActivateAsync(OrganizationProjectCertificateActivateParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationProjectCertificateActivateParameter, OrganizationProjectCertificateActivateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectCertificateActivateResponse> OrganizationProjectCertificateActivateAsync(OrganizationProjectCertificateActivateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationProjectCertificateActivateParameter, OrganizationProjectCertificateActivateResponse>(parameter, cancellationToken);
        }
    }
}
