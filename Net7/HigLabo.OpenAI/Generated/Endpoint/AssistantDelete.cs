using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Delete an assistant.
    /// <seealso href="https://api.openai.com/v1/assistants/{assistant_id}">https://api.openai.com/v1/assistants/{assistant_id}</seealso>
    /// </summary>
    public partial class AssistantDeleteParameter : IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        /// <summary>
        /// The ID of the assistant to delete.
        /// </summary>
        public string Assistant_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/assistants/{Assistant_Id}";
        }
    }
    public partial class AssistantDeleteResponse : DeleteObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<AssistantDeleteResponse> AssistantDeleteAsync(string assistant_Id, CancellationToken cancellationToken)
        {
            var p = new AssistantDeleteParameter();
            p.Assistant_Id = assistant_Id;
            return await this.SendJsonAsync<AssistantDeleteParameter, AssistantDeleteResponse>(p, cancellationToken);
        }
        public async ValueTask<AssistantDeleteResponse> AssistantDeleteAsync(AssistantDeleteParameter parameter)
        {
            return await this.SendJsonAsync<AssistantDeleteParameter, AssistantDeleteResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<AssistantDeleteResponse> AssistantDeleteAsync(AssistantDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<AssistantDeleteParameter, AssistantDeleteResponse>(parameter, cancellationToken);
        }
    }
}
