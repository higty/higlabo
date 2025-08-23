using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// List uploaded certificates for this organization.
    /// <seealso href="https://api.openai.com/v1/organization/certificates">https://api.openai.com/v1/organization/certificates</seealso>
    /// </summary>
    public partial class OrganizationCertificatesParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly OrganizationCertificatesParameter Empty = new OrganizationCertificatesParameter();

        string IRestApiParameter.HttpMethod { get; } = "GET";
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
            return $"/organization/certificates";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationCertificatesResponse : RestApiDataResponse<List<CertificateObject>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationCertificatesResponse> OrganizationCertificatesAsync()
        {
            return await this.SendJsonAsync<OrganizationCertificatesParameter, OrganizationCertificatesResponse>(OrganizationCertificatesParameter.Empty, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationCertificatesResponse> OrganizationCertificatesAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationCertificatesParameter, OrganizationCertificatesResponse>(OrganizationCertificatesParameter.Empty, cancellationToken);
        }
        public async ValueTask<OrganizationCertificatesResponse> OrganizationCertificatesAsync(OrganizationCertificatesParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationCertificatesParameter, OrganizationCertificatesResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationCertificatesResponse> OrganizationCertificatesAsync(OrganizationCertificatesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationCertificatesParameter, OrganizationCertificatesResponse>(parameter, cancellationToken);
        }
    }
}
