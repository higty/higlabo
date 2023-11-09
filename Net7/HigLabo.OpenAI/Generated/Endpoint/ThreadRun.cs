using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Create a thread and run it in one request.
    /// <seealso href="https://api.openai.com/v1/threads/runs">https://api.openai.com/v1/threads/runs</seealso>
    /// </summary>
    public partial class ThreadRunParameter : IRestApiParameter
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

        string IRestApiParameter.GetApiPath()
        {
            return $"/threads/runs";
        }
    }
    public partial class ThreadRunResponse : RunObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ThreadRunResponse> ThreadRunAsync(string assistant_Id, CancellationToken cancellationToken)
        {
            var p = new ThreadRunParameter();
            p.Assistant_Id = assistant_Id;
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
    }
}
