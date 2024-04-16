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
        /// The ID of an uploaded file that contains requests for the new batch.See upload file for how to upload a file.Your input file must be formatted as a JSONL file, and must be uploaded with the purpose batch.
        /// </summary>
        public string Input_File_Id { get; set; } = "";
        /// <summary>
        /// The endpoint to be used for all requests in the batch. Currently only /v1/chat/completions is supported.
        /// </summary>
        public string Endpoint { get; set; } = "";
        /// <summary>
        /// The time frame within which the batch should be processed. Currently only 24h is supported.
        /// </summary>
        public string Completion_Window { get; set; } = "";
        /// <summary>
        /// Optional custom metadata for the batch.
        /// </summary>
        public object? Metadata { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/batches";
        }
        public override object GetRequestBody()
        {
            return new {
            	input_file_id = this.Input_File_Id,
            	endpoint = this.Endpoint,
            	completion_window = this.Completion_Window,
            	metadata = this.Metadata,
            };
        }
    }
    public partial class BatchCreateResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<BatchCreateResponse> BatchCreateAsync(string input_File_Id, string endpoint, string completion_Window)
        {
            var p = new BatchCreateParameter();
            p.Input_File_Id = input_File_Id;
            p.Endpoint = endpoint;
            p.Completion_Window = completion_Window;
            return await this.SendJsonAsync<BatchCreateParameter, BatchCreateResponse>(p, CancellationToken.None);
        }
        public async ValueTask<BatchCreateResponse> BatchCreateAsync(string input_File_Id, string endpoint, string completion_Window, CancellationToken cancellationToken)
        {
            var p = new BatchCreateParameter();
            p.Input_File_Id = input_File_Id;
            p.Endpoint = endpoint;
            p.Completion_Window = completion_Window;
            return await this.SendJsonAsync<BatchCreateParameter, BatchCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<BatchCreateResponse> BatchCreateAsync(BatchCreateParameter parameter)
        {
            return await this.SendJsonAsync<BatchCreateParameter, BatchCreateResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<BatchCreateResponse> BatchCreateAsync(BatchCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<BatchCreateParameter, BatchCreateResponse>(parameter, cancellationToken);
        }
    }
}
