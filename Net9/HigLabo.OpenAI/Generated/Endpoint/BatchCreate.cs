using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Creates and executes a batch from an uploaded file of requests
    /// <seealso href="https://api.openai.com/v1/batches">https://api.openai.com/v1/batches</seealso>
    /// </summary>
    public partial class BatchCreateParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The time frame within which the batch should be processed. Currently only 24h is supported.
        /// </summary>
        public string Completion_Window { get; set; } = "";
        /// <summary>
        /// The endpoint to be used for all requests in the batch. Currently /v1/chat/completions, /v1/embeddings, and /v1/completions are supported. Note that /v1/embeddings batches are also restricted to a maximum of 50,000 embedding inputs across all requests in the batch.
        /// </summary>
        public string Endpoint { get; set; } = "";
        /// <summary>
        /// The ID of an uploaded file that contains requests for the new batch.
        /// See upload file for how to upload a file.
        /// Your input file must be formatted as a JSONL file, and must be uploaded with the purpose batch. The file can contain up to 50,000 requests, and can be up to 200 MB in size.
        /// </summary>
        public string Input_File_Id { get; set; } = "";
        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format, and querying for objects via API or the dashboard.
        /// Keys are strings with a maximum length of 64 characters. Values are strings with a maximum length of 512 characters.
        /// </summary>
        public object? Metadata { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/batches";
        }
        public override object GetRequestBody()
        {
            return new {
            	completion_window = this.Completion_Window,
            	endpoint = this.Endpoint,
            	input_file_id = this.Input_File_Id,
            	metadata = this.Metadata,
            };
        }
    }
    public partial class BatchCreateResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<BatchCreateResponse> BatchCreateAsync(string completion_Window, string endpoint, string input_File_Id)
        {
            var p = new BatchCreateParameter();
            p.Completion_Window = completion_Window;
            p.Endpoint = endpoint;
            p.Input_File_Id = input_File_Id;
            return await this.SendJsonAsync<BatchCreateParameter, BatchCreateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<BatchCreateResponse> BatchCreateAsync(string completion_Window, string endpoint, string input_File_Id, CancellationToken cancellationToken)
        {
            var p = new BatchCreateParameter();
            p.Completion_Window = completion_Window;
            p.Endpoint = endpoint;
            p.Input_File_Id = input_File_Id;
            return await this.SendJsonAsync<BatchCreateParameter, BatchCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<BatchCreateResponse> BatchCreateAsync(BatchCreateParameter parameter)
        {
            return await this.SendJsonAsync<BatchCreateParameter, BatchCreateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<BatchCreateResponse> BatchCreateAsync(BatchCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<BatchCreateParameter, BatchCreateResponse>(parameter, cancellationToken);
        }
    }
}
