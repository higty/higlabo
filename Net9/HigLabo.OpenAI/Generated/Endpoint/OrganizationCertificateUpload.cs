using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Upload a certificate to the organization. This does not automatically activate the certificate.
    /// Organizations can upload up to 50 certificates.
    /// <seealso href="https://api.openai.com/v1/organization/certificates">https://api.openai.com/v1/organization/certificates</seealso>
    /// </summary>
    public partial class OrganizationCertificateUploadParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The certificate content in PEM format
        /// </summary>
        public string Content { get; set; } = "";
        /// <summary>
        /// An optional name for the certificate
        /// </summary>
        public string? Name { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/certificates";
        }
        public override object GetRequestBody()
        {
            return new {
            	content = this.Content,
            	name = this.Name,
            };
        }
    }
    public partial class OrganizationCertificateUploadResponse : CertificateObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationCertificateUploadResponse> OrganizationCertificateUploadAsync(string content)
        {
            var p = new OrganizationCertificateUploadParameter();
            p.Content = content;
            return await this.SendJsonAsync<OrganizationCertificateUploadParameter, OrganizationCertificateUploadResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationCertificateUploadResponse> OrganizationCertificateUploadAsync(string content, CancellationToken cancellationToken)
        {
            var p = new OrganizationCertificateUploadParameter();
            p.Content = content;
            return await this.SendJsonAsync<OrganizationCertificateUploadParameter, OrganizationCertificateUploadResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationCertificateUploadResponse> OrganizationCertificateUploadAsync(OrganizationCertificateUploadParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationCertificateUploadParameter, OrganizationCertificateUploadResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationCertificateUploadResponse> OrganizationCertificateUploadAsync(OrganizationCertificateUploadParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationCertificateUploadParameter, OrganizationCertificateUploadResponse>(parameter, cancellationToken);
        }
    }
}
