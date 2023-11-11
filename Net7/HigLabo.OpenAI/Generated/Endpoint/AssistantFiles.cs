using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Returns a list of assistant files.
    /// <seealso href="https://api.openai.com/v1/assistants/{assistant_id}/files">https://api.openai.com/v1/assistants/{assistant_id}/files</seealso>
    /// </summary>
    public partial class AssistantFilesParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly AssistantFilesParameter Empty = new AssistantFilesParameter();

        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the assistant the file belongs to.
        /// </summary>
        public string Assistant_Id { get; set; } = "";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public QueryParameter QueryParameter { get; set; } = new QueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/assistants/{Assistant_Id}/files";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class AssistantFilesResponse : RestApiDataResponse<List<AssistantFileObject>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<AssistantFilesResponse> AssistantFilesAsync(string assistant_Id)
        {
            var p = new AssistantFilesParameter();
            p.Assistant_Id = assistant_Id;
            return await this.SendJsonAsync<AssistantFilesParameter, AssistantFilesResponse>(p, CancellationToken.None);
        }
        public async ValueTask<AssistantFilesResponse> AssistantFilesAsync(string assistant_Id, CancellationToken cancellationToken)
        {
            var p = new AssistantFilesParameter();
            p.Assistant_Id = assistant_Id;
            return await this.SendJsonAsync<AssistantFilesParameter, AssistantFilesResponse>(p, cancellationToken);
        }
        public async ValueTask<AssistantFilesResponse> AssistantFilesAsync(AssistantFilesParameter parameter)
        {
            return await this.SendJsonAsync<AssistantFilesParameter, AssistantFilesResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<AssistantFilesResponse> AssistantFilesAsync(AssistantFilesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<AssistantFilesParameter, AssistantFilesResponse>(parameter, cancellationToken);
        }
    }
}
