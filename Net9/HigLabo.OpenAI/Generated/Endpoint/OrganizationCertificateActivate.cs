using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Activate certificates at the organization level.
    /// You can atomically and idempotently activate up to 10 certificates at a time.
    /// <seealso href="https://api.openai.com/v1/organization/certificates/activate">https://api.openai.com/v1/organization/certificates/activate</seealso>
    /// </summary>
    public partial class OrganizationCertificateActivateParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public List<string>? Certificate_Ids { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/certificates/activate";
        }
        public override object GetRequestBody()
        {
            return new {
            	certificate_ids = this.Certificate_Ids,
            };
        }
    }
    public partial class OrganizationCertificateActivateResponse : CertificateObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationCertificateActivateResponse> OrganizationCertificateActivateAsync(List<string>? certificate_Ids)
        {
            var p = new OrganizationCertificateActivateParameter();
            p.Certificate_Ids = certificate_Ids;
            return await this.SendJsonAsync<OrganizationCertificateActivateParameter, OrganizationCertificateActivateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationCertificateActivateResponse> OrganizationCertificateActivateAsync(List<string>? certificate_Ids, CancellationToken cancellationToken)
        {
            var p = new OrganizationCertificateActivateParameter();
            p.Certificate_Ids = certificate_Ids;
            return await this.SendJsonAsync<OrganizationCertificateActivateParameter, OrganizationCertificateActivateResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationCertificateActivateResponse> OrganizationCertificateActivateAsync(OrganizationCertificateActivateParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationCertificateActivateParameter, OrganizationCertificateActivateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationCertificateActivateResponse> OrganizationCertificateActivateAsync(OrganizationCertificateActivateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationCertificateActivateParameter, OrganizationCertificateActivateResponse>(parameter, cancellationToken);
        }
    }
}
