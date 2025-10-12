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
        public OrganizationProjectCertificatesQueryParameter QueryParameter { get; set; } = new OrganizationProjectCertificatesQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/projects/{Project_Id}/certificates";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class OrganizationProjectCertificatesQueryParameter : IQueryParameter
    {
        /// <summary>
        /// A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list.
        /// </summary>
        public string? After { get; set; }
        /// <summary>
        /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20.
        /// </summary>
        public int? Limit { get; set; }
        /// <summary>
        /// Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order.
        /// </summary>
        public string? Order { get; set; }

        string IQueryParameter.GetQueryString()
        {
            var sb = new StringBuilder();
            if (this.After != null)
            {
                sb.Append($"after={WebUtility.UrlEncode(this.After)}&");
            }
            if (this.Limit != null)
            {
                sb.Append($"limit={this.Limit}&");
            }
            if (this.Order != null)
            {
                sb.Append($"order={WebUtility.UrlEncode(this.Order)}&");
            }
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class OrganizationProjectCertificatesResponse : RestApiDataResponse<List<CertificateObject>>
    {
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
