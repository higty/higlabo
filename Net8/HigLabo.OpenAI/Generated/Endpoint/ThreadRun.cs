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
    public partial class ThreadRunParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter
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
        /// A set of resources that are used by the assistant's tools. The resources are specific to the type of tool. For example, the code_interpreter tool requires a list of file IDs, while the file_search tool requires a list of vector store IDs.
        /// </summary>
        public object? Tool_Resources { get; set; }
        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format. Keys can be a maximum of 64 characters long and values can be a maxium of 512 characters long.
        /// </summary>
        public object? Metadata { get; set; }
        /// <summary>
        /// What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic.
        /// </summary>
        public double? Temperature { get; set; }
        /// <summary>
        /// An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered.We generally recommend altering this or temperature but not both.
        /// </summary>
        public double? Top_P { get; set; }
        /// <summary>
        /// If true, returns a stream of events that happen during the Run as server-sent events, terminating when the Run enters a terminal state with a data: [DONE] message.
        /// </summary>
        public bool? Stream { get; set; }
        /// <summary>
        /// The maximum number of prompt tokens that may be used over the course of the run. The run will make a best effort to use only the number of prompt tokens specified, across multiple turns of the run. If the run exceeds the number of prompt tokens specified, the run will end with status incomplete. See incomplete_details for more info.
        /// </summary>
        public int? Max_Prompt_Tokens { get; set; }
        /// <summary>
        /// The maximum number of completion tokens that may be used over the course of the run. The run will make a best effort to use only the number of completion tokens specified, across multiple turns of the run. If the run exceeds the number of completion tokens specified, the run will end with status incomplete. See incomplete_details for more info.
        /// </summary>
        public int? Max_Completion_Tokens { get; set; }
        /// <summary>
        /// Controls for how a thread will be truncated prior to the run. Use this to control the intial context window of the run.
        /// </summary>
        public object? Truncation_Strategy { get; set; }
        /// <summary>
        /// Controls which (if any) tool is called by the model.
        /// none means the model will not call any tools and instead generates a message.
        /// auto is the default value and means the model can pick between generating a message or calling one or more tools.
        /// required means the model must call one or more tools before responding to the user.
        /// Specifying a particular tool like {"type": "file_search"} or {"type": "function", "function": {"name": "my_function"}} forces the model to call that tool.
        /// </summary>
        public string? Tool_Choice { get; set; }
        /// <summary>
        /// Specifies the format that the model must output. Compatible with GPT-4o, GPT-4 Turbo, and all GPT-3.5 Turbo models since gpt-3.5-turbo-1106.Setting to { "type": "json_object" } enables JSON mode, which guarantees the message the model generates is valid JSON.Important: when using JSON mode, you must also instruct the model to produce JSON yourself via a system or user message. Without this, the model may generate an unending stream of whitespace until the generation reaches the token limit, resulting in a long-running and seemingly "stuck" request. Also note that the message content may be partially cut off if finish_reason="length", which indicates the generation exceeded max_tokens or the conversation exceeded the max context length.
        /// </summary>
        public string? Response_Format { get; set; }

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
            	tool_resources = this.Tool_Resources,
            	metadata = this.Metadata,
            	temperature = this.Temperature,
            	top_p = this.Top_P,
            	stream = this.Stream,
            	max_prompt_tokens = this.Max_Prompt_Tokens,
            	max_completion_tokens = this.Max_Completion_Tokens,
            	truncation_strategy = this.Truncation_Strategy,
            	tool_choice = this.Tool_Choice,
            	response_format = this.Response_Format,
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
        public async IAsyncEnumerable<string> ThreadRunStreamAsync(string assistant_Id)
        {
            var p = new ThreadRunParameter();
            p.Assistant_Id = assistant_Id;
            p.Stream = true;
            await foreach (var item in this.GetStreamAsync(p, null, CancellationToken.None))
            {
                yield return item;
            }
        }
        public async IAsyncEnumerable<string> ThreadRunStreamAsync(string assistant_Id, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var p = new ThreadRunParameter();
            p.Assistant_Id = assistant_Id;
            p.Stream = true;
            await foreach (var item in this.GetStreamAsync(p, null, cancellationToken))
            {
                yield return item;
            }
        }
        public async IAsyncEnumerable<string> ThreadRunStreamAsync(ThreadRunParameter parameter)
        {
            parameter.Stream = true;
            await foreach (var item in this.GetStreamAsync(parameter, null, CancellationToken.None))
            {
                yield return item;
            }
        }
        public async IAsyncEnumerable<string> ThreadRunStreamAsync(ThreadRunParameter parameter, AssistantMessageStreamResult result)
        {
            parameter.Stream = true;
            await foreach (var item in this.GetStreamAsync(parameter, result, CancellationToken.None))
            {
                yield return item;
            }
        }
        public async IAsyncEnumerable<string> ThreadRunStreamAsync(ThreadRunParameter parameter, AssistantMessageStreamResult result, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            parameter.Stream = true;
            await foreach (var item in this.GetStreamAsync(parameter, result, cancellationToken))
            {
                yield return item;
            }
        }
    }
}
