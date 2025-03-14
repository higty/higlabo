using System.Collections.Generic;
using System.IO;
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
        /// Text, image, or file inputs to the model, used to generate a response.
        /// Learn more:
        /// Text inputs and outputs
        /// Image inputs
        /// File inputs
        /// Conversation state
        /// Function calling
        /// </summary>
        public ResponseInput Input { get; set; } = new ();
        /// <summary>
        /// Model ID used to generate the response, like gpt-4o or o1. OpenAI offers a wide range of models with different capabilities, performance characteristics, and price points. Refer to the model guide to browse and compare available models.
        /// </summary>
        public string Model { get; set; } = "";
        /// <summary>
        /// Specify additional output data to include in the model response. Currently supported values are:
        /// file_search_call.results: Include the search results of the file search tool call.
        /// message.input_image.image_url: Include image urls from the input message.
        /// computer_call_output.output.image_url: Include image urls from the computer call output.
        /// </summary>
        public List<string>? Include { get; set; }
        /// <summary>
        /// Inserts a system (or developer) message as the first item in the model's context.
        /// When using along with previous_response_id, the instructions from a previous response will be not be carried over to the next response. This makes it simple to swap out system (or developer) messages in new responses.
        /// </summary>
        public string? Instructions { get; set; }
        /// <summary>
        /// An upper bound for the number of tokens that can be generated for a response, including visible output tokens and reasoning tokens.
        /// </summary>
        public int? Max_Output_Tokens { get; set; }
        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format, and querying for objects via API or the dashboard.
        /// Keys are strings with a maximum length of 64 characters. Values are strings with a maximum length of 512 characters.
        /// </summary>
        public object? Metadata { get; set; }
        /// <summary>
        /// Whether to allow the model to run tool calls in parallel.
        /// </summary>
        public bool? Parallel_Tool_Calls { get; set; }
        /// <summary>
        /// The unique ID of the previous response to the model. Use this to create multi-turn conversations. Learn more about conversation state.
        /// </summary>
        public string? Previous_Response_Id { get; set; }
        /// <summary>
        /// o-series models only
        /// Configuration options for reasoning models.
        /// </summary>
        public Reasoning? Reasoning { get; set; }
        /// <summary>
        /// Whether to store the generated model response for later retrieval via API.
        /// </summary>
        public bool? Store { get; set; }
        /// <summary>
        /// If set to true, the model response data will be streamed to the client as it is generated using server-sent events. See the Streaming section below for more information.
        /// </summary>
        public bool? Stream { get; set; }
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
        /// The two categories of tools you can provide the model are:
        /// Built-in tools: Tools that are provided by OpenAI that extend the model's capabilities, like web search or file search. Learn more about built-in tools.
        /// Function calls (custom tools): Functions that are defined by you, enabling the model to call your own code. Learn more about function calling.
        /// </summary>
        public List<ToolObject>? Tools { get; set; }
        /// <summary>
        /// An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered.
        /// We generally recommend altering this or temperature but not both.
        /// </summary>
        public double? Top_P { get; set; }
        /// <summary>
        /// The truncation strategy to use for the model response.
        /// auto: If the context of this response and previous ones exceeds the model's context window size, the model will truncate the response to fit the context window by dropping input items in the middle of the conversation.
        /// disabled (default): If a model response will exceed the context window size for a model, the request will fail with a 400 error.
        /// </summary>
        public string? Truncation { get; set; }
        /// <summary>
        /// A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse. Learn more.
        /// </summary>
        public string? User { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/responses";
        }
        public override object GetRequestBody()
        {
            return new {
            	input = this.Input,
            	model = this.Model,
            	include = this.Include,
            	instructions = this.Instructions,
            	max_output_tokens = this.Max_Output_Tokens,
            	metadata = this.Metadata,
            	parallel_tool_calls = this.Parallel_Tool_Calls,
            	previous_response_id = this.Previous_Response_Id,
            	reasoning = this.Reasoning,
            	store = this.Store,
            	stream = this.Stream,
            	temperature = this.Temperature,
            	text = this.Text,
            	tool_choice = this.Tool_Choice,
            	tools = this.Tools,
            	top_p = this.Top_P,
            	truncation = this.Truncation,
            	user = this.User,
            };
        }
    }
    public partial class ResponseCreateResponse : ResponseObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ResponseCreateResponse> ResponseCreateAsync(ResponseInput input, string model)
        {
            var p = new ResponseCreateParameter();
            p.Input = input;
            p.Model = model;
            return await this.SendJsonAsync<ResponseCreateParameter, ResponseCreateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ResponseCreateResponse> ResponseCreateAsync(ResponseInput input, string model, CancellationToken cancellationToken)
        {
            var p = new ResponseCreateParameter();
            p.Input = input;
            p.Model = model;
            p.Stream = null;
            return await this.SendJsonAsync<ResponseCreateParameter, ResponseCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<ResponseCreateResponse> ResponseCreateAsync(ResponseCreateParameter parameter)
        {
            return await this.SendJsonAsync<ResponseCreateParameter, ResponseCreateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ResponseCreateResponse> ResponseCreateAsync(ResponseCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ResponseCreateParameter, ResponseCreateResponse>(parameter, cancellationToken);
        }
        public async IAsyncEnumerable<string> ResponseCreateStreamAsync(ResponseInput input, string model)
        {
            var p = new ResponseCreateParameter();
            p.Input = input;
            p.Model = model;
            p.Stream = true;
            await foreach (var item in this.GetStreamAsync(p, null, System.Threading.CancellationToken.None))
            {
                yield return item;
            }
        }
        public async IAsyncEnumerable<string> ResponseCreateStreamAsync(ResponseInput input, string model, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var p = new ResponseCreateParameter();
            p.Input = input;
            p.Model = model;
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
