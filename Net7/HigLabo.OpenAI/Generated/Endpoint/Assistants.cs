using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Returns a list of assistants.
    /// <seealso href="https://api.openai.com/v1/assistants">https://api.openai.com/v1/assistants</seealso>
    /// </summary>
    public partial class AssistantsParameter : IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";

        string IRestApiParameter.GetApiPath()
        {
            return $"/assistants";
        }
    }
    public partial class AssistantsResponse : RestApiDataResponse<List<AssistantObject>>
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<AssistantsResponse> AssistantsAsync()
        {
            var p = new AssistantsParameter();
            return await this.SendJsonAsync<AssistantsParameter, AssistantsResponse>(p, CancellationToken.None);
        }
        public async ValueTask<AssistantsResponse> AssistantsAsync(CancellationToken cancellationToken)
        {
            var p = new AssistantsParameter();
            return await this.SendJsonAsync<AssistantsParameter, AssistantsResponse>(p, cancellationToken);
        }
        public async ValueTask<AssistantsResponse> AssistantsAsync(AssistantsParameter parameter)
        {
            return await this.SendJsonAsync<AssistantsParameter, AssistantsResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<AssistantsResponse> AssistantsAsync(AssistantsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<AssistantsParameter, AssistantsResponse>(parameter, cancellationToken);
        }
    }
}
