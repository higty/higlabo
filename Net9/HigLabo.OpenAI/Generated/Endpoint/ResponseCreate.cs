using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Creates a model response. Provide text or image inputs to generate text or JSON outputs. Have the model call your own custom code or use built-in tools like web search or file search to use your own data as input for the model's response.
    /// <seealso href="https://api.openai.com/v1/responses">https://api.openai.com/v1/responses</seealso>
    /// </summary>
    public partial class ResponseCreateParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// Whether to run the model response in the background. Learn more.
        /// </summary>
        public bool? Background { get; set; }
        /// <summary>
        /// The conversation that this response belongs to. Items from this conversation are prepended to input_items for this response request. Input items and output items from this response are automatically added to this conversation after this response completes.
        /// </summary>
        public string? Conversation { get; set; }
        /// <summary>
        /// Specify additional output data to include in the model response. Currently supported values are:
        /// web_search_call.action.sources: Include the sources of the web search tool call.
        /// code_interpreter_call.outputs: Includes the outputs of python code execution in code interpreter tool call items.
        /// computer_call_output.output.image_url: Include image urls from the computer call output.
        /// file_search_call.results: Include the search results of the file search tool call.
        /// message.input_image.image_url: Include image urls from the input message.
        /// message.output_text.logprobs: Include logprobs with assistant messages.
        /// reasoning.encrypted_content: Includes an encrypted version of reasoning tokens in reasoning item outputs. This enables reasoning items to be used in multi-turn conversations when using the Responses API statelessly (like when the store parameter is set to false, or when an organization is enrolled in the zero data retention program).
        /// </summary>
        public List<string>? Include { get; set; }
        /// <summary>
        /// Text, image, or file inputs to the model, used to generate a response.
        /// Learn more:
        /// Text inputs and outputs
        /// Image inputs
        /// File inputs
        /// Conversation state
        /// Function calling
        /// </summary>
        public ResponseInput? Input { get; set; } = new ();
        /// <summary>
        /// A system (or developer) message inserted into the model's context.
        /// When using along with previous_response_id, the instructions from a previous response will not be carried over to the next response. This makes it simple to swap out system (or developer) messages in new responses.
        /// </summary>
        public string? Instructions { get; set; }
        /// <summary>
        /// An upper bound for the number of tokens that can be generated for a response, including visible output tokens and reasoning tokens.
        /// </summary>
        public int? Max_Output_Tokens { get; set; }
        /// <summary>
        /// The maximum number of total calls to built-in tools that can be processed in a response. This maximum number applies across all built-in tool calls, not per individual tool. Any further attempts to call a tool by the model will be ignored.
        /// </summary>
        public int? Max_Tool_Calls { get; set; }
        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format, and querying for objects via API or the dashboard.
        /// Keys are strings with a maximum length of 64 characters. Values are strings with a maximum length of 512 characters.
        /// </summary>
        public object? Metadata { get; set; }
        /// <summary>
        /// Model ID used to generate the response, like gpt-4o or o3. OpenAI offers a wide range of models with different capabilities, performance characteristics, and price points. Refer to the model guide to browse and compare available models.
        /// </summary>
        public string? Model { get; set; }
        /// <summary>
        /// Whether to allow the model to run tool calls in parallel.
        /// </summary>
        public bool? Parallel_Tool_Calls { get; set; }
        /// <summary>
        /// The unique ID of the previous response to the model. Use this to create multi-turn conversations. Learn more about conversation state. Cannot be used in conjunction with conversation.
        /// </summary>
        public string? Previous_Response_Id { get; set; }
        /// <summary>
        /// Reference to a prompt template and its variables. Learn more.
        /// </summary>
        public object? Prompt { get; set; }
        /// <summary>
        /// Used by OpenAI to cache responses for similar requests to optimize your cache hit rates. Replaces the user field. Learn more.
        /// </summary>
        public string? Prompt_Cache_Key { get; set; }
        /// <summary>
        /// gpt-5 and o-series models only
        /// Configuration options for reasoning models.
        /// </summary>
        public Reasoning? Reasoning { get; set; }
        /// <summary>
        /// A stable identifier used to help detect users of your application that may be violating OpenAI's usage policies. The IDs should be a string that uniquely identifies each user. We recommend hashing their username or email address, in order to avoid sending us any identifying information. Learn more.
        /// </summary>
        public string? Safety_Identifier { get; set; }
        /// <summary>
        /// Specifies the processing type used for serving the request.
        /// If set to 'auto', then the request will be processed with the service tier configured in the Project settings. Unless otherwise configured, the Project will use 'default'.
        /// If set to 'default', then the request will be processed with the standard pricing and performance for the selected model.
        /// If set to 'flex' or 'priority', then the request will be processed with the corresponding service tier.
        /// When not set, the default behavior is 'auto'.
        /// When the service_tier parameter is set, the response body will include the service_tier value based on the processing mode actually used to serve the request. This response value may be different from the value set in the parameter.
        /// </summary>
        public string? Service_Tier { get; set; }
        /// <summary>
        /// Whether to store the generated model response for later retrieval via API.
        /// </summary>
        public bool? Store { get; set; }
        /// <summary>
        /// If set to true, the model response data will be streamed to the client as it is generated using server-sent events. See the Streaming section below for more information.
        /// </summary>
        public bool? Stream { get; set; }
        /// <summary>
        /// Options for streaming responses. Only set this when you set stream: true.
        /// </summary>
        public object? Stream_Options { get; set; }
        /// <summary>
        /// What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic. We generally recommend altering this or top_p but not both.
        /// </summary>
        public double? Temperature { get; set; }
        /// <summary>
        /// Configuration options for a text response from the model. Can be plain text or structured JSON data. Learn more:
        /// Text inputs and outputs
        /// Structured Outputs
        /// </summary>
        public object? Text { get; set; }
        /// <summary>
        /// How the model should select which tool (or tools) to use when generating a response. See the tools parameter to see how to specify which tools the model can call.
        /// </summary>
        public string? Tool_Choice { get; set; }
        /// <summary>
        /// An array of tools the model may call while generating a response. You can specify which tool to use by setting the tool_choice parameter.
        /// We support the following categories of tools:
        /// Built-in tools: Tools that are provided by OpenAI that extend the model's capabilities, like web search or file search. Learn more about built-in tools.
        /// MCP Tools: Integrations with third-party systems via custom MCP servers or predefined connectors such as Google Drive and SharePoint. Learn more about MCP Tools.
        /// Function calls (custom tools): Functions that are defined by you, enabling the model to call your own code with strongly typed arguments and outputs. Learn more about function calling. You can also use custom tools to call your own code.
        /// </summary>
        public List<Tool>? Tools { get; set; }
        /// <summary>
        /// An integer between 0 and 20 specifying the number of most likely tokens to return at each token position, each with an associated log probability.
        /// </summary>
        public int? Top_Logprobs { get; set; }
        /// <summary>
        /// An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered.
        /// We generally recommend altering this or temperature but not both.
        /// </summary>
        public double? Top_P { get; set; }
        /// <summary>
        /// The truncation strategy to use for the model response.
        /// auto: If the input to this Response exceeds the model's context window size, the model will truncate the response to fit the context window by dropping items from the beginning of the conversation.
        /// disabled (default): If the input size will exceed the context window size for a model, the request will fail with a 400 error.
        /// </summary>
        public string? Truncation { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/responses";
        }
        public override object GetRequestBody()
        {
            return new {
            	background = this.Background,
            	conversation = this.Conversation,
            	include = this.Include,
            	input = this.Input,
            	instructions = this.Instructions,
            	max_output_tokens = this.Max_Output_Tokens,
            	max_tool_calls = this.Max_Tool_Calls,
            	metadata = this.Metadata,
            	model = this.Model,
            	parallel_tool_calls = this.Parallel_Tool_Calls,
            	previous_response_id = this.Previous_Response_Id,
            	prompt = this.Prompt,
            	prompt_cache_key = this.Prompt_Cache_Key,
            	reasoning = this.Reasoning,
            	safety_identifier = this.Safety_Identifier,
            	service_tier = this.Service_Tier,
            	store = this.Store,
            	stream = this.Stream,
            	stream_options = this.Stream_Options,
            	temperature = this.Temperature,
            	text = this.Text,
            	tool_choice = this.Tool_Choice,
            	tools = this.Tools,
            	top_logprobs = this.Top_Logprobs,
            	top_p = this.Top_P,
            	truncation = this.Truncation,
            };
        }
    }
    public partial class ResponseCreateResponse : ResponseObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ResponseCreateResponse> ResponseCreateAsync()
        {
            var p = new ResponseCreateParameter();
            return await this.SendJsonAsync<ResponseCreateParameter, ResponseCreateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ResponseCreateResponse> ResponseCreateAsync(CancellationToken cancellationToken)
        {
            var p = new ResponseCreateParameter();
            p.Stream = null;
            return await this.SendJsonAsync<ResponseCreateParameter, ResponseCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<ResponseCreateResponse> ResponseCreateAsync(ResponseCreateParameter parameter)
        {
            parameter.Stream = null;
            return await this.SendJsonAsync<ResponseCreateParameter, ResponseCreateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ResponseCreateResponse> ResponseCreateAsync(ResponseCreateParameter parameter, CancellationToken cancellationToken)
        {
            parameter.Stream = null;
            return await this.SendJsonAsync<ResponseCreateParameter, ResponseCreateResponse>(parameter, cancellationToken);
        }
        public async IAsyncEnumerable<string> ResponseCreateStreamAsync()
        {
            var p = new ResponseCreateParameter();
            p.Stream = true;
            await foreach (var item in this.GetStreamAsync(p, null, System.Threading.CancellationToken.None))
            {
                yield return item;
            }
        }
        public async IAsyncEnumerable<string> ResponseCreateStreamAsync([EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var p = new ResponseCreateParameter();
            p.Stream = true;
            await foreach (var item in this.GetStreamAsync(p, null, cancellationToken))
            {
                yield return item;
            }
        }
        public async IAsyncEnumerable<string> ResponseCreateStreamAsync(ResponseCreateParameter parameter)
        {
            parameter.Stream = true;
            await foreach (var item in this.GetStreamAsync(parameter, null, System.Threading.CancellationToken.None))
            {
                yield return item;
            }
        }
        public async IAsyncEnumerable<string> ResponseCreateStreamAsync(ResponseCreateParameter parameter, ResponseStreamResult result)
        {
            parameter.Stream = true;
            await foreach (var item in this.GetStreamAsync(parameter, result, System.Threading.CancellationToken.None))
            {
                yield return item;
            }
        }
        public async IAsyncEnumerable<string> ResponseCreateStreamAsync(ResponseCreateParameter parameter, ResponseStreamResult result, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            parameter.Stream = true;
            await foreach (var item in this.GetStreamAsync(parameter, result, cancellationToken))
            {
                yield return item;
            }
        }
    }
}
