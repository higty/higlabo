using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Search a vector store for relevant chunks based on a query and file attributes filter.
    /// <seealso href="https://api.openai.com/v1/vector_stores/{vector_store_id}/search">https://api.openai.com/v1/vector_stores/{vector_store_id}/search</seealso>
    /// </summary>
    public partial class VectorStoreSearchParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the vector store to search.
        /// </summary>
        public string Vector_Store_Id { get; set; } = "";
        /// <summary>
        /// A query string for a search
        /// </summary>
        public string Query { get; set; } = "";
        /// <summary>
        /// A filter to apply based on file attributes.
        /// </summary>
        public object? Filters { get; set; }
        /// <summary>
        /// The maximum number of results to return. This number should be between 1 and 50 inclusive.
        /// </summary>
        public int? Max_Num_Results { get; set; }
        /// <summary>
        /// Ranking options for search.
        /// </summary>
        public object? Ranking_Options { get; set; }
        /// <summary>
        /// Whether to rewrite the natural language query for vector search.
        /// </summary>
        public bool? Rewrite_Query { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/vector_stores/{Vector_Store_Id}/search";
        }
        public override object GetRequestBody()
        {
            return new {
            	query = this.Query,
            	filters = this.Filters,
            	max_num_results = this.Max_Num_Results,
            	ranking_options = this.Ranking_Options,
            	rewrite_query = this.Rewrite_Query,
            };
        }
    }
    public partial class VectorStoreSearchResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<VectorStoreSearchResponse> VectorStoreSearchAsync(string vector_Store_Id, string query)
        {
            var p = new VectorStoreSearchParameter();
            p.Vector_Store_Id = vector_Store_Id;
            p.Query = query;
            return await this.SendJsonAsync<VectorStoreSearchParameter, VectorStoreSearchResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreSearchResponse> VectorStoreSearchAsync(string vector_Store_Id, string query, CancellationToken cancellationToken)
        {
            var p = new VectorStoreSearchParameter();
            p.Vector_Store_Id = vector_Store_Id;
            p.Query = query;
            return await this.SendJsonAsync<VectorStoreSearchParameter, VectorStoreSearchResponse>(p, cancellationToken);
        }
        public async ValueTask<VectorStoreSearchResponse> VectorStoreSearchAsync(VectorStoreSearchParameter parameter)
        {
            return await this.SendJsonAsync<VectorStoreSearchParameter, VectorStoreSearchResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreSearchResponse> VectorStoreSearchAsync(VectorStoreSearchParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<VectorStoreSearchParameter, VectorStoreSearchResponse>(parameter, cancellationToken);
        }
    }
}
