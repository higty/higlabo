using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Create a thread and run it in one request.
    /// <seealso href="https://api.openai.com/v1/threads/runs">https://api.openai.com/v1/threads/runs</seealso>
    /// </summary>
    public partial class ThreadRunParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the assistant to use to execute this run.
        /// </summary>
        public string Assistant_Id { get; set; } = "";
        public object? Thread { get; set; }
        /// <summary>
        /// The ID of the Model to be used to execute this run. If a value is provided here, it will override the model associated with the assistant. If not, the model associated with the assistant will be used.
        /// </summary>
        public string? Model { get; set; }
        /// <summary>
        /// Override the default system message of the assistant. This is useful for modifying the behavior on a per-run basis.
        /// </summary>
        public string? Instructions { get; set; }
        /// <summary>
        /// Override the tools the assistant can use for this run. This is useful for modifying the behavior on a per-run basis.
        /// </summary>
        public List<ToolObject>? Tools { get; set; }
        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format. Keys can be a maximum of 64 characters long and values can be a maxium of 512 characters long.
        /// </summary>
        public object? Metadata { get; set; }
        /// <summary>
        /// If true, returns a stream of events that happen during the Run as server-sent events, terminating when the Run enters a terminal state with a data: [DONE] message.
        /// </summary>
        public bool? Stream { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/threads/runs";
        }
        public override object GetRequestBody()
        {
            return new {
            	assistant_id = this.Assistant_Id,
            	thread = this.Thread,
            	model = this.Model,
            	instructions = this.Instructions,
            	tools = this.Tools,
            	metadata = this.Metadata,
            	stream = this.Stream,
            };
        }
    }
    public partial class ThreadRunResponse : RunObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ThreadRunResponse> ThreadRunAsync(string assistant_Id)
        {
            var p = new ThreadRunParameter();
            p.Assistant_Id = assistant_Id;
            return await this.SendJsonAsync<ThreadRunParameter, ThreadRunResponse>(p, CancellationToken.None);
        }
        public async ValueTask<ThreadRunResponse> ThreadRunAsync(string assistant_Id, CancellationToken cancellationToken)
        {
            var p = new ThreadRunParameter();
            p.Assistant_Id = assistant_Id;
            p.Stream = null;
            return await this.SendJsonAsync<ThreadRunParameter, ThreadRunResponse>(p, cancellationToken);
        }
        public async ValueTask<ThreadRunResponse> ThreadRunAsync(ThreadRunParameter parameter)
        {
            return await this.SendJsonAsync<ThreadRunParameter, ThreadRunResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<ThreadRunResponse> ThreadRunAsync(ThreadRunParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ThreadRunParameter, ThreadRunResponse>(parameter, cancellationToken);
        }
        public async IAsyncEnumerable<AssistantDeltaObject> ThreadRunStreamAsync(string assistant_Id)
        {
            var p = new ThreadRunParameter();
            p.Assistant_Id = assistant_Id;
            p.Stream = true;
            await foreach (var item in this.GetStreamAsync<ThreadRunParameter, AssistantDeltaObject>(p, CancellationToken.None))
            {
                yield return item;
            }
        }
        public async IAsyncEnumerable<AssistantDeltaObject> ThreadRunStreamAsync(string assistant_Id, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var p = new ThreadRunParameter();
            p.Assistant_Id = assistant_Id;
            p.Stream = true;
            await foreach (var item in this.GetStreamAsync<ThreadRunParameter, AssistantDeltaObject>(p, cancellationToken))
            {
                yield return item;
            }
        }
        public async IAsyncEnumerable<AssistantDeltaObject> ThreadRunStreamAsync(ThreadRunParameter parameter)
        {
            await foreach (var item in this.GetStreamAsync<ThreadRunParameter, AssistantDeltaObject>(parameter, CancellationToken.None))
            {
                yield return item;
            }
        }
        public async IAsyncEnumerable<AssistantDeltaObject> ThreadRunStreamAsync(ThreadRunParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            parameter.Stream = true;
            await foreach (var item in this.GetStreamAsync<ThreadRunParameter, AssistantDeltaObject>(parameter, cancellationToken))
            {
                yield return item;
            }
        }
    }
}
