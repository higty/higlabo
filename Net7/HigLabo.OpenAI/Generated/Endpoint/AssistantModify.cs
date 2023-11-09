using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Modifies an assistant.
    /// <seealso href="https://api.openai.com/v1/assistants/{assistant_id}">https://api.openai.com/v1/assistants/{assistant_id}</seealso>
    /// </summary>
    public partial class AssistantModifyParameter : IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the assistant to modify.
        /// </summary>
        public string Assistant_Id { get; set; } = "";
        /// <summary>
        /// ID of the model to use. You can use the List models API to see all of your available models, or see our Model overview for descriptions of them.
        /// </summary>
        public string? Model { get; set; }
        /// <summary>
        /// The name of the assistant. The maximum length is 256 characters.
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// The description of the assistant. The maximum length is 512 characters.
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// The system instructions that the assistant uses. The maximum length is 32768 characters.
        /// </summary>
        public string? Instructions { get; set; }
        /// <summary>
        /// A list of tool enabled on the assistant. There can be a maximum of 128 tools per assistant. Tools can be of types code_interpreter, retrieval, or function.
        /// </summary>
        public List<ToolObject>? Tools { get; set; }
        /// <summary>
        /// A list of File IDs attached to this assistant. There can be a maximum of 20 files attached to the assistant. Files are ordered by their creation date in ascending order. If a file was previosuly attached to the list but does not show up in the list, it will be deleted from the assistant.
        /// </summary>
        public List<string>? File_Ids { get; set; }
        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format. Keys can be a maximum of 64 characters long and values can be a maxium of 512 characters long.
        /// </summary>
        public object? Metadata { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/assistants/{Assistant_Id}";
        }
    }
    public partial class AssistantModifyResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<AssistantModifyResponse> AssistantModifyAsync(string assistant_Id)
        {
            var p = new AssistantModifyParameter();
            p.Assistant_Id = assistant_Id;
            return await this.SendJsonAsync<AssistantModifyParameter, AssistantModifyResponse>(p, CancellationToken.None);
        }
        public async ValueTask<AssistantModifyResponse> AssistantModifyAsync(string assistant_Id, CancellationToken cancellationToken)
        {
            var p = new AssistantModifyParameter();
            p.Assistant_Id = assistant_Id;
            return await this.SendJsonAsync<AssistantModifyParameter, AssistantModifyResponse>(p, cancellationToken);
        }
        public async ValueTask<AssistantModifyResponse> AssistantModifyAsync(AssistantModifyParameter parameter)
        {
            return await this.SendJsonAsync<AssistantModifyParameter, AssistantModifyResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<AssistantModifyResponse> AssistantModifyAsync(AssistantModifyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<AssistantModifyParameter, AssistantModifyResponse>(parameter, cancellationToken);
        }
    }
}
