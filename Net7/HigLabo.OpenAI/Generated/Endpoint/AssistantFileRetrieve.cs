using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Retrieves an AssistantFile.
    /// <seealso href="https://api.openai.com/v1/assistants/{assistant_id}/files/{file_id}">https://api.openai.com/v1/assistants/{assistant_id}/files/{file_id}</seealso>
    /// </summary>
    public partial class AssistantFileRetrieveParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the assistant who the file belongs to.
        /// </summary>
        public string Assistant_Id { get; set; } = "";
        /// <summary>
        /// The ID of the file we're getting.
        /// </summary>
        public string File_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/assistants/{Assistant_Id}/files/{File_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class AssistantFileRetrieveResponse : AssistantFileObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<AssistantFileRetrieveResponse> AssistantFileRetrieveAsync(string assistant_Id, string file_Id)
        {
            var p = new AssistantFileRetrieveParameter();
            p.Assistant_Id = assistant_Id;
            p.File_Id = file_Id;
            return await this.SendJsonAsync<AssistantFileRetrieveParameter, AssistantFileRetrieveResponse>(p, CancellationToken.None);
        }
        public async ValueTask<AssistantFileRetrieveResponse> AssistantFileRetrieveAsync(string assistant_Id, string file_Id, CancellationToken cancellationToken)
        {
            var p = new AssistantFileRetrieveParameter();
            p.Assistant_Id = assistant_Id;
            p.File_Id = file_Id;
            return await this.SendJsonAsync<AssistantFileRetrieveParameter, AssistantFileRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<AssistantFileRetrieveResponse> AssistantFileRetrieveAsync(AssistantFileRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<AssistantFileRetrieveParameter, AssistantFileRetrieveResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<AssistantFileRetrieveResponse> AssistantFileRetrieveAsync(AssistantFileRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<AssistantFileRetrieveParameter, AssistantFileRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
