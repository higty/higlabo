using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

/// <summary>
/// Create a vector store.
/// <seealso href="https://api.openai.com/v1/vector_stores">https://api.openai.com/v1/vector_stores</seealso>
/// </summary>
public partial class VectorStoreCreateParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "POST";
    /// <summary>
    /// A list of File IDs that the vector store should use. Useful for tools like file_search that can access files.
    /// </summary>
    public List<string>? File_Ids { get; set; }
    /// <summary>
    /// The name of the vector store.
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// The expiration policy for a vector store.
    /// </summary>
    public object? Expires_After { get; set; }
    /// <summary>
    /// The chunking strategy used to chunk the file(s). If not set, will use the auto strategy. Only applicable if file_ids is non-empty.
    /// </summary>
    public ChunkingStrategy? Chunking_Strategy { get; set; }
    /// <summary>
    /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format. Keys can be a maximum of 64 characters long and values can be a maxium of 512 characters long.
    /// </summary>
    public object? Metadata { get; set; }

    string IRestApiParameter.GetApiPath()
    {
        return $"/vector_stores";
    }
    public override object GetRequestBody()
    {
        return new {
        	file_ids = this.File_Ids,
        	name = this.Name,
        	expires_after = this.Expires_After,
        	chunking_strategy = this.Chunking_Strategy,
        	metadata = this.Metadata,
        };
    }
}
public partial class VectorStoreCreateResponse : VectorStoreObjectResponse
{
}
public partial class OpenAIClient
{
    public async ValueTask<VectorStoreCreateResponse> VectorStoreCreateAsync()
    {
        var p = new VectorStoreCreateParameter();
        return await this.SendJsonAsync<VectorStoreCreateParameter, VectorStoreCreateResponse>(p, CancellationToken.None);
    }
    public async ValueTask<VectorStoreCreateResponse> VectorStoreCreateAsync(CancellationToken cancellationToken)
    {
        var p = new VectorStoreCreateParameter();
        return await this.SendJsonAsync<VectorStoreCreateParameter, VectorStoreCreateResponse>(p, cancellationToken);
    }
    public async ValueTask<VectorStoreCreateResponse> VectorStoreCreateAsync(VectorStoreCreateParameter parameter)
    {
        return await this.SendJsonAsync<VectorStoreCreateParameter, VectorStoreCreateResponse>(parameter, CancellationToken.None);
    }
    public async ValueTask<VectorStoreCreateResponse> VectorStoreCreateAsync(VectorStoreCreateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<VectorStoreCreateParameter, VectorStoreCreateResponse>(parameter, cancellationToken);
    }
}
