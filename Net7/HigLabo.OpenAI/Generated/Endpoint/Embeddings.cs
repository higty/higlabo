using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Creates an embedding vector representing the input text.
    /// <seealso href="https://api.openai.com/v1/embeddings">https://api.openai.com/v1/embeddings</seealso>
    /// </summary>
    public partial class EmbeddingsParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// Input text to embed, encoded as a string or array of tokens. To embed multiple inputs in a single request, pass an array of strings or array of token arrays. The input must not exceed the max input tokens for the model (8192 tokens for text-embedding-ada-002) and cannot be an empty string. Example Python code for counting tokens.
        /// </summary>
        public string Input { get; set; } = "";
        /// <summary>
        /// ID of the model to use. You can use the List models API to see all of your available models, or see our Model overview for descriptions of them.
        /// </summary>
        public string Model { get; set; } = "";
        /// <summary>
        /// The format to return the embeddings in. Can be either float or base64.
        /// </summary>
        public string? Encoding_Format { get; set; }
        /// <summary>
        /// A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse. Learn more.
        /// </summary>
        public string? User { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/embeddings";
        }
        public override object GetRequestBody()
        {
            return new {
            	input = this.Input,
            	model = this.Model,
            	encoding_format = this.Encoding_Format,
            	user = this.User,
            };
        }
    }
    public partial class EmbeddingsResponse : RestApiDataResponse<List<EmbeddingObject>>
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<EmbeddingsResponse> EmbeddingsAsync(string input, string model)
        {
            var p = new EmbeddingsParameter();
            p.Input = input;
            p.Model = model;
            return await this.SendJsonAsync<EmbeddingsParameter, EmbeddingsResponse>(p, CancellationToken.None);
        }
        public async ValueTask<EmbeddingsResponse> EmbeddingsAsync(string input, string model, CancellationToken cancellationToken)
        {
            var p = new EmbeddingsParameter();
            p.Input = input;
            p.Model = model;
            return await this.SendJsonAsync<EmbeddingsParameter, EmbeddingsResponse>(p, cancellationToken);
        }
        public async ValueTask<EmbeddingsResponse> EmbeddingsAsync(EmbeddingsParameter parameter)
        {
            return await this.SendJsonAsync<EmbeddingsParameter, EmbeddingsResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<EmbeddingsResponse> EmbeddingsAsync(EmbeddingsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<EmbeddingsParameter, EmbeddingsResponse>(parameter, cancellationToken);
        }
    }
}
