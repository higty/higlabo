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
    /// Deactivate certificates at the organization level.
    /// You can atomically and idempotently deactivate up to 10 certificates at a time.
    /// <seealso href="https://api.openai.com/v1/organization/certificates/deactivate">https://api.openai.com/v1/organization/certificates/deactivate</seealso>
    /// </summary>
    public partial class OrganizationCertificateDeactivateParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public List<string>? Certificate_Ids { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/certificates/deactivate";
        }
        public override object GetRequestBody()
        {
            return new {
            	certificate_ids = this.Certificate_Ids,
            };
        }
    }
    public partial class OrganizationCertificateDeactivateResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationCertificateDeactivateResponse> OrganizationCertificateDeactivateAsync(List<string>? certificate_Ids)
        {
            var p = new OrganizationCertificateDeactivateParameter();
            p.Certificate_Ids = certificate_Ids;
            return await this.SendJsonAsync<OrganizationCertificateDeactivateParameter, OrganizationCertificateDeactivateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationCertificateDeactivateResponse> OrganizationCertificateDeactivateAsync(List<string>? certificate_Ids, CancellationToken cancellationToken)
        {
            var p = new OrganizationCertificateDeactivateParameter();
            p.Certificate_Ids = certificate_Ids;
            return await this.SendJsonAsync<OrganizationCertificateDeactivateParameter, OrganizationCertificateDeactivateResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationCertificateDeactivateResponse> OrganizationCertificateDeactivateAsync(OrganizationCertificateDeactivateParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationCertificateDeactivateParameter, OrganizationCertificateDeactivateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationCertificateDeactivateResponse> OrganizationCertificateDeactivateAsync(OrganizationCertificateDeactivateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationCertificateDeactivateParameter, OrganizationCertificateDeactivateResponse>(parameter, cancellationToken);
        }
    }
}
