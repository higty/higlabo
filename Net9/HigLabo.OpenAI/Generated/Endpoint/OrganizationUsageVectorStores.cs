using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Get vector stores usage details for the organization.
    /// <seealso href="https://api.openai.com/v1/organization/usage/vector_stores">https://api.openai.com/v1/organization/usage/vector_stores</seealso>
    /// </summary>
    public partial class OrganizationUsageVectorStoresParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly OrganizationUsageVectorStoresParameter Empty = new OrganizationUsageVectorStoresParameter();

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
            return $"/organization/usage/vector_stores";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationUsageVectorStoresResponse : RestApiDataResponse<List<OrganizationUsageVectorStoreObject>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationUsageVectorStoresResponse> OrganizationUsageVectorStoresAsync()
        {
            return await this.SendJsonAsync<OrganizationUsageVectorStoresParameter, OrganizationUsageVectorStoresResponse>(OrganizationUsageVectorStoresParameter.Empty, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationUsageVectorStoresResponse> OrganizationUsageVectorStoresAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationUsageVectorStoresParameter, OrganizationUsageVectorStoresResponse>(OrganizationUsageVectorStoresParameter.Empty, cancellationToken);
        }
        public async ValueTask<OrganizationUsageVectorStoresResponse> OrganizationUsageVectorStoresAsync(OrganizationUsageVectorStoresParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationUsageVectorStoresParameter, OrganizationUsageVectorStoresResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationUsageVectorStoresResponse> OrganizationUsageVectorStoresAsync(OrganizationUsageVectorStoresParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationUsageVectorStoresParameter, OrganizationUsageVectorStoresResponse>(parameter, cancellationToken);
        }
    }
}
