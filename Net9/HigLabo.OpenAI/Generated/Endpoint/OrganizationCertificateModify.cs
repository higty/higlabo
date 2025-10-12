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
    /// Modify a certificate. Note that only the name can be modified.
    /// <seealso href="https://api.openai.com/v1/organization/certificates/{certificate_id}">https://api.openai.com/v1/organization/certificates/{certificate_id}</seealso>
    /// </summary>
    public partial class OrganizationCertificateModifyParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The updated name for the certificate
        /// </summary>
        public string Name { get; set; } = "";
        public string Certificate_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/certificates/{Certificate_Id}";
        }
        public override object GetRequestBody()
        {
            return new {
            	name = this.Name,
            };
        }
    }
    public partial class OrganizationCertificateModifyResponse : CertificateObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationCertificateModifyResponse> OrganizationCertificateModifyAsync(string name)
        {
            var p = new OrganizationCertificateModifyParameter();
            p.Name = name;
            return await this.SendJsonAsync<OrganizationCertificateModifyParameter, OrganizationCertificateModifyResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationCertificateModifyResponse> OrganizationCertificateModifyAsync(string name, CancellationToken cancellationToken)
        {
            var p = new OrganizationCertificateModifyParameter();
            p.Name = name;
            return await this.SendJsonAsync<OrganizationCertificateModifyParameter, OrganizationCertificateModifyResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationCertificateModifyResponse> OrganizationCertificateModifyAsync(OrganizationCertificateModifyParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationCertificateModifyParameter, OrganizationCertificateModifyResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationCertificateModifyResponse> OrganizationCertificateModifyAsync(OrganizationCertificateModifyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationCertificateModifyParameter, OrganizationCertificateModifyResponse>(parameter, cancellationToken);
        }
    }
}
