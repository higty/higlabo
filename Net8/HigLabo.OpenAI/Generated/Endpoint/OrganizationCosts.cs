using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Get costs details for the organization.
    /// <seealso href="https://api.openai.com/v1/organization/costs">https://api.openai.com/v1/organization/costs</seealso>
    /// </summary>
    public partial class OrganizationCostsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly OrganizationCostsParameter Empty = new OrganizationCostsParameter();

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
            return $"/organization/costs";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationCostsResponse : RestApiResponse
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationCostsResponse> OrganizationCostsAsync()
        {
            return await this.SendJsonAsync<OrganizationCostsParameter, OrganizationCostsResponse>(OrganizationCostsParameter.Empty, CancellationToken.None);
        }
        public async ValueTask<OrganizationCostsResponse> OrganizationCostsAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationCostsParameter, OrganizationCostsResponse>(OrganizationCostsParameter.Empty, cancellationToken);
        }
        public async ValueTask<OrganizationCostsResponse> OrganizationCostsAsync(OrganizationCostsParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationCostsParameter, OrganizationCostsResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<OrganizationCostsResponse> OrganizationCostsAsync(OrganizationCostsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationCostsParameter, OrganizationCostsResponse>(parameter, cancellationToken);
        }
    }
}
