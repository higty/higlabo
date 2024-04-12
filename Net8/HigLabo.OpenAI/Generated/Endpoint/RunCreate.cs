using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Create a run.
    /// <seealso href="https://api.openai.com/v1/threads/{thread_id}/runs">https://api.openai.com/v1/threads/{thread_id}/runs</seealso>
    /// </summary>
    public partial class RunCreateParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the thread to run.
        /// </summary>
        public string Thread_Id { get; set; } = "";
        /// <summary>
        /// The ID of the assistant to use to execute this run.
        /// </summary>
        public string Assistant_Id { get; set; } = "";
        /// <summary>
        /// The ID of the Model to be used to execute this run. If a value is provided here, it will override the model associated with the assistant. If not, the model associated with the assistant will be used.
        /// </summary>
        public string? Model { get; set; }
        /// <summary>
        /// Overrides the instructions of the assistant. This is useful for modifying the behavior on a per-run basis.
        /// </summary>
        public string? Instructions { get; set; }
        /// <summary>
        /// Appends additional instructions at the end of the instructions for the run. This is useful for modifying the behavior on a per-run basis without overriding other instructions.
        /// </summary>
        public string? Additional_Instructions { get; set; }
        /// <summary>
        /// Adds additional messages to the thread before creating the run.
        /// </summary>
        public List<ThreadAdditionalMessageObject>? Additional_Messages { get; set; }
        /// <summary>
        /// Override the tools the assistant can use for this run. This is useful for modifying the behavior on a per-run basis.
        /// </summary>
        public List<ToolObject>? Tools { get; set; }
        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format. Keys can be a maximum of 64 characters long and values can be a maxium of 512 characters long.
        /// </summary>
        public object? Metadata { get; set; }
        /// <summary>
        /// What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic.
        /// </summary>
        public double? Temperature { get; set; }
        /// <summary>
        /// If true, returns a stream of events that happen during the Run as server-sent events, terminating when the Run enters a terminal state with a data: [DONE] message.
        /// </summary>
        public bool? Stream { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/threads/{Thread_Id}/runs";
        }
        public override object GetRequestBody()
        {
            return new {
            	assistant_id = this.Assistant_Id,
            	model = this.Model,
            	instructions = this.Instructions,
            	additional_instructions = this.Additional_Instructions,
            	additional_messages = this.Additional_Messages,
            	tools = this.Tools,
            	metadata = this.Metadata,
            	temperature = this.Temperature,
            	stream = this.Stream,
            };
        }
    }
    public partial class RunCreateResponse : RunObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<RunCreateResponse> RunCreateAsync(string thread_Id, string assistant_Id)
        {
            var p = new RunCreateParameter();
            p.Thread_Id = thread_Id;
            p.Assistant_Id = assistant_Id;
            return await this.SendJsonAsync<RunCreateParameter, RunCreateResponse>(p, CancellationToken.None);
        }
        public async ValueTask<RunCreateResponse> RunCreateAsync(string thread_Id, string assistant_Id, CancellationToken cancellationToken)
        {
            var p = new RunCreateParameter();
            p.Thread_Id = thread_Id;
            p.Assistant_Id = assistant_Id;
            p.Stream = null;
            return await this.SendJsonAsync<RunCreateParameter, RunCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<RunCreateResponse> RunCreateAsync(RunCreateParameter parameter)
        {
            return await this.SendJsonAsync<RunCreateParameter, RunCreateResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<RunCreateResponse> RunCreateAsync(RunCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<RunCreateParameter, RunCreateResponse>(parameter, cancellationToken);
        }
        public async IAsyncEnumerable<string> RunCreateStreamAsync(string thread_Id, string assistant_Id)
        {
            var p = new RunCreateParameter();
            p.Thread_Id = thread_Id;
            p.Assistant_Id = assistant_Id;
            p.Stream = true;
            await foreach (var item in this.GetStreamAsync(p, null, CancellationToken.None))
            {
                yield return item;
            }
        }
        public async IAsyncEnumerable<string> RunCreateStreamAsync(string thread_Id, string assistant_Id, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var p = new RunCreateParameter();
            p.Thread_Id = thread_Id;
            p.Assistant_Id = assistant_Id;
            p.Stream = true;
            await foreach (var item in this.GetStreamAsync(p, null, cancellationToken))
            {
                yield return item;
            }
        }
        public async IAsyncEnumerable<string> RunCreateStreamAsync(RunCreateParameter parameter)
        {
            parameter.Stream = true;
            await foreach (var item in this.GetStreamAsync(parameter, null, CancellationToken.None))
            {
                yield return item;
            }
        }
        public async IAsyncEnumerable<string> RunCreateStreamAsync(RunCreateParameter parameter, AssistantMessageStreamResult result)
        {
            parameter.Stream = true;
            await foreach (var item in this.GetStreamAsync(parameter, result, CancellationToken.None))
            {
                yield return item;
            }
        }
        public async IAsyncEnumerable<string> RunCreateStreamAsync(RunCreateParameter parameter, AssistantMessageStreamResult result, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            parameter.Stream = true;
            await foreach (var item in this.GetStreamAsync(parameter, result, cancellationToken))
            {
                yield return item;
            }
        }
    }
}
