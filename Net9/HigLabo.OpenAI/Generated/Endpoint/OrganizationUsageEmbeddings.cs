using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Get embeddings usage details for the organization.
    /// <seealso href="https://api.openai.com/v1/organization/usage/embeddings">https://api.openai.com/v1/organization/usage/embeddings</seealso>
    /// </summary>
    public partial class OrganizationUsageEmbeddingsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly OrganizationUsageEmbeddingsParameter Empty = new OrganizationUsageEmbeddingsParameter();

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
            return $"/organization/usage/embeddings";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationUsageEmbeddingsResponse : RestApiDataResponse<List<OrganizationUsageEmbeddingObject>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationUsageEmbeddingsResponse> OrganizationUsageEmbeddingsAsync()
        {
            return await this.SendJsonAsync<OrganizationUsageEmbeddingsParameter, OrganizationUsageEmbeddingsResponse>(OrganizationUsageEmbeddingsParameter.Empty, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationUsageEmbeddingsResponse> OrganizationUsageEmbeddingsAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationUsageEmbeddingsParameter, OrganizationUsageEmbeddingsResponse>(OrganizationUsageEmbeddingsParameter.Empty, cancellationToken);
        }
        public async ValueTask<OrganizationUsageEmbeddingsResponse> OrganizationUsageEmbeddingsAsync(OrganizationUsageEmbeddingsParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationUsageEmbeddingsParameter, OrganizationUsageEmbeddingsResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationUsageEmbeddingsResponse> OrganizationUsageEmbeddingsAsync(OrganizationUsageEmbeddingsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationUsageEmbeddingsParameter, OrganizationUsageEmbeddingsResponse>(parameter, cancellationToken);
        }
    }
}
