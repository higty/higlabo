using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Returns a list of assistants.
    /// <seealso href="https://api.openai.com/v1/assistants">https://api.openai.com/v1/assistants</seealso>
    /// </summary>
    public partial class AssistantsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public IQueryParameter QueryParameter { get; set; } = new QueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/assistants";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class AssistantsResponse : RestApiDataResponse<List<AssistantObject>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
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
