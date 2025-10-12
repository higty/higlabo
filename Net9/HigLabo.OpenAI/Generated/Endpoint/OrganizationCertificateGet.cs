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
        public OrganizationCertificateGetQueryParameter QueryParameter { get; set; } = new OrganizationCertificateGetQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/certificates/{Certificate_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class OrganizationCertificateGetQueryParameter : IQueryParameter
    {
        /// <summary>
        /// A list of additional fields to include in the response. Currently the only supported value is content to fetch the PEM content of the certificate.
        /// </summary>
        public List<string>? Include { get; set; }

        string IQueryParameter.GetQueryString()
        {
            var sb = new StringBuilder();
            if (this.Include != null)
            {
                foreach (var item in this.Include)
                {
                    sb.Append($"include[]={item}&");
                }
            }
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class OrganizationCertificateGetResponse : CertificateObjectResponse
    {
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
