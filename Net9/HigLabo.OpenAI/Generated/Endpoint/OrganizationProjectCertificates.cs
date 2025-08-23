using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// List certificates for this project.
    /// <seealso href="https://api.openai.com/v1/organization/projects/{project_id}/certificates">https://api.openai.com/v1/organization/projects/{project_id}/certificates</seealso>
    /// </summary>
    public partial class OrganizationProjectCertificatesParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the project.
        /// </summary>
        public string Project_Id { get; set; } = "";
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
            return $"/organization/projects/{Project_Id}/certificates";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationProjectCertificatesResponse : RestApiDataResponse<List<CertificateObject>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationProjectCertificatesResponse> OrganizationProjectCertificatesAsync(string project_Id)
        {
            var p = new OrganizationProjectCertificatesParameter();
            p.Project_Id = project_Id;
            return await this.SendJsonAsync<OrganizationProjectCertificatesParameter, OrganizationProjectCertificatesResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectCertificatesResponse> OrganizationProjectCertificatesAsync(string project_Id, CancellationToken cancellationToken)
        {
            var p = new OrganizationProjectCertificatesParameter();
            p.Project_Id = project_Id;
            return await this.SendJsonAsync<OrganizationProjectCertificatesParameter, OrganizationProjectCertificatesResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationProjectCertificatesResponse> OrganizationProjectCertificatesAsync(OrganizationProjectCertificatesParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationProjectCertificatesParameter, OrganizationProjectCertificatesResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectCertificatesResponse> OrganizationProjectCertificatesAsync(OrganizationProjectCertificatesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationProjectCertificatesParameter, OrganizationProjectCertificatesResponse>(parameter, cancellationToken);
        }
    }
}
