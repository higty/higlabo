using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Get a certificate that has been uploaded to the organization.
    /// You can get a certificate regardless of whether it is active or not.
    /// <seealso href="https://api.openai.com/v1/organization/certificates/{certificate_id}">https://api.openai.com/v1/organization/certificates/{certificate_id}</seealso>
    /// </summary>
    public partial class OrganizationCertificateGetParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// Unique ID of the certificate to retrieve.
        /// </summary>
        public string Certificate_Id { get; set; } = "";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public QueryParameter QueryParameter { get; set; } = new QueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/certificates/{Certificate_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationCertificateGetResponse : CertificateObjectResponse
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationCertificateGetResponse> OrganizationCertificateGetAsync(string certificate_Id)
        {
            var p = new OrganizationCertificateGetParameter();
            p.Certificate_Id = certificate_Id;
            return await this.SendJsonAsync<OrganizationCertificateGetParameter, OrganizationCertificateGetResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationCertificateGetResponse> OrganizationCertificateGetAsync(string certificate_Id, CancellationToken cancellationToken)
        {
            var p = new OrganizationCertificateGetParameter();
            p.Certificate_Id = certificate_Id;
            return await this.SendJsonAsync<OrganizationCertificateGetParameter, OrganizationCertificateGetResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationCertificateGetResponse> OrganizationCertificateGetAsync(OrganizationCertificateGetParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationCertificateGetParameter, OrganizationCertificateGetResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationCertificateGetResponse> OrganizationCertificateGetAsync(OrganizationCertificateGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationCertificateGetParameter, OrganizationCertificateGetResponse>(parameter, cancellationToken);
        }
    }
}
