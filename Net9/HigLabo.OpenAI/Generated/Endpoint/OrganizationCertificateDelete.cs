using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Delete a certificate from the organization.
    /// The certificate must be inactive for the organization and all projects.
    /// <seealso href="https://api.openai.com/v1/organization/certificates/{certificate_id}">https://api.openai.com/v1/organization/certificates/{certificate_id}</seealso>
    /// </summary>
    public partial class OrganizationCertificateDeleteParameter : RestApiParameter, IRestApiParameter
    {
        internal static readonly OrganizationCertificateDeleteParameter Empty = new OrganizationCertificateDeleteParameter();

        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Certificate_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/certificates/{Certificate_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationCertificateDeleteResponse : DeleteObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationCertificateDeleteResponse> OrganizationCertificateDeleteAsync()
        {
            return await this.SendJsonAsync<OrganizationCertificateDeleteParameter, OrganizationCertificateDeleteResponse>(OrganizationCertificateDeleteParameter.Empty, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationCertificateDeleteResponse> OrganizationCertificateDeleteAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationCertificateDeleteParameter, OrganizationCertificateDeleteResponse>(OrganizationCertificateDeleteParameter.Empty, cancellationToken);
        }
        public async ValueTask<OrganizationCertificateDeleteResponse> OrganizationCertificateDeleteAsync(OrganizationCertificateDeleteParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationCertificateDeleteParameter, OrganizationCertificateDeleteResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationCertificateDeleteResponse> OrganizationCertificateDeleteAsync(OrganizationCertificateDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationCertificateDeleteParameter, OrganizationCertificateDeleteResponse>(parameter, cancellationToken);
        }
    }
}
