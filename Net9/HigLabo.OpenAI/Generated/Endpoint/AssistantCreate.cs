﻿using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Create an assistant with a model and instructions.
    /// <seealso href="https://api.openai.com/v1/assistants">https://api.openai.com/v1/assistants</seealso>
    /// </summary>
    public partial class AssistantCreateParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// ID of the model to use. You can use the List models API to see all of your available models, or see our Model overview for descriptions of them.
        /// </summary>
        public string Model { get; set; } = "";
        /// <summary>
        /// The description of the assistant. The maximum length is 512 characters.
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// The system instructions that the assistant uses. The maximum length is 256,000 characters.
        /// </summary>
        public string? Instructions { get; set; }
        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format, and querying for objects via API or the dashboard.
        /// Keys are strings with a maximum length of 64 characters. Values are strings with a maximum length of 512 characters.
        /// </summary>
        public object? Metadata { get; set; }
        /// <summary>
        /// The name of the assistant. The maximum length is 256 characters.
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// o-series models only
        /// Constrains effort on reasoning for reasoning models. Currently supported values are low, medium, and high. Reducing reasoning effort can result in faster responses and fewer tokens used on reasoning in a response.
        /// </summary>
        public string? Reasoning_Effort { get; set; }
        /// <summary>
        /// Specifies the format that the model must output. Compatible with GPT-4o, GPT-4 Turbo, and all GPT-3.5 Turbo models since gpt-3.5-turbo-1106.
        /// Setting to { "type": "json_schema", "json_schema": {...} } enables Structured Outputs which ensures the model will match your supplied JSON schema. Learn more in the Structured Outputs guide.
        /// Setting to { "type": "json_object" } enables JSON mode, which ensures the message the model generates is valid JSON.
        /// Important: when using JSON mode, you must also instruct the model to produce JSON yourself via a system or user message. Without this, the model may generate an unending stream of whitespace until the generation reaches the token limit, resulting in a long-running and seemingly "stuck" request. Also note that the message content may be partially cut off if finish_reason="length", which indicates the generation exceeded max_tokens or the conversation exceeded the max context length.
        /// </summary>
        public object? Response_Format { get; set; }
        /// <summary>
        /// What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic.
        /// </summary>
        public double? Temperature { get; set; }
        /// <summary>
        /// A set of resources that are used by the assistant's tools. The resources are specific to the type of tool. For example, the code_interpreter tool requires a list of file IDs, while the file_search tool requires a list of vector store IDs.
        /// </summary>
        public object? Tool_Resources { get; set; }
        /// <summary>
        /// A list of tool enabled on the assistant. There can be a maximum of 128 tools per assistant. Tools can be of types code_interpreter, file_search, or function.
        /// </summary>
        public List<ChatCompletionFunctionTool>? Tools { get; set; }
        /// <summary>
        /// An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered.
        /// We generally recommend altering this or temperature but not both.
        /// </summary>
        public double? Top_P { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/assistants";
        }
        public override object GetRequestBody()
        {
            return new {
            	model = this.Model,
            	description = this.Description,
            	instructions = this.Instructions,
            	metadata = this.Metadata,
            	name = this.Name,
            	reasoning_effort = this.Reasoning_Effort,
            	response_format = this.Response_Format,
            	temperature = this.Temperature,
            	tool_resources = this.Tool_Resources,
            	tools = this.Tools,
            	top_p = this.Top_P,
            };
        }
    }
    public partial class AssistantCreateResponse : AssistantObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<AssistantCreateResponse> AssistantCreateAsync(string model)
        {
            var p = new AssistantCreateParameter();
            p.Model = model;
            return await this.SendJsonAsync<AssistantCreateParameter, AssistantCreateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<AssistantCreateResponse> AssistantCreateAsync(string model, CancellationToken cancellationToken)
        {
            var p = new AssistantCreateParameter();
            p.Model = model;
            return await this.SendJsonAsync<AssistantCreateParameter, AssistantCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<AssistantCreateResponse> AssistantCreateAsync(AssistantCreateParameter parameter)
        {
            return await this.SendJsonAsync<AssistantCreateParameter, AssistantCreateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<AssistantCreateResponse> AssistantCreateAsync(AssistantCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<AssistantCreateParameter, AssistantCreateResponse>(parameter, cancellationToken);
        }
    }
}
