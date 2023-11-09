using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Retrieves an assistant.
    /// <seealso href="https://api.openai.com/v1/assistants/{assistant_id}">https://api.openai.com/v1/assistants/{assistant_id}</seealso>
    /// </summary>
    public partial class AssistantRetrieveParameter : IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the assistant to retrieve.
        /// </summary>
        public string Assistant_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/assistants/{Assistant_Id}";
        }
    }
    public partial class AssistantRetrieveResponse : AssistantObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<AssistantRetrieveResponse> AssistantRetrieveAsync(string assistant_Id, CancellationToken cancellationToken)
        {
            var p = new AssistantRetrieveParameter();
            p.Assistant_Id = assistant_Id;
            return await this.SendJsonAsync<AssistantRetrieveParameter, AssistantRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<AssistantRetrieveResponse> AssistantRetrieveAsync(AssistantRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<AssistantRetrieveParameter, AssistantRetrieveResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<AssistantRetrieveResponse> AssistantRetrieveAsync(AssistantRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<AssistantRetrieveParameter, AssistantRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
